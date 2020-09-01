using System;
using System.Collections.Generic;

namespace BatchMp4Converter.Models
{
    [Serializable]
    internal class Jobs
    {
        internal List<Job> AllJobs { get; set; } = new List<Job>();

        internal void Remove(string jobId)
        {
            int index = -1;
            for (int i = 0; i < AllJobs.Count; i++)
                if (AllJobs[i].Id == jobId)
                {
                    index = i;
                    break;
                }

            if (index >= 0)
                AllJobs.RemoveAt(index);
        }
        internal Job Find(string jobId)
        {
            Job tempJob = null;
            foreach (Job job in AllJobs)
                if (job.Id == jobId)
                {
                    tempJob = job;
                    break;
                }
            return tempJob;
        }
        internal void Update(Job job)
        {
            for (int i = 0; i < AllJobs.Count; i++)
                if (AllJobs[i].Id == job.Id)
                {
                    AllJobs[i] = job;
                    break;
                }
        }
        internal bool IsWaiting()
        {
            bool isWaiting = false;
            foreach (Job job in AllJobs)
                if (job.Status == JobStatus.WAITING)
                {
                    isWaiting = true;
                    break;
                }
            return isWaiting;
        }
    }
}
