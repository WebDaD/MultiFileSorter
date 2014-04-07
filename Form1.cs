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
    public partial class Form1 : Form
    {
        Options myOps;
        List<mFile> mfiles;
        List<string> files;
        WMPLib.WindowsMediaPlayer a;
        public Form1()
        {
            InitializeComponent();
            myOps = new Options();
            mfiles = new List<mFile>();
            files = new List<string>();
            a = new WMPLib.WindowsMediaPlayer();
            a.OpenStateChange += new WMPLib._WMPOCXEvents_OpenStateChangeEventHandler(a_OpenStateChange);
        }


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileLoader f = new FileLoader();
            f.ShowDialog();
            files = f.Files;
            f = null;
            if (files.Count > 0)
            {
                btn_copy.Enabled = true;
                btn_Start.Enabled = true;
                exportToolStripMenuItem.Enabled = true;
                foreach (string file in files)
                {
                    list_files.Items.Add(file);
                }
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myOps.ShowDialog();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_copy_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btn_copy.Enabled && (mfiles.Count > 0 || files.Count > 0))
            {
                if (DialogResult.Yes == MessageBox.Show("Still Files open.\nReally Exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Help().ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About("MultiFileSorter","http://www.webdad.eu").ShowDialog(); //TODO: Edit Dialog
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            if (mfiles.Count > 0)
            {
                RunProgress();
            }
            else
            {
                MessageBox.Show("No Marked Files!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (list_files.SelectedItems.Count < 1) return;
            if (a.playState == WMPLib.WMPPlayState.wmppsPlaying) a.controls.stop();
            foreach (Marker m in Properties.Settings.Default.Markers)
            {
                if (e.KeyChar == m.Key)
                {
                    mfiles.Add(new mFile(m,list_files.SelectedItems[0].Text));
                    list_files.SelectedItems[0].BackColor = m.Color;
                    list_files.SelectedItems[0].ForeColor = ContrastColor(m.Color);
                    if (Properties.Settings.Default.MarkAndNext)
                    {
                        if (list_files.SelectedIndices.Count > 0)
                        {
                            int oldSelection = list_files.SelectedIndices[0];
                            list_files.SelectedIndices.Clear();

                            if (oldSelection + 1 >= list_files.Items.Count)
                                list_files.SelectedIndices.Add(0);
                            else
                                list_files.SelectedIndices.Add(oldSelection + 1);
                        }
                        string s = list_files.SelectedItems[0].Text;
                        if (s.EndsWith("mp3"))
                        {
                            startSong(s);
                        }
                    }
                    break;
                }
            }
        }

        private void clearListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            files.Clear();
            list_files.Items.Clear();
            btn_copy.Enabled = false;
            exportToolStripMenuItem.Enabled = false;
            btn_Start.Enabled = false;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            list_files.Items[0].Selected=true;
            list_files.Focus();
            if (list_files.Items[0].ToString().EndsWith("mp3"))
            {
                startSong(list_files.Items[0].ToString());
            }
        }

        private Color ContrastColor(Color color)
        {
            int d = 0;

            // Counting the perceptive luminance - human eye favors green color... 
            double a = 1 - (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            if (a < 0.5)
                d = 0; // bright colors - black font
            else
                d = 255; // dark colors - white font

            return Color.FromArgb(d, d, d);
        }

        /// <summary>
        /// This function displays a processing and display of progress with RuProgressBar
        /// </summary>
        public void RunProgress()
        {
            try
            {
                // Init ProgressBar
                ProgressWindow progress = new ProgressWindow();
                progress.Text = "Copying Files...";

                // Run Application with ProgressBar
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(Copy), progress);
                progress.ShowDialog();
            }
            catch
            {
            }

        }
        /// <summary>
        ///  Function of progress should appear 
        /// </summary>
        /// <param name="status"></param>
        public void Copy(object status)
        {
            try
            {
                IProgressCallback callback = status as IProgressCallback;

                // Init Progressbar
                int iMax = mfiles.Count;
                callback.Begin(0, iMax);
                int i = 0;
                foreach (mFile m in mfiles)
	                {
                        if (Properties.Settings.Default.ForceOverwrite)
                        {
                            File.Copy(m.File, m.Mark.Folder + "\\" + Path.GetFileName(m.File),true);
                        }
                        else
                        {
                            try
                            {
                                File.Copy(m.File, m.Mark.Folder + "\\" + Path.GetFileName(m.File));
                            }
                            catch (Exception)
                            {
                                if (DialogResult.Yes == MessageBox.Show(m.Mark.Folder + "\\" + Path.GetFileName(m.File) + " already exists.\nOverwrite?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                                {
                                    File.Copy(m.File, m.Mark.Folder + "\\" + Path.GetFileName(m.File),true);
                                }
                            }
                        }
                        
                        if (Properties.Settings.Default.DeleteAfterCopy)
                        {
                            File.Delete(m.File);
                        }
                        callback.StepTo(i);
                        i++;
	                }

               
                // End Progressbar
                callback.End();

            }
            catch (System.FormatException)
            {
            }
        }

        private void tb_player_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            a.controls.play();
            audio_counter.Start();
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            if (a.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                a.controls.pause();
                audio_counter.Stop();
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            if (a.playState == WMPLib.WMPPlayState.wmppsPlaying || a.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                a.controls.stop();
                audio_counter.Stop();
            }
        }

        private void startSong(string url)
        {
            a.URL = url;        
        }

        void a_OpenStateChange(int NewState)
        {
            if (a.openState == WMPLib.WMPOpenState.wmposMediaOpen)
            {
                double dur = a.controls.currentItem.duration;
                tb_player.Maximum = (int)dur;
                tb_player.Value = 0;
                if (Properties.Settings.Default.JumpToMiddle)
                {
                    a.controls.currentPosition = dur / 2;
                    tb_player.Value = (int)(dur / 2);
                    a.controls.play();
                }
                else
                {
                   a.controls.play(); 
                }
                audio_counter.Start(); 
            }
        }


        private void audio_counter_Tick(object sender, EventArgs e)
        {
            tb_player.Value = (int)a.controls.currentPosition;
        }

        private void tb_player_Scroll(object sender, EventArgs e)
        {
            if (a.playState == WMPLib.WMPPlayState.wmppsPlaying || a.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                a.controls.pause();
                a.controls.currentPosition = tb_player.Value;
                a.controls.play();
            }
        }
    }
}
