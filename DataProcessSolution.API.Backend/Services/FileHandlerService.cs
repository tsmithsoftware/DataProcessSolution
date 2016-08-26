using DataProcessSolution.API.Backend.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessSolution.API.Backend.Services
{
    [ServiceContract]
    public interface IFileHandlerService
    {
        [OperationContract]
        string ProcessFile(ProcessedFile processedFile);
    }
    public class FileHandlerService : IFileHandlerService
    {
        public string ProcessFile(ProcessedFile processedFile)
        {
            return $"File name {processedFile.Name} at location {processedFile.BlobReference} processed.";
        }
    }
}
