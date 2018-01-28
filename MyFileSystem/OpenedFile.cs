using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileSystem {
    [Serializable]
    class OpenedFile {
        //for convenience...I don't encapsulate these fileds
        public string name;//absolute file path name
        public char attribute;
        public int number;// the begining of disk block num
        public int length;//file length /byte
        public int flag;// 0 read, 1 write
        public Pointer read;
        public Pointer write;
        private File file;
        public OpenedFile(File file, string mode, FAT fat) {

            this.name = file.name;
            this.attribute = file.attribute;
            this.number = file.sblock.num;
            this.length = file.blength * 64 + file.boffset;
            this.file = file;
            read = new Pointer();
            write = new Pointer();
            //先把读写指针都初始化一下.....
            this.write.dnum = file.sblock.num;
            this.write.bnum = 0;
            this.read.dnum = file.sblock.num;
            this.read.bnum = 0;
            if (mode.Equals("w")) {//new and write
                this.flag = 1;
                this.write.dnum = fat.searchForTheEnd(file.sblock.num);//寻找文件结束块
                this.write.bnum = file.boffset;
            }
            else {//read
                this.flag = 0;
            }
            //else if (mode.Equals("w+")) {//write append
            //    this.flag = 1;
            //    this.write.dnum = fat.searchForTheEnd(file.sblock.num);//寻找文件结束块
            //    this.write.bnum = file.boffset;
            //}


        }

        public class Pointer {
            public int dnum;
            public int bnum;
        }

        internal void increaseLength(int num) {
            if (num < 64) {
                file.length += num;
                file.boffset += num;
                file.boffset %= 64;
            }
            else {
                file.blength += num / 64;
                file.boffset = num%64;
            }   
        }

        internal void updateOffset(int pos) {
            file.boffset = pos;
        }
    }
}
