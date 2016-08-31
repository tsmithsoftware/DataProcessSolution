using System.Runtime.Serialization;

namespace DataProcessSolution.FileHandlingService
{
    [DataContract]
    public class ProcessedFile
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string BlobReference { get; set; }
    }
}
