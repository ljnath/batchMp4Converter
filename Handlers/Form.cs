using BatchMp4Converter.Forms;
using System;
using System.Windows.Forms;

namespace BatchMp4Converter.Handlers
{
    static class Form
    {
        internal static void Update(MainForm mainform)
        {
            mainform.Text = string.Format("{0} v{1}", Data.AppName, Data.AppVersion);
            mainform.MaximumSize = mainform.MinimumSize = mainform.Size;
            mainform.MaximizeBox = false;

            mainform.dgvJobs.BackgroundColor = mainform.BackColor;
            mainform.dgvJobs.BorderStyle = BorderStyle.None;
            mainform.dgvJobs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            mainform.dgvJobs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            mainform.dgvJobs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            mainform.dgvJobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainform.dgvJobs.MultiSelect = false;
            mainform.dgvJobs.RowHeadersVisible = false;
            mainform.dgvJobs.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            mainform.dgvJobs.AllowUserToAddRows = false;
            mainform.dgvJobs.AllowUserToDeleteRows = false;
            mainform.dgvJobs.AllowUserToResizeRows = false;
            mainform.dgvJobs.AllowUserToOrderColumns = false;
            mainform.dgvJobs.AllowUserToResizeColumns = false;

            mainform.dgvJobs.Columns.Add("serial", "Serial No.");
            mainform.dgvJobs.Columns.Add("id", "Job ID");
            mainform.dgvJobs.Columns.Add("inputVideo", "Input Video");
            mainform.dgvJobs.Columns.Add("inputSize", "Size (in MB)");
            mainform.dgvJobs.Columns.Add("ouptutVideo", "Output Video");
            mainform.dgvJobs.Columns.Add("outputSize", "Size (in MB)");
            mainform.dgvJobs.Columns.Add("status", "Status");

            mainform.dgvJobs.Columns[0].Width = 25;
            mainform.dgvJobs.Columns[1].Visible = false;
            mainform.dgvJobs.Columns[3].Width = mainform.dgvJobs.Columns[5].Width = 40;
            mainform.dgvJobs.Columns[6].Width = 70;

            mainform.btnAdd.Text = "&Add Job(s)";
            mainform.btnStart.Text = "&Start Jobs";
            mainform.btnExit.Text = "E&xit";
            mainform.btnAbout.Text = "&About";

            mainform.timerRefresh.Interval = 2000;
            mainform.timerRefresh.Enabled = false;
        }

        internal static void RefreshJobList(DataGridView dgv)
        {
            int counter = 0;
            dgv.Rows.Clear();

            foreach (Models.Job job in Data.Jobs.AllJobs)
            {
                dgv.Rows.Insert(counter++, counter, job.Id, job.InputVideoFile, job.InputFileSize, job.OutputVideoFile, job.OutputFileSize, job.Status);
                if (job.Status == Models.JobStatus.RUNNING)
                    dgv.Rows[counter - 1].Selected = true;
            }
        }

        internal static void RefreshJobControl(Button btn)
        {
            btn.Enabled = Data.Jobs.IsWaiting();
        }

    }
}
