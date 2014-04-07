using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiFileSorter
{
    public partial class PressKeyDialog : Form
    {
        private char key;
        public char Key { get { return key; } set { key = value; } }

        public PressKeyDialog()
        {
            InitializeComponent();
            key = new Char();
        }

        private void PressKeyDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            key = e.KeyChar;
            lbl_key.Text = key+"";
            lbl_key.Invalidate();
            lbl_key.Update();
            lbl_key.Refresh();
            Application.DoEvents();
            System.Threading.Thread.Sleep(250);
            this.Close();
        }
    }
}
