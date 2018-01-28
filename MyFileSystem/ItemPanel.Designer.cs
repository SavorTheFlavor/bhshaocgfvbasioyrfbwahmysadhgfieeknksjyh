namespace MyFileSystem {
    partial class ItemPanel {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.title = new System.Windows.Forms.Label();
            this.Pic = new System.Windows.Forms.PictureBox();
            this.nameInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(3, 98);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(110, 12);
            this.title.TabIndex = 3;
            this.title.Text = "....";
            this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Pic
            // 
            this.Pic.Location = new System.Drawing.Point(22, 17);
            this.Pic.Name = "Pic";
            this.Pic.Size = new System.Drawing.Size(68, 78);
            this.Pic.TabIndex = 2;
            this.Pic.TabStop = false;
            this.Pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseClick);
            this.Pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseMove);
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(5, 97);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(100, 21);
            this.nameInput.TabIndex = 4;
            // 
            // ItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.title);
            this.Controls.Add(this.Pic);
            this.Name = "ItemPanel";
            this.Size = new System.Drawing.Size(116, 121);
            this.Load += new System.EventHandler(this.ItemPanel_Load);
            this.MouseLeave += new System.EventHandler(this.ItemPanel_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pic;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox nameInput;

    }
}
