using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileSystem {
     [Serializable]
    public class FileSystem {
        MyDisk disk = new MyDisk();
        OpenedFileList openedFiles;
        Directory root = new Directory();
        Directory tempCurDir; //暂时的当前目录，中间的定位操作什么的要用到
        Directory curDir; //当前目录
        private int duplicateFileCount;//重名的文件数，创建文件的时候用,好像这样不行，待完善...
        public FileSystem() {
            openedFiles = new OpenedFileList(disk.getFAT());
            tempCurDir = root;
            curDir = root;
        }

        /**
         * create a new file
         */
        public string createFile(string path, string name, char attr, bool isOpen = true) {//是否新建就打开
            if (attr == 'r') {
                return "Can't create read only file!\n";
            }

            //check things...dir..filename   path../../
            if (!locateDir(path)) {
                return "No such directory!\n";
            }
            
            //duplication of name
            string filename = "newfile";
            foreach (Item item in tempCurDir.items) {
                if (item.name.Equals(name)) {
                    duplicateFileCount++;
                }
            }
            if (duplicateFileCount > 0) {
                filename = filename + duplicateFileCount + ".txt";
            }
            else {
                filename = name;
                duplicateFileCount = 0;
            }

            Block b = disk.allocate();
            if (b != null) {
                File file = new File(filename, 'w', b);
                disk.blocks[file.sblock.num].content[0] = (byte)'#';//新建的文件第一个字节就是结束符，不知道这样设置合不合理
                tempCurDir.Add(file);
                //if (isOpen) {
                //    openedFiles.Add(file, "w");
                //}
                disk.getFAT().getTable()[b.num] = (byte)255;//更新fat
            }

            return "";
        }

        /**
         * 
         * oopen a file in current  directory
         * 
         */
        public bool openFile(string path, string filename, char mode) {
            if (!locateDir(path)) {
                return false;
            }
            foreach (Item item in tempCurDir.items) {
                if (item is File && filename == item.name) { //found the file
   
                    if (item.attribute == 'r' && mode == 'w') {//can't write read-only file
                        return false;
                    }
                    if (openedFiles.hasOpened(filename)) {
                        return true;
                    }

                    openedFiles.Add((File)item, mode+"");
                    return true;
                }
            }
            return false;
        }

        /**
         * read file 
         */
        public string readFile(string path, string filename, int length) {
            if (!openedFiles.hasOpened(filename)) {
                if (!this.openFile(path, filename, 'r')) {
                    return "Open file failed!!!!";
                }
            }

            OpenedFile file = openedFiles.getFile(filename);
            int disknum = file.read.dnum;
            int startByte = file.read.bnum;

            StringBuilder sb = new StringBuilder();
            bool flag = false;
            for (int i = 0; i < length; i++) {
                int num = i%64;
                flag = (i%64 == 0 && i!=0);//mark if it is the end of one block
                if(flag){
                    disknum = disk.getFAT().getTable()[disknum];
                    flag = false;
                }
                char ch = (char)disk.blocks[disknum].content[num];
                if (ch == '#') {//文件结束符
                    closeFile(filename);
                    return sb.ToString();
                }
                sb.Append(ch);
            }
            closeFile(filename);
            return sb.ToString();
        }

        /**
         *  
         * write file
         * //just >> 
         */
        public bool writeFile(string path, string filename, byte[] buf, int length) {
            if (!locateDir(path)) {
                return false;
            }
            if (!openedFiles.hasOpened(filename)) {
                if (!this.openFile(path,filename, 'w')) {
                    return false;
                }
            }
            OpenedFile file = openedFiles.getFile(filename);
            int disknum = file.write.dnum;
            int pos = file.write.bnum;

            //写文件，只能追加....
            for (int i = 0; i < length; i++){
                disk.blocks[disknum].content[pos] = buf[i];//the last character is always '#'
                file.increaseLength(1);
                pos++;
                if (pos == 64) {//have to allocate a new block
                    Block block = disk.allocate();
                    disk.getFAT().getTable()[disknum] = (byte)block.num;//next block
                    disknum = block.num;
                    pos = 0;
                    file.increaseLength(64);//increase file length property
                }
            }
            disk.blocks[disknum].content[pos] = (byte)'#'; //the eof
            //更新写指针
            file.write.bnum = pos;
            file.write.dnum = disknum;
            file.updateOffset(pos);  //update offset in the file
            closeFile(filename);
            return true;
        }

        /**
         *
         * close file
         * 
         */
        public bool closeFile(string filename) {
            if (!openedFiles.hasOpened(filename)) {
                return true;
            }
            OpenedFile file = openedFiles.getFile(filename);
            if (file.flag == 1) {//it is writing...
                int disknum = file.write.dnum;
                int pos = file.write.bnum;
                pos++;
                disk.blocks[disknum].content[pos] = (byte)'#';//apend '#' before closing
                file.write.bnum = pos;
            }
            openedFiles.remove(filename);
            return true;
        }

        /**
         *
         * delete file
         * 
         */
        public string deleteFile(string path, string filename) {
            if (!locateDir(path)) {
                return "No such directory!\n";
            }
            File file = null;
            foreach (Item item in tempCurDir.items) {
                if (item is File && item.name == filename) {
                    if (openedFiles.hasOpened(filename)) {//can't delete the opended file
                        return "can't delete the opended file!\n";
                    }
                    file = (File)item;
                    break;
                }
            }
            if (file == null) {//file doesn't exist...
                return "file doesn't exist...\n";
            }
            //remove from items
            tempCurDir.items.Remove(file);

            //remove from FAT
            int snum = file.sblock.num;
            disk.getFAT().freeSpace(snum);
            return "";
        }

        /**
         *显示文件内容..  打开则不能显示？
         */
        public string displayFile(string path, string filename) {
            if (openedFiles.hasOpened(filename)) {
                return "can't display the file which has been opened! I don't know why";
            }
            return readFile(path, filename, 9999);
        }

        /**
         * 改变文件属性
         */
        public bool changeAttr(string path, string filename, char attr) {
            //检查并定位到（如果存在）给定的路径
            if (!locateDir(path)) {
                return false;
            }
            //is already opened
            if (openedFiles.hasOpened(filename)) {
                return false;
            }
            File file = (File)tempCurDir.getItem(filename);
            if (file == null) {
                return false;
            }
            file.attribute = attr;
            return true;
        }

        //在这个project中很常用......
        //定位到目标路径 格式：/sasadsadas/sadas/... /
        private bool locateDir(string path) {
            if (!path.StartsWith("/")) {
                return false;
            }
            if (!path.Equals("/")) {
                tempCurDir = root.searchForDir(path);
            }
            else {
                tempCurDir = root;
            }
            if (tempCurDir == null) {
                return false;
            }
            return true;
        }
        /**
         * 建立目录 
         */
        public string md(string path, string dirname) {
 
            if (!locateDir(path)) {
                return "cannot create directory! No such directory";
            }
            
            //是否重名
            foreach (Item item in tempCurDir.items) {
                if (item.isDir() && item.name.Equals(dirname)) {
                    return "Directory exists";
                }
            }
            //分配空间，创建目录
            Block b = disk.allocate();
            if (b != null) {
                Directory directory = new Directory();
                directory.absolutePath = new StringBuilder("/");
                directory.name = dirname;
                directory.blocknum = b.num;

                //cd ..
                Directory parentNavigator = new Directory();
                parentNavigator.absolutePath = new StringBuilder(tempCurDir.absolutePath.ToString());
                parentNavigator.name = "..";
                directory.Add(parentNavigator);

                tempCurDir.Add(directory);
                disk.getFAT().getTable()[b.num] = (byte)255;//更新fat
                return "";
            }
            return "create directory failed!";
        }

        /**
         * 显示目录内容
         */
        public String dir(string d) {
            if (!d.Equals("/")) {
                if (!locateDir("/"+d + "/")) {
                    return "No such directory!";
                }
            }
            else {
                tempCurDir = root;
            }

            StringBuilder sb = new StringBuilder();
            foreach(Item item in tempCurDir.items){
                if (item.isDir()) {
                    sb.Append("d");
                }
                else {
                    sb.Append("-");
                }
                if (item.attribute == 'w') {
                    sb.Append("rwx rw- r--");
                }
                else if (item.attribute == 'r') {
                    sb.Append("r-x r-x r--");
                }
                else if (item.attribute == 'n') {
                    sb.Append("--- --- ---");
                }
                else {
                    sb.Append("r-x r-x r--");
                }
                sb.Append("     " + item.name + "        "+((item is File)?((File)item).length.ToString():"*"));
                sb.Append(" \r\n");
            }
            return sb.ToString();
        }

        /**
         * 删除空目录 
         */
        public string rd(string path, string name) {
            if (!locateDir(path+name+"/")) {
                return "No such directory!";
            }
            if (name.Contains("..")) {
                return "permission denied!";
            }
            //.......................
            if (tempCurDir.items.Count > 2) {
                return "The directory is not empty!";
            }

            locateDir(path);//定位到父目录

            Directory dir = null;
            foreach (Item item in tempCurDir.items) {
                if (item.isDir() && item.name == name) {
                    dir = (Directory)item;
                    break;
                }
            }
            if (dir == null) {//file doesn't exist...
                return "No such directory!";
            }
            //remove from items
            tempCurDir.items.Remove(dir);

            //remove from FAT
            int snum = dir.blocknum;
            disk.getFAT().freeSpace(snum);
            return "";
        }

        /// <summary>
        ///  cd命令......
        /// 
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>

        public string cd(string dir) {

            if (dir == "/" ) {
                curDir = root;
                return "";
            }

            if (dir.Contains("..")) {
                if (curDir.absolutePath.ToString() == "/") {
                    curDir = root;
                    return "";
                }
                locateDir(curDir.absolutePath.ToString());
                curDir = tempCurDir;
                return "";
            }

            if (!locateDir(dir)) {
                return "No such directory!!";
            }
            else {
                curDir = tempCurDir;
                return "";
            }
        }

        /**
         * item重命名 
         */
        public string rename(string path, string oldname, string newname) {

            if (!locateDir(path)) {
                return "file doesn't exist!";
            }
            if (tempCurDir.hasItem(oldname)) {
                return "filename has existed!";
            }
            Item item = tempCurDir.getItem(oldname);
            item.name = newname;
            //若是目录，其items及其items的items的absolutePath都要改...
            if (item is Directory) {
                renameAssociatedPath((Directory)item, oldname, newname);
            }
            return "";

        }

        private void renameAssociatedPath(Directory directory, string oldpath, string newpath) {
            if (directory.items.Count > 0) {
                foreach (Item i in directory.items) {
                    i.absolutePath.Replace(oldpath, newpath);
                    if (i is Directory) {
                        renameAssociatedPath((Directory)i, oldpath, newpath);
                    }
                }
            }
        }

        /**
         * 查找指定的文件，判断是否存在 
         */
        public bool exists(string path, string name) {
            Directory tempDir = tempCurDir;//先保存当前目录，以免调用locateDir后当前目录丢失
            if (!locateDir(path)) {
                return false;
            }
            if (tempCurDir.hasFile(name)) {
                return true;
            }
            tempCurDir = tempDir;
            return false;
        }


        internal Directory getRootDirectory() {
            return this.root;
        }
        internal Directory getCurDirectory() {
            return this.curDir;
        }
    }
}
