namespace MyFileSystem {
    partial class ViTextArea {
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
            this.ViTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ViTextBox
            // 
            this.ViTextBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.ViTextBox.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ViTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ViTextBox.Location = new System.Drawing.Point(0, 0);
            this.ViTextBox.Name = "ViTextBox";
            this.ViTextBox.Size = new System.Drawing.Size(646, 347);
            this.ViTextBox.TabIndex = 0;
            this.ViTextBox.Text = "";
            this.ViTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.ViTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ViTextBox_KeyPress);
            // 
            // ViTextArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 348);
            this.Controls.Add(this.ViTextBox);
            this.Name = "ViTextArea";
            this.Text = "ViTextArea";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViTextArea_FormClosed);
            this.Load += new System.EventHandler(this.ViTextArea_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ViTextBox;
    }
}