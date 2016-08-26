using System.ServiceModel;

namespace DataProcessSolution.FileHandlingService
{
    [ServiceContract]
    public interface IFileHandlerService
    {
        [OperationContract]
        string ProcessFile(ProcessedFile processedFile);
    }
}
