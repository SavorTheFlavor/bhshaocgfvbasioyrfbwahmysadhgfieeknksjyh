using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyFileSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BinaryFormatter bformatter = new BinaryFormatter();

            FileSystem fs = null;
            Stream inStream = null;
            try {
                inStream = new FileStream("mydisk.dat", FileMode.Open, FileAccess.Read);
                fs = (FileSystem)bformatter.Deserialize(inStream);
            }
            catch {
                fs = new FileSystem();
            }
            finally {
                if(inStream != null)
                     inStream.Close();
            }
            FileSystemUI fsui = new FileSystemUI(fs);
            Application.Run(fsui);
        }
    }
}
