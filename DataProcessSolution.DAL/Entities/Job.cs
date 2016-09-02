using System;
namespace DataProcessSolution.DAL.Entities
{
    public class Job
    {
        public string JobId { get; set; }
        public string ClientId { get; set; }
        public DateTime LastUpdated { get; set; }
        public Status Status { get; set; } 
    }
}
