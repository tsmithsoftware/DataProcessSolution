using DataProcessSolution.SharedObjects;
using System.ServiceModel;

namespace DataProcessSolution.FileHandlingService
{
    [ServiceContract]
    public class FileHandlerService:IFileHandlerService
    {
        [OperationContract]
        public string ProcessFile(ProcessedFile processedFile)
        {
            //Update Status database with new job information
            //Pass job through to queue (serialise job - string properties)
            return $"File name {processedFile.Name} at location {processedFile.BlobReference} processed.";
        }

        //POC - need to look at how to pass back object
       // [OperationContract]
        public FileReference ProcessFile(JobReference job)
        {
            return null;
        }
    }
}
