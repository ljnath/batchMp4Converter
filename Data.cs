using System;
using System.ComponentModel;
using System.IO;
using BatchMp4Converter.Models;

namespace BatchMp4Converter
{
    internal static class Data
    {
        internal static string AppName { get { return "Batch MP4 Converter"; } }
        internal static string AppVersion { get { return "1.1"; } }
        internal static string AppDownloadUrl { get { return "https://sourceforge.net/projects/batchmp4converter/files/latest/download";  } }
        internal static string AppUpdateApi { get { return "https://app.ljnath.com/batchmp4converter"; } }

        internal static string JobsDbFile { get { return Path.Combine(Environment.CurrentDirectory, "jobs"); } }
        internal static Jobs Jobs { get; set; }
        internal static Job SelectedJob { get; set; }
        
        internal static BackgroundWorker FfmpegWorker { get; set; } = new BackgroundWorker();
        internal static string FfmpegBinary { get { return Path.Combine(Environment.CurrentDirectory, "ffmpeg.exe"); } }
        internal static string FfmpegDownloadLink { get { return "https://ffmpeg.org/download.html"; } }

        internal static string VideoCodec { get { return "libx264"; } }
        internal static string AudioCodec { get { return "aac"; } }
        
    }
}
