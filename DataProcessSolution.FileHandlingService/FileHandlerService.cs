using System;
using DataProcessSolution.SharedObjects;
using System.ServiceModel;
using DataProcessSolution.DAL;
using DataProcessSolution.DAL.Entities;

namespace DataProcessSolution.FileHandlingService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class FileHandlerService:IFileHandlerService
    {
        private JobContext Context { get; set; }
        public JobContext _context
        {
            get
            {
                if (Context != null) return Context;
                return new JobContext();
            }
            set { Context = value; }
        }

        public string ProcessFile(ProcessedFile processedFile)
        {
            return $"File name {processedFile.Name} at location {processedFile.BlobReference} processed.";
        }

        public FileReference ProcessFile(JobReference job,string connectionId)
        {
            using (_context)
            {
                //Update Status database with new job information
                _context.JobTables.Add(new JobTable()
                {
                    ClientId = Int32.Parse(connectionId),
                    Status = Status.Started
                });
                _context.SaveChanges();
            }
            //Pass job through to queue (serialise job - string properties)
            return null;
        }
    }
}
