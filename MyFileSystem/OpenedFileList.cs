using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileSystem {
    [Serializable]
    class OpenedFileList {

        public const int MAX_NUMS = 22;
        public List<OpenedFile> files;
        FAT fat;
        public OpenedFileList(FAT fat) {
            files = new List<OpenedFile>(MAX_NUMS);
            this.fat = fat;
        }

        public bool Add(File file, string mode) {
            OpenedFile f = new OpenedFile(file,mode,fat);
            if (this.files.Count > MAX_NUMS) {
                return false;
            }
            this.files.Add(f);
            return true;
        }

        public bool hasOpened(string filename) {
            foreach (OpenedFile f in this.files) {
                if (f.name == filename) {//already open
                    return true;
                }
            }
            return false;
        }

        public OpenedFile getFile(string filename) {
            foreach (OpenedFile f in this.files) {
                if (f.name == filename) {//already open
                    return f;
                }
            }
            return null;
        }

        public bool remove(string filename) {
            for (int i = 0; i < files.Count; i++) {
                if (files[i].name == filename) {
                    files.Remove(files[i]);
                    return true;
                }
            }
            return false;
        }

    }
}
