using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caciki25022022
{
    class Functions
    {
        public static void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }

        public static OpenFileDialog openfiledialog = new OpenFileDialog
        {
            //Filter = "Txt/Lua Files(.txt; .lua)|*txt; *lua",
            Filter = "Txt/Lua Files(.txt; .lua)|*txt; *lua",
            //Filter = "Lua (*.lua)|*.lua|All files (*.*)|*.*",
            FilterIndex = 1,
            RestoreDirectory = true,
            Title = "Open"
        };
    }
}
