using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFileSystem {
    public partial class ItemPanel : UserControl {

        private Item item;
        private FileSystem fs;

        public ItemPanel(Item item, FileSystem fs) {
            this.item = item;
            this.fs = fs;
            InitializeComponent();
        }

        private void Pic_MouseMove(object sender, MouseEventArgs e) {
            this.BackColor = Color.AliceBlue;
        }

        private void Pic_MouseClick(object sender, MouseEventArgs e) {
            this.BackColor = System.Drawing.Color.LightSkyBlue;
        }

        private void ItemPanel_MouseLeave(object sender, EventArgs e) {
            this.BackColor = System.Drawing.Color.White;
        }

        public Item getItem() {
            return this.item;
        }


        private void ItemPanel_Load(object sender, EventArgs e) {
            nameInput.Hide();
        }

        public TextBox getNameInput() {
            return nameInput;
        }
    }
}
