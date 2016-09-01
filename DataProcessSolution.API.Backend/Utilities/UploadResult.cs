using DataProcessSolution.SharedObjects;

namespace DataProcessSolution.API.Backend.Utilities
{
    public class UploadResult
    {
        public FileReference UploadedFile { get; set; }
        public bool Result { get; set; }
        public UploadResult(bool result,FileReference uploadedFile)
        {
            UploadedFile = uploadedFile;
            Result = result;
        }
    }
}
