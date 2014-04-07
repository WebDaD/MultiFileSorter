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
    public partial class Options : Form
    {
        PressKeyDialog pkd = new PressKeyDialog();

        public Options()
        {
            InitializeComponent();
            Properties.Settings.Default.Reload();
            if (Properties.Settings.Default.Markers == null)
            {
                Properties.Settings.Default.Markers = new List<Marker>();
                Properties.Settings.Default.Markers.Add(new Marker(0, new Char(), "", 255,255,255));
                Properties.Settings.Default.Markers.Add(new Marker(1, new Char(), "", 255, 255, 255));
                Properties.Settings.Default.Markers.Add(new Marker(2, new Char(), "", 255, 255, 255));
                Properties.Settings.Default.Markers.Add(new Marker(3, new Char(), "", 255, 255, 255));
                Properties.Settings.Default.Markers.Add(new Marker(4, new Char(), "", 255, 255, 255));
                Properties.Settings.Default.Markers.Add(new Marker(5, new Char(), "", 255, 255, 255));
                Properties.Settings.Default.Markers.Add(new Marker(6, new Char(), "", 255, 255, 255));
                Properties.Settings.Default.Markers.Add(new Marker(7, new Char(), "", 255, 255, 255));
                Properties.Settings.Default.Markers.Add(new Marker(8, new Char(), "", 255, 255, 255));
            }

            cb_markandnext.Checked = Properties.Settings.Default.MarkAndNext;
            cb_deleteaftercopy.Checked = Properties.Settings.Default.DeleteAfterCopy;
            cb_forceoverwrite.Checked = Properties.Settings.Default.ForceOverwrite;
            cb_JumpToMiddle.Checked = Properties.Settings.Default.JumpToMiddle;
            foreach (Marker m in Properties.Settings.Default.Markers)
            {
                switch (m.ID)
                {
                    case 0: 
                        l0_mark_key.Text = m.Key+"";
                        l0_mark_folder.Text = m.Folder;
                        l0_mark_color.BackColor = m.Color;
                        break;
                    case 1:
                        l1_mark_key.Text = m.Key + "";
                        l1_mark_folder.Text = m.Folder;
                        l1_mark_color.BackColor = m.Color;
                        break;
                    case 2:
                        l2_mark_key.Text = m.Key + "";
                        l2_mark_folder.Text = m.Folder;
                        l2_mark_color.BackColor = m.Color;
                        break;
                    case 3:
                        l3_mark_key.Text = m.Key + "";
                        l3_mark_folder.Text = m.Folder;
                        l3_mark_color.BackColor = m.Color;
                        break;
                    case 4:
                        l4_mark_key.Text = m.Key + "";
                        l4_mark_folder.Text = m.Folder;
                        l4_mark_color.BackColor = m.Color;
                        break;
                    case 5:
                        l5_mark_key.Text = m.Key + "";
                        l5_mark_folder.Text = m.Folder;
                        l5_mark_color.BackColor = m.Color;
                        break;
                    case 6:
                        l6_mark_key.Text = m.Key + "";
                        l6_mark_folder.Text = m.Folder;
                        l6_mark_color.BackColor = m.Color;
                        break;
                    case 7:
                        l7_mark_key.Text = m.Key + "";
                        l7_mark_folder.Text = m.Folder;
                        l7_mark_color.BackColor = m.Color;
                        break;
                    case 8:
                        l8_mark_key.Text = m.Key + "";
                        l8_mark_folder.Text = m.Folder;
                        l8_mark_color.BackColor = m.Color;
                        break;
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MarkAndNext = cb_markandnext.Checked;
            Properties.Settings.Default.DeleteAfterCopy = cb_deleteaftercopy.Checked;
            Properties.Settings.Default.ForceOverwrite = cb_forceoverwrite.Checked;
            Properties.Settings.Default.JumpToMiddle = cb_JumpToMiddle.Checked;

            foreach (Marker m in Properties.Settings.Default.Markers)
            {
                switch (m.ID)
                {
                    case 0:
                        if (!String.IsNullOrEmpty(l0_mark_key.Text))
                        {
                            m.Key = l0_mark_key.Text[0];
                            m.Folder = l0_mark_folder.Text;
                            m.Color_R = l0_mark_color.BackColor.R;
                            m.Color_G = l0_mark_color.BackColor.G;
                            m.Color_B = l0_mark_color.BackColor.B;
                        }
                        else
                        {
                            m.Key = new Char();
                            m.Folder = "";
                            m.Color_R = 255;
                            m.Color_G = 255;
                            m.Color_B = 255;
                        }
                        break;
                    case 1:
                        if (!String.IsNullOrEmpty(l1_mark_key.Text))
                        {
                            m.Key = l1_mark_key.Text[0];
                            m.Folder=  l1_mark_folder.Text;
                            m.Color_R = l1_mark_color.BackColor.R;
                            m.Color_G = l1_mark_color.BackColor.G;
                            m.Color_B = l1_mark_color.BackColor.B;
                        }
                        else
                        {
                            m.Key = new Char();
                            m.Folder = "";
                            m.Color_R = 255;
                            m.Color_G = 255;
                            m.Color_B = 255;
                        }
                        break;
                    case 2:
                        if (!String.IsNullOrEmpty(l2_mark_key.Text))
                        {
                        m.Key = l2_mark_key.Text[0];
                        m.Folder=  l2_mark_folder.Text;
                        m.Color_R = l2_mark_color.BackColor.R;
                        m.Color_G = l2_mark_color.BackColor.G;
                        m.Color_B = l2_mark_color.BackColor.B;
                       }
                        else
                        {
                            m.Key = new Char();
                            m.Folder = "";
                            m.Color_R = 255;
                            m.Color_G = 255;
                            m.Color_B = 255;
                        }
                        break;
                    case 3:
                        if (!String.IsNullOrEmpty(l3_mark_key.Text))
                        {
                        m.Key = l3_mark_key.Text[0];
                        m.Folder=  l3_mark_folder.Text;
                        m.Color_R = l3_mark_color.BackColor.R;
                        m.Color_G = l3_mark_color.BackColor.G;
                        m.Color_B = l3_mark_color.BackColor.B;
                        }
                        else
                        {
                            m.Key = new Char();
                            m.Folder = "";
                            m.Color_R = 255;
                            m.Color_G = 255;
                            m.Color_B = 255;
                        }
                        break;
                    case 4:
                        if (!String.IsNullOrEmpty(l4_mark_key.Text))
                        {
                        m.Key = l4_mark_key.Text[0];
                        m.Folder=  l4_mark_folder.Text;
                        m.Color_R = l4_mark_color.BackColor.R;
                        m.Color_G = l4_mark_color.BackColor.G;
                        m.Color_B = l4_mark_color.BackColor.B;
                        }
                        else
                        {
                            m.Key = new Char();
                            m.Folder = "";
                            m.Color_R = 255;
                            m.Color_G = 255;
                            m.Color_B = 255;
                        }
                        break;
                    case 5:
                        if (!String.IsNullOrEmpty(l5_mark_key.Text))
                        {
                        m.Key = l5_mark_key.Text[0];
                        m.Folder=  l5_mark_folder.Text;
                        m.Color_R = l5_mark_color.BackColor.R;
                        m.Color_G = l5_mark_color.BackColor.G;
                        m.Color_B = l5_mark_color.BackColor.B;
                        }
                        else
                        {
                            m.Key = new Char();
                            m.Folder = "";
                            m.Color_R = 255;
                            m.Color_G = 255;
                            m.Color_B = 255;
                        }
                        break;
                    case 6:
                        if (!String.IsNullOrEmpty(l6_mark_key.Text))
                        {
                        m.Key = l6_mark_key.Text[0];
                        m.Folder=  l6_mark_folder.Text;
                        m.Color_R = l6_mark_color.BackColor.R;
                        m.Color_G = l6_mark_color.BackColor.G;
                        m.Color_B = l6_mark_color.BackColor.B;
                        }
                        else
                        {
                            m.Key = new Char();
                            m.Folder = "";
                            m.Color_R = 255;
                            m.Color_G = 255;
                            m.Color_B = 255;
                        }
                        break;
                    case 7:
                         if (!String.IsNullOrEmpty(l7_mark_key.Text))
                        {
                        m.Key = l7_mark_key.Text[0];
                        m.Folder=  l7_mark_folder.Text;
                        m.Color_R = l7_mark_color.BackColor.R;
                        m.Color_G = l7_mark_color.BackColor.G;
                        m.Color_B = l7_mark_color.BackColor.B;
                         }
                        else
                        {
                            m.Key = new Char();
                            m.Folder = "";
                            m.Color_R = 255;
                            m.Color_G = 255;
                            m.Color_B = 255;
                        }
                        break;
                    case 8:
                        if (!String.IsNullOrEmpty(l8_mark_key.Text))
                        {
                        m.Key = l8_mark_key.Text[0];
                        m.Folder=  l8_mark_folder.Text;
                        m.Color_R = l8_mark_color.BackColor.R;
                        m.Color_G = l8_mark_color.BackColor.G;
                        m.Color_B = l8_mark_color.BackColor.B;
                        }
                        else
                        {
                            m.Key = new Char();
                            m.Folder = "";
                            m.Color_R = 255;
                            m.Color_G = 255;
                            m.Color_B = 255;
                        }
                        break;
                }
            }
            Properties.Settings.Default.Save();
        }

        private void btn_save_exit_Click(object sender, EventArgs e)
        {
            btn_apply_Click(sender, e);
            btn_cancel_Click(sender, e);
        }



        private void mark_key_Click(object sender, EventArgs e)
        {
            pkd.Key = new Char();
            pkd.ShowDialog();
            TextBox t = (TextBox)sender as TextBox;
            t.Text = pkd.Key + "";
        }

        private void mark_folder_Click(object sender, EventArgs e)
        {
            fbd_folder.SelectedPath = "";
            fbd_folder.ShowDialog();
            TextBox t = (TextBox)sender as TextBox;
            t.Text = fbd_folder.SelectedPath;
        }

        private void mark_color_Click(object sender, EventArgs e)
        {
            cd_color.ShowDialog();
            Label t = (Label)sender as Label;
            t.BackColor = cd_color.Color;
        }
    }
}
