using System.ServiceModel;
using DataProcessSolution.SharedObjects;

namespace DataProcessSolution.FileHandlingService
{
    [ServiceContract]
    public interface IFileHandlerService
    {
        [OperationContract]
        FileReference ProcessFile(JobReference job,string connectionId);
    }
}
