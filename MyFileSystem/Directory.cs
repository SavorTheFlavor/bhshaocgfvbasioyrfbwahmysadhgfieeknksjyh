using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFileSystem {
    [Serializable]
    public class Directory : Item{
        
        public List<Item> items;//目录项，只能放 8 个？

        public int blocknum;//所在磁盘块

        public Directory(string name,char attribute,int bnum) :base(name,attribute,bnum){//语法啊....
            items = new List<Item>(8);
        }

        public Directory() : base(){
            items = new List<Item>(8);
            this.name = "/";
        }

        /**
         * 
         *寻找给定的目录 
         */
        public Directory searchForDir(string path) {
            string[] tempaths = path.Split('/');//     /asdas/ length=3
            if (tempaths.Length < 3) {
                return null;
            }
            string[] paths = new string[tempaths.Length - 2]; 
            for (int i = 1; i < tempaths.Length - 1; i++) {
                paths[i - 1] = tempaths[i];
            }
            return searchForDir(paths,items,0);
        }

        private Directory searchForDir(string[] paths, List<Item> items, int level) {
            if (items.Count == 0 || !hasDir(items)) {
                return null;
            }
            foreach (Item item in items) {
                if (item.isDir() && (level == paths.Length - 1) && (item.name == paths[level])){
                    return (Directory)item;
                }
                if (item.isDir() && (level < paths.Length - 1)) {//递归下去
                    Directory tDir = searchForDir(paths, ((Directory)item).items, level + 1);
                    if (tDir == null) {//此处的bug已修复.....
                        continue;
                    }
                    return tDir;
                }
            }
            return null;
        }
        //是否有dir
        private bool hasDir(List<Item> items) {
            foreach(Item item in items){
                if (item.isDir()) {
                    return true;
                }
            }
            return false;
        }

        //是否已有file
        public bool hasFile(String name) {
            foreach (Item item in items) {
                if (name == item.name && item is File) {//c#里 == 是比较字符串是否相等
                    return true;
                }
            }
            return false;
        }
        internal bool hasItem(string oldname) {
            foreach (Item item in items) {
                if (name == item.name) {
                    return true;
                }
            }
            return false;
        }

        /**
         *添加目录项，带上绝对路径 
         */
        public bool Add(Item item) {
            //if (this.items.Count > 8) { //还是不要有这种限制了吧
            //    return false;
            //}
            if (!this.name.Equals("/")) {
                item.absolutePath.Remove(0,item.absolutePath.Length).Append(this.absolutePath+this.name + "/");
            }
            items.Add(item);
            return true;
        }
        /**
         * 从目录项中获取item 
         */
        public Item getItem(string name) {
            foreach (Item item in items) {
                if (name.Equals(item.name)) {
                    return item;
                }
            }
            return null;
        }

        public override bool isDir() {
            return true;
        }
    }
}
