using System.ServiceModel;
using DataProcessSolution.SharedObjects;

namespace DataProcessSolution.FileHandlingService
{
    [ServiceContract]
    public interface IFileHandlerService
    {
        [OperationContract]
        //string ProcessFile(ProcessedFile processedFile);
        FileReference ProcessFile(JobReference job);
    }
}
