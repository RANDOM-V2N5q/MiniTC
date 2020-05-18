using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace MiniTC.Model {
    class Panel {
        public Panel() {
            SelectedDriveIndex = 0;
            SelectedItemIndex = -1;
        }

        public String Path { get; private set; }
        public String[] Drives { get { return Directory.GetLogicalDrives(); } }
        public String[] Directorys { get { return Directory.GetDirectories(Path); } }
        public String[] Files { get { return Directory.GetFiles(Path); } }
        public Int32 SelectedDriveIndex { set { Path = Drives[value]; } }

        private Int32 selectedItemIndex;
        public Int32 SelectedItemIndex {
            get { return selectedItemIndex; }
            set {
                Int32 tmp = (Path.Length > 3) ? 1 : 0;

                if(value > Directorys.Length - 1 + tmp) {
                    selectedItemIndex = value;
                }
                else if(value > -1 + tmp) {
                    try {
                        Directory.GetDirectories(Directorys[value - tmp]);
                        Path = Directorys[value - tmp];
                        selectedItemIndex = -1;
                    }
                    catch(Exception e) {
                        MessageBox.Show(e.Message, Properties.Resources.AccessError, MessageBoxButton.OK);
                    }
                }
                else if(value > -1) {
                    Path = Directory.GetParent(Path).FullName;
                    selectedItemIndex = -1;
                }
                else {
                    selectedItemIndex = value;
                }
            }
        }

        public String[] Items {
            get {
                List<String> tmp = new List<String>();
                if(Path.Length > 3) {
                    tmp.Add("..");
                }

                String[] DirectorysArray = Directorys;
                for(Int32 i = 0; i < DirectorysArray.Length; i++) {
                    tmp.Add($"<D>{ DirectorysArray[i].Substring(DirectorysArray[i].LastIndexOf('\\') + 1)}");
                }
                String[] FilesArray = Files;
                for(Int32 i = 0; i < FilesArray.Length; i++) {
                    tmp.Add($"{ FilesArray[i].Substring(FilesArray[i].LastIndexOf('\\') + 1)}");
                }

                return tmp.ToArray();
            }
        }
    }
}
