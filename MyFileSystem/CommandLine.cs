using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFileSystem {
    /// <summary>
    /// MyCommandLine
    /// version: 1.0.0
    /// </summary>
    public partial class CommandLine : Form {

        private Label curUserLabel;
        public TextBox curTextLine;
        private int offsetY = 22;
        private int msgoffset = 4;
        private bool hasMsg = false;
      
        //当前命令行控件的坐标
        private int curLX;
        private int curLY;
        private int curTX;
        private int curTY;

        private FileSystem fs;
        private Directory root;
        private Directory curDir;


        public CommandLine(FileSystem fs) {
            InitializeComponent();
            this.fs = fs;
            root = fs.getRootDirectory();
            curDir = fs.getCurDirectory();
        }


        private void label1_Click(object sender, EventArgs e) {

        }

        private void CommandLine_Load(object sender, EventArgs e) {
            curUserLabel = userLabel;
            curTextLine = textLine;
            curLX = curUserLabel.Location.X;
            curLY = curUserLabel.Location.Y;
            curTX = curTextLine.Location.X;
            curTY = curTextLine.Location.Y;
            textLine.Focus();
            curDir = fs.getCurDirectory();
        }


        private void removeFirstLine() {
            throw new NotImplementedException();
        }
        //按下回车键时，读取textbox内容，解析执行命令，生成下一行控件
        private void textLine_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                curTextLine.Enabled = false;
                string command = curTextLine.Text;
                if (command.Trim() == "") {
                    nextLine();
                    return;
                }
                string result = executeCommand(command);
                if (result != null && result.Trim() != "") {
                    hasMsg = true;
                    addMessage(result);
                }
                nextLine();
            }
        }

        private string executeCommand(string command) {
            string result = execute(command);
            return result;
        }

        private string execute(string command) {
            string[] cmdAndParam = command.Split(' ');
            string cmd = cmdAndParam[0];
            //解析命令//
            switch (cmd) {
                case "ll":
                case "ls":
                case "dir":
                    if (cmdAndParam.Length < 2) {
                        if (curDir.name == "/") {
                            return fs.dir("/");
                        }
                        return fs.dir(fs.getCurDirectory().absolutePath.ToString().Substring(1)+fs.getCurDirectory().name);
                    }
                    else {
                        return fs.dir(cmdAndParam[1]);
                    }
                    //cd命令.....
                    //TODO
                case "cd":
                    if (cmdAndParam.Length < 2) {
                        return "";
                    }
                    string r = "";
                    string fullPath = "";
                    if (cmdAndParam[1] == "/") {
                        r = fs.cd("/");
                        fullPath = "/";
                    }
                    else {
                        string[] nap221 = parseFullyQualifiedName(cmdAndParam[1]);
                        fullPath = nap221[1] + nap221[0] + "/";
                        r = fs.cd(fullPath);
                    }
                    if (r == "") {//cd success...then change the path in cmd...
                        curDir = fs.getCurDirectory();
                        if (curDir.name == "/") {
                            curUserLabel.Text = "root:/$";
                        }
                        else {
                            if (fullPath.Contains("..")) {
                                fullPath = curDir.absolutePath.ToString()+curDir.name+"/";
                            }
                            curUserLabel.Text = "root:" + fullPath + "$2";
                        }
                        int tWidth = (int)getContentSize(curUserLabel.Text).Width;
                        curTX = tWidth + 7;
                        curUserLabel.Width = tWidth;
                    }
                    return r;
                                            //创建文件
                case "create_file":
                case "touch":
                    //解析绝对路径
                    //todo
                    // parseFullyQualifiedName(cmdAndParam[i]): string[]  //string[0]:filename, stirng[1]:path--curDir?curDir.absolutePath.ToString()
                    string res = "";
                    for (int i = 1; i < cmdAndParam.Length; i++) {
                        string[] nap = parseFullyQualifiedName(cmdAndParam[i]);
                        res += fs.createFile(nap[1], nap[0], 'w');
                        //fs.closeFile(nap[0]); //(sigh............
                    }
                    return res;
                                        //低仿Vi编辑器
                case "vi":
                    return writeWithVi(cmd, cmdAndParam);
                                    //cat命令
                case "cat":
                    string[] nap3 = parseFullyQualifiedName(cmdAndParam[1]);
                    return fs.readFile(nap3[1], nap3[0], 9999);
                                      
                    //只能删文件的rm命令
                case "rm":
                case "delete_file":
                    string res2 = "";
                    for (int i = 1; i < cmdAndParam.Length; i++) {
                        string[] nap4 = parseFullyQualifiedName(cmdAndParam[i]);
                        res2 += fs.deleteFile(nap4[1], nap4[0]);
                    }
                    return res2;

                                    //chmod命令超级低仿........a little boring...
                case "chmod":
                    return chmod(cmd,cmdAndParam);
                                    
                            //mkdir....
                case "md":
                case "mkdir":
                    if (cmdAndParam[1] == "/") {
                        return "Directory exists!";
                    }
                    if (cmdAndParam[1].IndexOf("/") == -1) {//不包含'/'，则认为是在当前目录下创建s
                        Directory d = fs.getCurDirectory();
                        if (d.name == "/") {
                            return fs.md("/", cmdAndParam[1]);
                        }
                        else {
                            return fs.md(d.absolutePath + d.name + "/", cmdAndParam[1]);
                        }
                    }
                    string[] nap6 = parseFullyQualifiedName(cmdAndParam[1]);
                    return fs.md(nap6[1], nap6[0]);

                            //rd... rm -r
                case "rd":
                    string[] nap7 = parseFullyQualifiedName(cmdAndParam[1]);
                    return fs.rd(nap7[1], nap7[0]);
                case "exit":
                    this.Close();
                    return "";
                default:
                    return "command not found: " + cmd;
            }
            
        }

        private string chmod(string cmd, string[] cmdAndParam) {
            if (cmdAndParam.Length < 3) {
                return "Usage: chmod [0-7]{3} filename";
            }
            string mode = cmdAndParam[1];
            Regex regex = new Regex("[0-7]{3}");
            if (!regex.IsMatch(mode)) {
                return "Usage: chmod [0-7]{3} filename";
            }

            string[] nap5 = parseFullyQualifiedName(cmdAndParam[2]);
            //具有写权限
            if (mode[0] == '7' || mode[0] == '6' || mode[0] == '3' || mode[0] == '2') {
                fs.changeAttr(nap5[1], nap5[0], 'w');
            }
            else if (mode[0] == '5' || mode[0] == '4' || mode[0] == '1') {
                fs.changeAttr(nap5[1], nap5[0], 'r');
            }
            else if (mode[0] == '0') {
                fs.changeAttr(nap5[1], nap5[0], 'n');
            }
            return "";
        }
        //自制的低仿vi.....
        private string writeWithVi(string cmd, string[] cmdAndParam) {
            if (cmdAndParam.Length > 3) {
                return "Usage: vi filename";
            }
            ViTextArea viTextArea;
            string[] nap2 = parseFullyQualifiedName(cmdAndParam[1]);
            if (!fs.exists(nap2[1], nap2[0])) {//文件不存在则创建新的文件
                string cres = fs.createFile(nap2[1], nap2[0], 'w');
                if (cres == "No such directory!\n") {//创建文件失败则直接返回
                    return cres;
                }
                viTextArea = new ViTextArea(fs, this, nap2[1], nap2[0], false);//新建文件后的写入
            }
            else {
                viTextArea = new ViTextArea(fs, this, nap2[1], nap2[0], true);//追加
            }
            this.Hide();
            viTextArea.StartPosition = this.StartPosition;
            viTextArea.Show();
            return "";
        }
        /**
         *  解析全限定名
         *  return:
         *      string[0]:name
         *      stirng[1]:path
         */
        private string[] parseFullyQualifiedName(string qname) {
            string[] res = new string[2];
            if (!qname.Contains("/")) {//没有指定路径则在当前目录
                res[0] = qname;
                if (curDir.name == "/") {
                    res[1] = "/";
                }
                else {
                    res[1] = curDir.absolutePath.ToString()+curDir.name+"/";
                }
                return res;
            }
            string path = qname.Substring(0, qname.LastIndexOf("/")) + "/";
            string name = qname.Substring(qname.LastIndexOf("/") + 1, qname.Length - qname.LastIndexOf("/") - 1);
            if (qname.StartsWith("./") || !qname.StartsWith("/")) {//相对路径  ./sadasda/sss  asdasd/asda
                res[0] = name;
                if (qname.StartsWith("./")) {
                    if (qname.LastIndexOf("/") == 1) {
                        path = curDir.absolutePath.ToString() + curDir.name + "/";
                    }
                    else {
                        path = qname.Substring(2, qname.LastIndexOf("/")) + "/";
                    }
                    res[1] = path;
                    return res;
                }
                if (!qname.StartsWith("/")) {
                    path = qname.Substring(0, qname.LastIndexOf("/")) + "/";
                    res[1] = curDir.absolutePath.ToString() + curDir.name + "/" +path;
                    return res;
                }
            }
            res[0] = name;
            res[1] = path;
            return res;
        }

        private void nextLine() {
            Label uLabel = new Label();
            uLabel.Text = curUserLabel.Text;
            uLabel.ForeColor = curUserLabel.ForeColor;
            uLabel.Width = curUserLabel.Width;
            uLabel.Font = curUserLabel.Font;
            curLY += offsetY + (hasMsg ? msgoffset : 0);
            Point pp = new Point(curLX, curLY);
            uLabel.Location = pp;
            panel1.Controls.Add(uLabel);
            curUserLabel = uLabel;


            TextBox tLine = new TextBox();
            curTY += offsetY + (hasMsg ? msgoffset : 0);
            Point ppp = new Point(curTX, curTY);
            tLine.Location = ppp;
            tLine.Width = curTextLine.Width;
            tLine.KeyPress += textLine_KeyPress;
            tLine.ForeColor = curTextLine.ForeColor;
            tLine.BackColor = curTextLine.BackColor;
            tLine.BorderStyle = curTextLine.BorderStyle;
            tLine.Font = curTextLine.Font;
            panel1.Controls.Add(tLine);
            curTextLine = tLine;
            curTextLine.Focus();
            hasMsg = false;
        }

        private void addMessage(string result) {
            Label msg = new Label();
            msg.ForeColor = curUserLabel.ForeColor;
            msg.Font = curUserLabel.Font;
            msg.Text = result;
            msg.Width = (int)getContentSize(result).Width + 12;
            msg.Height = (int)getContentSize(result).Height + 23;
            Point pp = new Point(curLX, curLY + 26);
            msgoffset = msg.Height;
            msg.Location = pp;
            panel1.Controls.Add(msg);
        }

        private SizeF getContentSize(string content) {
            Font f = new Font("微软雅黑", 10.5F);
            Graphics g = panel1.CreateGraphics();
            SizeF siF = g.MeasureString(content, f);//通过此方法得到字体的像素长度
            return siF;//因为得到的长度是浮点数，所以要进行转换成整形才能使用
        }

        private void textLine_TextChanged(object sender, EventArgs e) {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
