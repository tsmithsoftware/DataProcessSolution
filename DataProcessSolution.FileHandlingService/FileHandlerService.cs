using DataProcessSolution.SharedObjects;
using System.ServiceModel;

namespace DataProcessSolution.FileHandlingService
{
    [ServiceContract]
    public class FileHandlerService:IFileHandlerService
    {
        public string ProcessFile(ProcessedFile processedFile)
        {
            return $"File name {processedFile.Name} at location {processedFile.BlobReference} processed.";
        }

        [OperationContract]
        public FileReference ProcessFile(JobReference job)
        {
            //Update Status database with new job information
            //Pass job through to queue (serialise job - string properties)
            return null;
        }
    }
}
