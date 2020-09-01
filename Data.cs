using System;
using System.ComponentModel;
using System.IO;
using BatchMp4Converter.Models;

namespace BatchMp4Converter
{
    internal static class Data
    {
        internal static string AppName { get { return "Batch MP4 Converter"; } }
        internal static string AppVersion { get { return "1.0"; } }
        
        internal static string JobsFile { get { return Path.Combine(Environment.CurrentDirectory, "jobs"); } }
        internal static Jobs Jobs { get; set; }
        internal static Job SelectedJob { get; set; }
        
        internal static BackgroundWorker FfmpegWorker { get; set; } = new BackgroundWorker();
        internal static string FfmpegBinary { get { return Path.Combine(Environment.CurrentDirectory, "ffmpeg.exe"); } }
        internal static string FfmpegDownloadLink { get { return "https://ffmpeg.org/download.html"; } }

        internal static string VideoCodec { get { return "libx264"; } }
        internal static string AudioCodec { get { return "aac"; } }
        
    }
}
