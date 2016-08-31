using System;
using System.Collections.Generic;
using System.Linq;
using DataProcessSolution.DAL.Entities;

namespace DataProcessSolution.DAL.Interfaces
{
    public interface IDatabaseInteractions
    {
        bool CreateNewJob(Job job);
        bool UpdateJob(Job job);
        bool DeleteJob(Job job);
        void GetJob(String jobId);
    }
}
