using System.Runtime.Serialization;
using System.ServiceModel;

namespace DataProcessSolution.FileHandlingService
{
    [ServiceContract]
    public class FileHandlerService:IFileHandlerService
    {
        [OperationContract]
        public string ProcessFile(ProcessedFile processedFile)
        {
            return $"File name {processedFile.Name} at location {processedFile.BlobReference} processed.";
        }
    }
}
