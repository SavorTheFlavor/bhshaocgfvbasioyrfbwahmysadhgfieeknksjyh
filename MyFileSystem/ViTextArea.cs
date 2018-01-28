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
    public partial class ViTextArea : Form {

        private CommandLine cmd;
        private FileSystem fs;
        private string filename;
        private string filepath;
        private bool appended;

        private int tempContentLength = -9999;

        public ViTextArea(FileSystem fs, CommandLine cmd, string filepath, string filename, bool appended) {
            
            InitializeComponent();
            this.fs = fs;
            this.cmd = cmd;
            this.filename = filename;
            this.filepath = filepath;
            this.appended = appended;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void ViTextArea_Load(object sender, EventArgs e) {
            if (appended) {
                string content = fs.readFile(filepath, filename, 9999);
                this.ViTextBox.Text = content;
                this.ViTextBox.Select(content.Length, 0);
                this.tempContentLength = content.Length;
            }
        }

        private void ViTextArea_FormClosed(object sender, FormClosedEventArgs e) {
        }

        private void ViTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Space) {
                string content = this.ViTextBox.Text;
                if (tempContentLength > 0) {//if it is appending writing，needed to be subtract previous string
                    content = content.Substring(tempContentLength);
                }

                byte[] buf = System.Text.Encoding.Default.GetBytes(content);
                bool ff = fs.writeFile(filepath, filename, buf, buf.Length);
                fs.closeFile(filename);
                this.Close();
                this.cmd.Show();
                this.cmd.curTextLine.Focus();
            }
        }
    }
}
