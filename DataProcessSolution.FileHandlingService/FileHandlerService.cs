using System.Runtime.Serialization;
using System.ServiceModel;

namespace DataProcessSolution.FileHandlingService
{
    [ServiceContract]
    public interface IFileHandlerService
    {
        [OperationContract]
        string ProcessFile(ProcessedFile processedFile);
    }
    public class FileHandlerService:IFileHandlerService
    {
        public string ProcessFile(ProcessedFile processedFile)
        {
            return $"File name {processedFile.Name} at location {processedFile.BlobReference} processed.";
        }
    }
}
