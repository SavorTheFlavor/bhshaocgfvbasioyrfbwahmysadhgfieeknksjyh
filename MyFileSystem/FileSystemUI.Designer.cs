namespace MyFileSystem
{
    partial class FileSystemUI
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.curPath = new System.Windows.Forms.TextBox();
            this.navigateBtn = new CCWin.SkinControl.SkinButton();
            this.pathIcon = new CCWin.SkinControl.SkinPictureBox();
            this.fileOperationArea = new CCWin.SkinControl.SkinPanel();
            this.fileAreaMenuStrip = new CCWin.SkinControl.SkinContextMenuStrip();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.fileInfoArea = new CCWin.SkinControl.SkinPanel();
            this.filePic = new System.Windows.Forms.PictureBox();
            this.itemInfo = new System.Windows.Forms.TextBox();
            this.fileItemMenuStrip1 = new CCWin.SkinControl.SkinContextMenuStrip();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminalBtn = new System.Windows.Forms.Button();
            this.itemInfo_name = new System.Windows.Forms.Label();
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pathIcon)).BeginInit();
            this.fileAreaMenuStrip.SuspendLayout();
            this.fileInfoArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePic)).BeginInit();
            this.fileItemMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.White;
            this.skinPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinPanel1.Controls.Add(this.curPath);
            this.skinPanel1.Controls.Add(this.navigateBtn);
            this.skinPanel1.Controls.Add(this.pathIcon);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(43, 45);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(578, 62);
            this.skinPanel1.TabIndex = 4;
            this.skinPanel1.MouseHover += new System.EventHandler(this.skinPanel1_MouseHover);
            // 
            // curPath
            // 
            this.curPath.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.curPath.Location = new System.Drawing.Point(74, 21);
            this.curPath.Name = "curPath";
            this.curPath.Size = new System.Drawing.Size(397, 23);
            this.curPath.TabIndex = 6;
            this.curPath.Text = "/";
            this.curPath.TextChanged += new System.EventHandler(this.curPath_TextChanged);
            // 
            // navigateBtn
            // 
            this.navigateBtn.BackColor = System.Drawing.Color.Transparent;
            this.navigateBtn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.navigateBtn.DownBack = null;
            this.navigateBtn.Location = new System.Drawing.Point(488, 14);
            this.navigateBtn.MouseBack = null;
            this.navigateBtn.Name = "navigateBtn";
            this.navigateBtn.NormlBack = null;
            this.navigateBtn.Size = new System.Drawing.Size(75, 32);
            this.navigateBtn.TabIndex = 5;
            this.navigateBtn.Text = ">>>";
            this.navigateBtn.UseVisualStyleBackColor = false;
            this.navigateBtn.Click += new System.EventHandler(this.navigateBtn_Click);
            // 
            // pathIcon
            // 
            this.pathIcon.BackColor = System.Drawing.Color.Transparent;
            this.pathIcon.Image = global::MyFileSystem.Properties.Resources.pathIcon1;
            this.pathIcon.Location = new System.Drawing.Point(25, 14);
            this.pathIcon.Name = "pathIcon";
            this.pathIcon.Size = new System.Drawing.Size(43, 32);
            this.pathIcon.TabIndex = 3;
            this.pathIcon.TabStop = false;
            // 
            // fileOperationArea
            // 
            this.fileOperationArea.BackColor = System.Drawing.SystemColors.Window;
            this.fileOperationArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fileOperationArea.ContextMenuStrip = this.fileAreaMenuStrip;
            this.fileOperationArea.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.fileOperationArea.DownBack = null;
            this.fileOperationArea.Location = new System.Drawing.Point(43, 138);
            this.fileOperationArea.MouseBack = null;
            this.fileOperationArea.Name = "fileOperationArea";
            this.fileOperationArea.NormlBack = null;
            this.fileOperationArea.Size = new System.Drawing.Size(721, 375);
            this.fileOperationArea.TabIndex = 5;
            this.fileOperationArea.Paint += new System.Windows.Forms.PaintEventHandler(this.fileOperationArea_Paint);
            this.fileOperationArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fileOperationArea_MouseClick);
            // 
            // fileAreaMenuStrip
            // 
            this.fileAreaMenuStrip.Arrow = System.Drawing.Color.Black;
            this.fileAreaMenuStrip.Back = System.Drawing.Color.White;
            this.fileAreaMenuStrip.BackRadius = 4;
            this.fileAreaMenuStrip.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.fileAreaMenuStrip.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.fileAreaMenuStrip.Fore = System.Drawing.Color.Black;
            this.fileAreaMenuStrip.HoverFore = System.Drawing.Color.White;
            this.fileAreaMenuStrip.ItemAnamorphosis = true;
            this.fileAreaMenuStrip.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.fileAreaMenuStrip.ItemBorderShow = true;
            this.fileAreaMenuStrip.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.fileAreaMenuStrip.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.fileAreaMenuStrip.ItemRadius = 4;
            this.fileAreaMenuStrip.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.fileAreaMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.newFolderToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.fileAreaMenuStrip.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.fileAreaMenuStrip.Name = "fileAreaMenuStrip";
            this.fileAreaMenuStrip.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.fileAreaMenuStrip.Size = new System.Drawing.Size(139, 70);
            this.fileAreaMenuStrip.SkinAllColor = true;
            this.fileAreaMenuStrip.TitleAnamorphosis = true;
            this.fileAreaMenuStrip.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.fileAreaMenuStrip.TitleRadius = 4;
            this.fileAreaMenuStrip.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.newFileToolStripMenuItem.Text = "new file";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.newFolderToolStripMenuItem.Text = "new folder";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.refreshToolStripMenuItem.Text = "refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.Gray;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(2, 503);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(798, 10);
            this.skinLine1.TabIndex = 0;
            this.skinLine1.Text = "skinLine1";
            // 
            // fileInfoArea
            // 
            this.fileInfoArea.BackColor = System.Drawing.Color.Transparent;
            this.fileInfoArea.Controls.Add(this.itemInfo_name);
            this.fileInfoArea.Controls.Add(this.filePic);
            this.fileInfoArea.Controls.Add(this.itemInfo);
            this.fileInfoArea.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.fileInfoArea.DownBack = null;
            this.fileInfoArea.Location = new System.Drawing.Point(7, 516);
            this.fileInfoArea.MouseBack = null;
            this.fileInfoArea.Name = "fileInfoArea";
            this.fileInfoArea.NormlBack = null;
            this.fileInfoArea.Size = new System.Drawing.Size(793, 52);
            this.fileInfoArea.TabIndex = 6;
            // 
            // filePic
            // 
            this.filePic.Image = global::MyFileSystem.Properties.Resources.txt_files2;
            this.filePic.Location = new System.Drawing.Point(23, 0);
            this.filePic.Name = "filePic";
            this.filePic.Size = new System.Drawing.Size(50, 49);
            this.filePic.TabIndex = 1;
            this.filePic.TabStop = false;
            // 
            // itemInfo
            // 
            this.itemInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.itemInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemInfo.Enabled = false;
            this.itemInfo.Location = new System.Drawing.Point(91, 25);
            this.itemInfo.Multiline = true;
            this.itemInfo.Name = "itemInfo";
            this.itemInfo.Size = new System.Drawing.Size(699, 27);
            this.itemInfo.TabIndex = 0;
            this.itemInfo.Text = "...................";
            // 
            // fileItemMenuStrip1
            // 
            this.fileItemMenuStrip1.Arrow = System.Drawing.Color.Black;
            this.fileItemMenuStrip1.Back = System.Drawing.Color.White;
            this.fileItemMenuStrip1.BackRadius = 4;
            this.fileItemMenuStrip1.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.fileItemMenuStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.fileItemMenuStrip1.Fore = System.Drawing.Color.Black;
            this.fileItemMenuStrip1.HoverFore = System.Drawing.Color.White;
            this.fileItemMenuStrip1.ItemAnamorphosis = true;
            this.fileItemMenuStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.fileItemMenuStrip1.ItemBorderShow = true;
            this.fileItemMenuStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.fileItemMenuStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.fileItemMenuStrip1.ItemRadius = 4;
            this.fileItemMenuStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.fileItemMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.deleteToolStripMenuItem1,
            this.renameToolStripMenuItem});
            this.fileItemMenuStrip1.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.fileItemMenuStrip1.Name = "fileItemMenuStrip1";
            this.fileItemMenuStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.fileItemMenuStrip1.Size = new System.Drawing.Size(121, 70);
            this.fileItemMenuStrip1.SkinAllColor = true;
            this.fileItemMenuStrip1.TitleAnamorphosis = true;
            this.fileItemMenuStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.fileItemMenuStrip1.TitleRadius = 4;
            this.fileItemMenuStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.fileItemMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.fileItemMenuStrip1_Opening);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.openToolStripMenuItem1.Text = "open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem1.Text = "delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.renameToolStripMenuItem.Text = "rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // terminalBtn
            // 
            this.terminalBtn.Image = global::MyFileSystem.Properties.Resources.terminal2;
            this.terminalBtn.Location = new System.Drawing.Point(689, 45);
            this.terminalBtn.Name = "terminalBtn";
            this.terminalBtn.Size = new System.Drawing.Size(75, 55);
            this.terminalBtn.TabIndex = 8;
            this.terminalBtn.Text = "terminal";
            this.terminalBtn.UseVisualStyleBackColor = true;
            this.terminalBtn.Click += new System.EventHandler(this.terminalBtn_Click);
            // 
            // itemInfo_name
            // 
            this.itemInfo_name.AutoSize = true;
            this.itemInfo_name.Location = new System.Drawing.Point(89, 7);
            this.itemInfo_name.Name = "itemInfo_name";
            this.itemInfo_name.Size = new System.Drawing.Size(35, 12);
            this.itemInfo_name.TabIndex = 2;
            this.itemInfo_name.Text = ".....";
            // 
            // FileSystemUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(828, 575);
            this.Controls.Add(this.terminalBtn);
            this.Controls.Add(this.fileInfoArea);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.fileOperationArea);
            this.Controls.Add(this.skinPanel1);
            this.Name = "FileSystemUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "file system";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileSystemUI_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pathIcon)).EndInit();
            this.fileAreaMenuStrip.ResumeLayout(false);
            this.fileInfoArea.ResumeLayout(false);
            this.fileInfoArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePic)).EndInit();
            this.fileItemMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPictureBox pathIcon;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinButton navigateBtn;
        private CCWin.SkinControl.SkinPanel fileOperationArea;
        private CCWin.SkinControl.SkinLine skinLine1;
        private CCWin.SkinControl.SkinPanel fileInfoArea;
        private System.Windows.Forms.PictureBox filePic;
        private System.Windows.Forms.TextBox itemInfo;
        private System.Windows.Forms.Button terminalBtn;
        private CCWin.SkinControl.SkinContextMenuStrip fileAreaMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        private CCWin.SkinControl.SkinContextMenuStrip fileItemMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.TextBox curPath;
        private System.Windows.Forms.Label itemInfo_name;

    }
}

