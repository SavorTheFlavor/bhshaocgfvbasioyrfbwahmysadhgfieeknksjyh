using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFileSystem {
    [Serializable]
    public abstract class Item {
        public string name;
        public char attribute;
        public int index;

        public StringBuilder absolutePath = new StringBuilder();//当前目录的绝对路径名,
                                                                                            //just path, name excluded


        public Item(string name,char attribute,int bnum) {
            this.name = name;
            this.attribute = attribute;
            this.index = bnum;
            absolutePath.Append("/");//所有文件都在根目录下
        }

        public Item() {
            this.name = "$";//空目录项
            absolutePath.Append("/");
        }

        public abstract bool isDir();
    }
}
