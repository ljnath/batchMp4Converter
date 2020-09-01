using System;
using System.Diagnostics;
using System.IO;
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
        internal static decimal GetFileSizeInMb(string filepath)
        {
            decimal filesize = 0;
            if (File.Exists(filepath))
                filesize = Math.Round((decimal)new FileInfo(filepath).Length / (1024 * 1024), 2);
            return filesize;
        }
    }
}
