using System;

namespace BatchMp4Converter.Models
{
    [Serializable]
    class Job
    {
        public Job(string id, string inputVideoFile)
        {
            Id = id;
            InputVideoFile = inputVideoFile;
            OutputVideoFile = string.Format("{0}_converted.mp4", inputVideoFile.Substring(0, inputVideoFile.LastIndexOf('.')));
            InputFileSize = Utility.GetReadableFileSize(inputVideoFile);
        }
        public string Id { get; }
        public string InputVideoFile { get; }
        public string InputFileSize { get; }
        public string OutputVideoFile { get; }
        public string OutputFileSize { get; set; } = string.Empty;
        public JobStatus Status { get; set; } = JobStatus.WAITING;
        public bool IsWaiting
        {
            get
            {
                return !(Status == JobStatus.COMPLETED || Status == JobStatus.FAILED);
            }
        }
    }
}
