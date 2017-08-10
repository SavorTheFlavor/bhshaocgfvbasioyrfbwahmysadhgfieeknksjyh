using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileSystem
{
    class MyDisk
    {

        Block[] blocks ;

        MyDisk()
        {
            blocks = new Block[128];
            FAT fat = new FAT(blocks[0], blocks[1]);
            
        }


        class Block
        {
           public byte[] content = new byte[64];
        }
        class FAT {
            private byte[] table;
            private Block b1;
            private Block b2;
            public FAT(Block b1, Block b2) {
                table = new byte[b1.content.Length*2];
                this.b1 = b1;//disk[0]
                this.b2 = b2;//disk[1]
                blockUpdateToTable();
            }

            public byte[] getTable() {
                blockUpdateToTable();
                return table;
            }
            //把文件分配表的内容更新到块里
            public void updateBlock() {
                for (int i = 0; i < this.b1.content.Length; i++) {
                    b1.content[i] = this.table[i];
                }
                for (int i = this.b1.content.Length; i < this.b1.content.Length * 2; i++) {
                    b2.content[i - this.b1.content.Length] = this.table[i];
                }
            }

            private void blockUpdateToTable() {
                for (int i=0; i < this.b1.content.Length; i++) {
                    this.table[i] = b1.content[i];
                }
                for (int i = this.b1.content.Length; i < this.b1.content.Length*2; i++) {
                    this.table[i] = b2.content[i];
                }
            }
        }
    }
}
