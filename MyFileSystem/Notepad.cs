using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFileSystem {
    public partial class Notepad : CCWin.CCSkinMain {

        private File file;
        private FileSystem fs;
        //用于写文件的缓存
        private byte[] buffer;

        private int tempContentLength = -9999;

        public Notepad(File file, FileSystem fs) {
            this.file = file;
            this.fs = fs;
            this.buffer = new byte[0];
            InitializeComponent();
        }

        private void Notepad_Load(object sender, EventArgs e) {
            string content = fs.readFile(this.file.absolutePath.ToString(), this.file.name, 9999);
            this.textBox.Text = content;
            this.textBox.Font = new Font(this.textBox.Font.Name, 12);
            this.textBox.Select(content.Length, 0);
            this.tempContentLength = content.Length;
        }

        private void saveBtn_Click(object sender, EventArgs e) {
            string content = this.textBox.Text;
            if (tempContentLength > 0) {//if it is appending writing，needed to be subtract previous string
                if (tempContentLength > content.Length) {
                    MessageBox.Show("本系统暂不支持文本编辑，只能追加....");
                    return;
                }
                content = content.Substring(tempContentLength);
            }
            buffer= System.Text.Encoding.Default.GetBytes(content);
        }

        //按退出的时候再把缓冲的内容写到文件里
        private void exitBtn_Click(object sender, EventArgs e) {
            //flush.....
            if (this.buffer.Length > 0) {
                fs.writeFile(this.file.absolutePath.ToString(), this.file.name, this.buffer, this.buffer.Length);
            }
            this.Close();
        }

        //会引起stackOverflow...........
        private void Notepad_FormClosed(object sender, FormClosedEventArgs e) {
            //flush.....
            //if (this.buffer.Length > 0) {
            //    fs.writeFile(this.file.absolutePath.ToString(), this.file.name, this.buffer, this.buffer.Length);
            //}
            //this.Close();
        }
    }
}
