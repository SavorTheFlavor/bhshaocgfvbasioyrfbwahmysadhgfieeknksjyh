using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileSystem {
    [Serializable]
    public class Block {
        public byte[] content;
        public int num;//number in disk
        public Block() {
            content = new byte[64];
            for (int i = 0; i < content.Length; i++) {
                content[i] = (byte)0;
            }
        }
        public bool equals(int num){
            int val = BitConverter.ToInt32(this.content, 0);
            return val == num;
        }
    }
}
