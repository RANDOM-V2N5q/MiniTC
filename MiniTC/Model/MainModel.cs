using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MiniTC.Model {
    class MainModel {
        public Panel LeftPanel { get; set; } = new Panel();
        public Panel RightPanel { get; set; } = new Panel();

        public void Copy() {
            try {
                Int32 tmp = (LeftPanel.Path.Length > 3) ? 1 : 0;
                String source = LeftPanel.Files[LeftPanel.SelectedItemIndex - LeftPanel.Directorys.Length - tmp];
                String destination = $"{RightPanel.Path}{source.Substring(source.LastIndexOf('\\'))}";
                File.Copy(source, destination);
            }
            catch(Exception e) {
                MessageBox.Show(e.ToString(), Properties.Resources.CopyError, MessageBoxButtons.OK);
            }
        }
    }
}
