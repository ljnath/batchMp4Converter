using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace BatchMp4Converter
{
    internal static class Utility
    {
        internal static string GetJobId()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }

        internal static string[] GetInputVideos()
        {
            string[] inputVideoFile = Array.Empty<string>();
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Choose input video file",
                Filter = "Supported Video Files|*.3gp;*.mp4;*.mkv;*.flv;*.avi;*.wmv;*.divx;*.mpeg;*.mov;*.webm"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                inputVideoFile = openFileDialog.FileNames;
            return inputVideoFile;
        }
        internal static void KillProcess(int pid)
        {
            if (pid > 0)
                Process.GetProcessById(pid).Kill();
        }
        internal static string GetReadableFileSize(string filepath)
        {
            double filesize = 0;
            byte unitIndex = 0;
            string unit = "Byte";
            if (File.Exists(filepath))
                filesize = new FileInfo(filepath).Length;
            
            while (filesize > 1024)
            {
                filesize /= 1024;
                ++unitIndex;
            }

            switch (unitIndex)
            {
                case 1: unit = "KB"; break;
                case 2: unit = "MB"; break;
                case 3: unit = "GB"; break;
                case 4: unit = "TB"; break;
            }
            return string.Format("{0} {1}", Math.Round(filesize, 2), unit);
        }
        internal static void CheckForUpdate()
        {
            new Thread(delegate ()
            {
                try
                {
                    string newVersion = string.Empty;
                    HttpWebRequest updateRequest = (HttpWebRequest)WebRequest.Create(Data.AppUpdateApi);
                    updateRequest.AutomaticDecompression = DecompressionMethods.GZip;

                    using (HttpWebResponse response = (HttpWebResponse)updateRequest.GetResponse())
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            newVersion = reader.ReadToEnd();
                        }
                    }

                    if (Convert.ToDouble(newVersion) > Convert.ToDouble(Data.AppVersion) && MessageBox.Show(string.Format("A new version of {0} is available for download.\nDo you want to download it now ?", Data.AppName), "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        Process.Start(Data.AppDownloadUrl);
                }
                catch
                {
                    // i am okay with this
                }
            }).Start();
        }
    }
}
