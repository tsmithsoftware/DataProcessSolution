namespace DataProcessSolution.API.Backend.Utilities
{
    public class UploadResult
    {
        public string UploadedFile { get; set; }
        public bool Result { get; set; }
        public UploadResult(bool result,string uploadedFile)
        {
            this.UploadedFile = uploadedFile;
            this.Result = result;
        }
    }
}
