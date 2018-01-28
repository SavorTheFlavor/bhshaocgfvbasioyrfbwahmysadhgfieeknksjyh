using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileSystem {
    [Serializable]
           class FAT {
            private byte[] table;
            private Block b1;
            private Block b2;
            public FAT(Block b1, Block b2) {
                table = new byte[b1.content.Length*2];
                this.b1 = b1;//disk[0]
                this.b2 = b2;//disk[1]
                blockUpdateToTable();
                table[0] = table[1] = (byte)222;//fat区域
            }

            public byte[] getTable() {
                return table;
            }
            /**
             * 根据起始块寻找结束块
             */
            public int searchForTheEnd(int dnum) {
                if (table[dnum] == 255 || table[dnum] > 128) {//文件正常结束或磁盘块损坏都直接返回
                    return dnum;
                }
                return searchForTheEnd(table[dnum]);
            }
            //remove a file allocation info 
            public void freeSpace(int dnum) {
                if (table[dnum] == 255 || table[dnum] > 128) {
                    table[dnum] = 0;//顺带修复功能？
                    return;
                }
                freeSpace(table[dnum]);
                table[dnum] = 0; 
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

             /**
              * 
              *这方法........... 
              */
            private void blockUpdateToTable() {
                for (int i=0; i < this.b1.content.Length; i++) {
                    this.table[i] = b1.content[i];
                }
                for (int i = this.b1.content.Length; i < this.b1.content.Length*2; i++) {
                    this.table[i] = b2.content[i - this.b1.content.Length];
                }
            }
        }
}
