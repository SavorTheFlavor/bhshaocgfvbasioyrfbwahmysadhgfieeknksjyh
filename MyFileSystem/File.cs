using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileSystem {
    [Serializable]
    public class File : Item{ 
        public int blength;//   /block num
        public int boffset;// offset in a block
        public Block sblock;
        public int length;//length in bytes......
        public File(string name,char attribute,Block b):base(name,attribute,b.num) {
            this.sblock = b;
            this.blength = 0;
            this.boffset = 0;
            this.length = 0;
        }


        public override bool isDir() {
            return false;
        }
    }
}
