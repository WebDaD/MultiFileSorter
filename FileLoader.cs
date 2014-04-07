using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MultiFileSorter
{
    public partial class FileLoader : Form
    {
        public FileLoader()
        {
            InitializeComponent();
            Files = new List<string>();
        }

        public List<string> Files { get; set; }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            fbd.ShowDialog();
            txt_folder.Text = fbd.SelectedPath;
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_folder.Text))
            {
                MessageBox.Show("Please Choose a Folder!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                loadFiles();
                btn_cancel_Click(sender, e);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadFiles()
        {
            if(cb_subfolders.Checked)
            {
                if (cb_sort.Checked)
                {
                    Files.AddRange(Directory.GetFiles(txt_folder.Text, "*.*", SearchOption.AllDirectories).OrderBy(p => Path.GetExtension(p)));
                }
                else
                {
                    Files.AddRange(Directory.GetFiles(txt_folder.Text, "*.*", SearchOption.AllDirectories));
                }
            }
            else
            {
                if (cb_sort.Checked)
                {
                    Files.AddRange(Directory.GetFiles(txt_folder.Text, "*.*", SearchOption.TopDirectoryOnly).OrderBy(p => Path.GetExtension(p)));
                }
                else
                {
                    Files.AddRange(Directory.GetFiles(txt_folder.Text, "*.*", SearchOption.TopDirectoryOnly));
                }
            }
        }
    }
}
