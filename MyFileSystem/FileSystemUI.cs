using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyFileSystem
{
    public partial class FileSystemUI : CCWin.CCSkinMain
    {

        private FileSystem fs;
        private Directory curDir;
        private int curPX;
        private int curPY;
        private int newFilesCount = 0;
        private int newFoldersCount = 0;

        public FileSystemUI(FileSystem fs)
        {
            this.fs = fs;
            this.curDir = fs.getCurDirectory();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.curPX = 0;
            this.curPY = 0;
            curPath.Enabled = false;
            refreshFilesArea();
        }

        private void materialLabel1_Click(object sender, EventArgs e) {

        }

        private void materialLabel2_Click(object sender, EventArgs e) {

        }

        private void terminalBtn_Click(object sender, EventArgs e) {
            CommandLine cmdLine = new CommandLine(fs);
            cmdLine.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e) {
            refreshFilesArea();
        }

        /*把当前目录项的内容绘制到显示区域中*/
        //这样效率可能很低....可是谁管呢，又不是应用于现实的场景....
        private void refreshFilesArea() {
            clearFileItemArea();
            int count = 0;
            foreach(Item item in curDir.items){
                ItemPanel itemPanel = new ItemPanel(item,fs);
                itemPanel.ContextMenuStrip = fileItemMenuStrip1;

                if (count > 5) {//换到下一行
                    count = 0;
                    curPY += itemPanel.Height + 6;
                    curPX = 0;
                }

                itemPanel.Location = new Point(curPX, curPY);
                PictureBox pic = null;
                Label nameTitle = null;
                //提取自定义的控件里pic和label
                foreach(Control c in itemPanel.Controls){
                    if (c is PictureBox) {
                        pic = ((PictureBox)c);
                        pic.MouseDoubleClick +=pic_MouseDoubleClick;
                        pic.Click +=pic_Click;
                    }
                    else if (c is Label) {
                        nameTitle = ((Label)c);
                    }
                }
                if (item is Directory) {
                    pic.Image = Properties.Resources.folder_forItemPanel;
                }
                else if (item.name.EndsWith(".txt")) {
                    pic.Image = Properties.Resources.txt_file_forItemPanel;
                }
                else {
                    pic.Image = Properties.Resources.filepic_forItemPanel;
                }
                nameTitle.Text = item.name;
                fileOperationArea.Controls.Add(itemPanel);
                curPX += itemPanel.Width + 6;
                count++;
            }
        }
        //UI下方区域显示的item详细信息
        private void pic_Click(object sender, EventArgs e) {
            PictureBox pic = (PictureBox)sender;
            ItemPanel itemPanel = (ItemPanel)pic.Parent;
            Item item = itemPanel.getItem();
            itemInfo_name.Text = item.name;

            //拼接item信息字符串
            StringBuilder sb = new StringBuilder();
            if (item is Directory) {
                sb.Append("文件夹");
                sb.Append("                 所在磁盘块号："+((Directory)item).blocknum);
                filePic.Image = Properties.Resources.folderType;
            }else if (item.name.Contains(".")) {
                string[] strs = item.name.Split('.');
                sb.Append(strs[strs.Length - 1] + "文件");
                sb.Append("         大小：" + ((File)item).length + "字节");
                sb.Append("                 文件起始盘块号：" + ((File)item).sblock.num);
                if (item.name.EndsWith(".txt")) {
                    filePic.Image = Properties.Resources.txt_file_forItemPanel;
                }
                else {
                    filePic.Image = Properties.Resources.unknownFileType;
                }
            }
            else {
                sb.Append("文件");
                sb.Append("         大小：" + ((File)item).length + "字节");
                sb.Append("           文件起始盘块号：" + ((File)item).sblock.num);
                filePic.Image = Properties.Resources.unknownFileType;
            }
            itemInfo.Text = sb.ToString();
            
        }

        //双击open item
        private void pic_MouseDoubleClick(object sender, MouseEventArgs e) {
            PictureBox pic = (PictureBox)sender;
            ItemPanel itemPanel = (ItemPanel)pic.Parent;
            Item item = itemPanel.getItem();
            openItem(item);
        }

       //清空控件和重置坐标指针
        private void clearFileItemArea() {
            fileOperationArea.Controls.Clear();
            curPX = 0;
            curPY = 0;
        }


        private void newFileToolStripMenuItem_Click(object sender, EventArgs e) {
            if (curDir.name == "/") {
                fs.createFile("/", "newfile" + newFilesCount + ".txt", 'w', false);
            }
            else {
                fs.createFile(curDir.absolutePath.ToString()+curDir.name+"/", "newfile" + newFilesCount + ".txt", 'w', false);
            }
           
            newFilesCount++;
            itemInfo.Text = "   " + curDir.items.Count + "个对象";
            refreshFilesArea();
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            if (curDir.name == "/") {
                fs.md("/", "newfolder" + newFoldersCount);
            }
            else {
                fs.md(curDir.absolutePath.ToString() + curDir.name + "/", "newfolder" + newFoldersCount);
            }
            newFoldersCount++;
            itemInfo.Text = "   " + curDir.items.Count + "个对象";
            refreshFilesArea();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e) {
            ToolStripMenuItem openMenuStrip = sender as ToolStripMenuItem;
            ItemPanel itemPanel =
               (ItemPanel)(openMenuStrip.GetCurrentParent() as ContextMenuStrip).SourceControl;
            Item item = itemPanel.getItem();
            openItem(item);
        }

        private void openItem(Item item) {
            if (item is File) {//打开的是文件
                Notepad notepad = new Notepad(item as File, fs);
                notepad.StartPosition = this.StartPosition;
                notepad.Show();
            }
            else {//打开的是目录
                if (item.name == "/") {
                    fs.cd("/");
                    curPath.Text = "/";
                }
                else if (item.name == "..") {
                    try {//为了防止系统崩掉，还是catch一下吧
                        fs.cd("..");
                        if (fs.getCurDirectory().name == "/") {
                            curPath.Text = "/";
                        }
                        else {
                            curPath.Text = fs.getCurDirectory().absolutePath.ToString() + fs.getCurDirectory().name + "/";
                        }
                    }
                    catch (Exception e) {
                        MessageBox.Show("error！！！");
                    }
                }
                else {
                    fs.cd(item.absolutePath.ToString() + item.name + "/");
                    curPath.Text = item.absolutePath.ToString() + item.name + "/";
                }
                curDir = fs.getCurDirectory();
                refreshFilesArea();
            }
        }

        private void fileItemMenuStrip1_Opening(object sender, CancelEventArgs e) {

        }

        private void fileOperationArea_Paint(object sender, PaintEventArgs e) {

        }

        private void curPath_Paint(object sender, PaintEventArgs e) {

        }

        private void skinPanel1_MouseHover(object sender, EventArgs e) {
            curPath.Enabled = true;
            this.AcceptButton = navigateBtn;
        }

        private void fileOperationArea_MouseClick(object sender, MouseEventArgs e) {
            curPath.Enabled =false;
            this.AcceptButton = null;
            filePic.Image = Properties.Resources.txt_files2;
            itemInfo.Text = "   " + curDir.items.Count + "个对象";
            itemInfo_name.Text = "";
        }

        private void curPath_TextChanged(object sender, EventArgs e) {

        }

        private void navigateBtn_Click(object sender, EventArgs e) {

            if (curPath.Enabled == false) {//路径输入框激活的时候才接收回车
                return;
            }

            string path = curPath.Text;
            if (!path.EndsWith("/")) {
                path += "/";
            }
            if (!path.StartsWith("/")) {
                MessageBox.Show("系统找不到指定路径!", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string result = fs.cd(path);
            if (result != "") {
                MessageBox.Show("系统找不到指定路径!", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            curDir = fs.getCurDirectory();
            refreshFilesArea();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem openMenuStrip = sender as ToolStripMenuItem;
            ItemPanel itemPanel =
               (ItemPanel)(openMenuStrip.GetCurrentParent() as ContextMenuStrip).SourceControl;
            Item item = itemPanel.getItem();

            Label nameLable = null;
            foreach (Control c in itemPanel.Controls) {
                if (c is Label) {
                    nameLable = (Label)c;
                }
            }

            TextBox nameInput = itemPanel.getNameInput();

            //设置样式
            nameInput.Location = new Point(nameLable.Location.X, nameLable.Location.Y);
            nameInput.Width = nameLable.Width - 5;
            nameInput.Height = nameLable.Height;
            nameInput.Text = nameLable.Text;

            //绑定事件
            nameInput.KeyPress += nameInput_KeyPress;
            nameInput.LostFocus += nameInput_LostFocus;

            nameInput.Show();
            nameInput.Focus();
            nameLable.SendToBack();
        }
        private void nameInput_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                renameItem(sender);
            }
        }
        private void nameInput_LostFocus(object sender, EventArgs e) {
            renameItem(sender);
        }

        private void renameItem(object sender) {
            TextBox nameInput = (TextBox)sender;

            Label nameLable = null;
            ItemPanel itemPanel = (ItemPanel)nameInput.Parent;
            foreach (Control c in itemPanel.Controls) {
                if (c is Label) {
                    nameLable = (Label)c;
                }
            }
            string path = getCurPath();
            string res = fs.rename(path,itemPanel.getItem().name,nameInput.Text);
            if (res == "") {
                nameLable.Text = nameInput.Text;
                nameInput.Hide();
            }
            else {
                MessageBox.Show(res);
                nameInput.Hide();
            }

        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e) {
            ToolStripMenuItem openMenuStrip = sender as ToolStripMenuItem;
            ItemPanel itemPanel =
               (ItemPanel)(openMenuStrip.GetCurrentParent() as ContextMenuStrip).SourceControl;
            Item item = itemPanel.getItem();

            string path = getCurPath();
            string res = "";
            if (item is File) {
                res = fs.deleteFile(path, item.name);
            }
            else {
                res = fs.rd(path, item.name);
            }
            if (res != "") {
                MessageBox.Show(res);
                return;
            }
            itemInfo_name.Text = "";
            itemInfo.Text = "   " + curDir.items.Count + "个对象";
            refreshFilesArea();
        }

        private string getCurPath() {
            string path = "";
            if (curDir.name == "/") {
                path = "/";
            }
            else {
                path = curDir.absolutePath.ToString() + curDir.name + "/";
            }
            return path;
        }

        private void FileSystemUI_FormClosed(object sender, FormClosedEventArgs e) {
            BinaryFormatter bformatter = new BinaryFormatter();
            Stream outStream = new FileStream("mydisk.dat", FileMode.Create);
            bformatter.Serialize(outStream, fs);
            outStream.Close();
        }

    }
}
