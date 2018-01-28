namespace MyFileSystem {
    partial class Notepad {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.saveBtn = new CCWin.SkinControl.SkinButton();
            this.exitBtn = new CCWin.SkinControl.SkinButton();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.Transparent;
            this.saveBtn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.saveBtn.DownBack = null;
            this.saveBtn.Location = new System.Drawing.Point(22, 31);
            this.saveBtn.MouseBack = null;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.NormlBack = null;
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.exitBtn.DownBack = null;
            this.exitBtn.Location = new System.Drawing.Point(114, 31);
            this.exitBtn.MouseBack = null;
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.NormlBack = null;
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 2;
            this.exitBtn.Text = "exit";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.textBox.Location = new System.Drawing.Point(22, 60);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(715, 331);
            this.textBox.TabIndex = 0;
            this.textBox.Text = ".........";
            // 
            // Notepad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 408);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.saveBtn);
            this.Name = "Notepad";
            this.Text = "Notepad";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Notepad_FormClosed);
            this.Load += new System.EventHandler(this.Notepad_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton saveBtn;
        private CCWin.SkinControl.SkinButton exitBtn;
        private System.Windows.Forms.RichTextBox textBox;
    }
}