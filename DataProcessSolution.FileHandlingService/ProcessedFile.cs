using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
