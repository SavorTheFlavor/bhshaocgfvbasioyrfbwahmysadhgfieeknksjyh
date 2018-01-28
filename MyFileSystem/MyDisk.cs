using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileSystem
{
    [Serializable]
    class MyDisk {

        public Block[] blocks;
        FAT fat;

        public MyDisk() {
            blocks = new Block[128];//只是引用...........
            for(int i = 0;i<blocks.Length;i++){
                blocks[i] = new Block();
            }
            fat = new FAT(blocks[0], blocks[1]);
        }

        public Block allocate() {
            //search from the FAT for a spare space
            byte[] table = fat.getTable();
            for (int i = 2; i < table.Length; i++) {
                if (table[i] == (byte)0) {
                    blocks[i].num = i;
                    table[i] = (byte)255;
                    fat.updateBlock();
                    return blocks[i];
                }
            }
            return null;
        }


        public FAT getFAT() {
            return this.fat;
        }

    }
}
