using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BatchMp4Converter.Handlers;
using BatchMp4Converter.Models;

namespace BatchMp4Converter.Forms
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
            Handlers.Form.Update(this);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btnAdd":
                    Handlers.Job.Instance.Add(Utility.GetInputVideos());
                    Handlers.Form.RefreshJobList(dgvJobs);
                    Handlers.Form.RefreshJobControl(btnStart);
                    break;
                case "btnStart":
                    if (Data.FfmpegWorker.IsBusy)
                    {
                        btnStart.Text = "Stopping...";
                        btnStart.Enabled = false;
                        Handlers.Job.Instance.Stop();
                        tsmiDeleteJob.Enabled = tsmiDeleteAllJobs.Enabled = true;
                    }
                    else
                    {
                        tsmiDeleteJob.Enabled = tsmiDeleteAllJobs.Enabled = false;
                        btnStart.Text = "&Stop Jobs";
                        btnAdd.Enabled = false;
                        timerRefresh.Start();
                        Handlers.Job.Instance.Start(this);
                    }
                    Handlers.Form.RefreshJobControl(btnStart);
                    break;
                case "btnAbout":
                    MessageBox.Show(string.Format("{0} {1}\n\nAuthor: Lakhya Jyoti Nath (ljnath)\nEmail: ljnath@ljnath.com\nWebsite: www.ljnath.com", Data.AppName, Data.AppVersion), "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "btnExit":
                    Application.Exit();
                    break;
            }
        }

        private void ToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            switch (tsmi.Name)
            {
                case "tsmiDeleteJob":
                    if (MessageBox.Show(string.Format("Do you really want to delete the job for {0} ?", Data.SelectedJob.InputVideoFile), Data.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        Handlers.Job.Instance.Remove(Data.SelectedJob.Id);
                    break;
                case "tsmiDeleteAllJobs":
                    if (MessageBox.Show("Do you really want to delete all jobs ?", Data.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        Handlers.Job.Instance.RemoveAll();
                    break;
                case "tsmiOpenFileLocation":
                    Process.Start(Path.GetDirectoryName(Data.SelectedJob.InputVideoFile));
                    break;
            }
            Handlers.Form.RefreshJobList(dgvJobs);
        }

        private void DataGridViewMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvJobs.ClearSelection();
                DataGridView.HitTestInfo hitTestInfo = dgvJobs.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0 && hitTestInfo.ColumnIndex >= 0)
                {
                    dgvJobs.Rows[hitTestInfo.RowIndex].Selected = true;
                    Data.SelectedJob= Data.Jobs.Find(dgvJobs[1, hitTestInfo.RowIndex].Value.ToString());
                    if (Data.SelectedJob != null)
                    {
                        Point mousePoint = dgvJobs.PointToScreen(e.Location);
                        cmsJobs.Show(mousePoint);
                    }
                }
            }
        }

        private void TimerRefreshTick(object sender, EventArgs e)
        {
            Handlers.Form.RefreshJobList(dgvJobs);
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            if (!File.Exists(Data.FfmpegBinary))
            {
                if (MessageBox.Show(string.Format("FFmpeg binary file is missing. It should be present under {0} directory.\n\nYou may download it from  {1}\n\nDo you want to download it from the above link ?", Environment.CurrentDirectory, Data.FfmpegDownloadLink), Data.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(Data.FfmpegDownloadLink);
                Application.Exit();
            }

            Handlers.Job.Instance.LoadFromFile();
            Handlers.Form.RefreshJobList(dgvJobs);
            Handlers.Form.RefreshJobControl(btnStart);
            timerRefresh.Enabled = true;
            timerRefresh.Stop();
            Utility.CheckForUpdate();
        }
    }
}
