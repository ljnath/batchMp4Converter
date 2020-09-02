using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using BatchMp4Converter.Forms;
using BatchMp4Converter.Models;

namespace BatchMp4Converter.Handlers
{
    internal sealed class Job
    {
        private static Job jobHandler = new Job();
        private static readonly object padlock = new object();
        private bool StopWorker { get; set; } = false;
        private int FfmpegPid { get; set; } = -1;

        private Job()
        {
            // private constructor for singleton class
        }

        internal static Job Instance
        {
            get
            {
                lock (padlock)
                {
                    if (jobHandler == null)
                    {
                        jobHandler = new Job();
                    }
                    return jobHandler;
                }
            }
        }

        internal void LoadFromFile()
        {
            Jobs jobs = new Jobs();
            if (File.Exists(Data.JobsDbFile))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                try
                {
                    FileStream fileStream = new FileStream(Data.JobsDbFile, FileMode.Open, FileAccess.Read, FileShare.None);
                    using (fileStream)
                    {
                        jobs = (Jobs)binaryFormatter.Deserialize(fileStream);
                    }
                }
                catch
                {
                    jobs = new Jobs();
                }
            }
            Data.Jobs = jobs;
        }

        internal void SaveToFile()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(Data.JobsDbFile, FileMode.Create, FileAccess.Write, FileShare.None);
            using (fileStream)
            {
                binaryFormatter.Serialize(fileStream, Data.Jobs);
            }
        }

        internal void Add(string inputVideoFile)
        {
            if (string.IsNullOrWhiteSpace(inputVideoFile))
                return;

            Data.Jobs.AllJobs.Add(new Models.Job(Utility.GetJobId(), inputVideoFile));
            SaveToFile();
        }

        internal void Add(string[] inputVideoFiles)
        {
            if (inputVideoFiles.Length == 0)
                return;

            foreach (string videoFile in inputVideoFiles)
                Add(videoFile);
        }

        internal void Remove(string jobId)
        {
            Data.Jobs.Remove(jobId);
            SaveToFile();
        }

        internal void RemoveAll()
        {
            Data.Jobs = new Jobs();
            SaveToFile();
        }

        internal void Start(MainForm mainForm)
        {
            UInt16 sucessCount = 0, failedCount = 0;
            Data.FfmpegWorker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };

            Data.FfmpegWorker.DoWork += (sender, args) =>
            {
                StopWorker = false;
                for (int i = 0; i < Data.Jobs.AllJobs.Count; i++)
                {
                    if (StopWorker)
                        break;

                    if (!Data.Jobs.AllJobs[i].IsWaiting)
                        continue;

                    ProcessStartInfo processStartInfo = new ProcessStartInfo
                    {
                        Arguments = string.Format("-y -i \"{0}\" -vcodec {1} -acodec {2} \"{3}\"", Data.Jobs.AllJobs[i].InputVideoFile, Data.VideoCodec, Data.AudioCodec, Data.Jobs.AllJobs[i].OutputVideoFile),
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        FileName = Data.FfmpegBinary
                    };
                    Data.Jobs.AllJobs[i].Status = JobStatus.RUNNING;
                    Process workerProcess = Process.Start(processStartInfo);
                    FfmpegPid = workerProcess.Id;
                    workerProcess.WaitForExit();
                    if (workerProcess.ExitCode == 0)
                    {
                        sucessCount++;
                        Data.Jobs.AllJobs[i].Status = JobStatus.COMPLETED;
                        Data.Jobs.AllJobs[i].OutputFileSize = Utility.GetReadableFileSize(Data.Jobs.AllJobs[i].OutputVideoFile);
                    }
                    else
                    {
                        failedCount++;
                        Data.Jobs.AllJobs[i].Status = JobStatus.FAILED;
                    }
                    SaveToFile();
                }
            };
            Data.FfmpegWorker.RunWorkerCompleted += (sender, args) =>
            {
                Form.RefreshJobList(mainForm.dgvJobs);
                Form.RefreshJobControl(mainForm.btnStart);
                MessageBox.Show(string.Format("Completed conversion.\n\nTotal = {0}\nSuccessful = {1}\nFailed =  {2}", sucessCount+failedCount, sucessCount, failedCount), Data.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                mainForm.btnAdd.Enabled = mainForm.btnStart.Enabled = true;
                mainForm.btnStart.Text = "&Start Jobs";
                mainForm.timerRefresh.Stop();
            };
            Data.FfmpegWorker.RunWorkerAsync();
        }

        internal void Stop()
        {
            StopWorker = true;
            Utility.KillProcess(FfmpegPid);
            Data.FfmpegWorker.CancelAsync();
        }
    }
}
