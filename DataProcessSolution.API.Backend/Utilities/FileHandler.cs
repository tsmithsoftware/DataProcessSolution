using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessSolution.API.Backend.Utilities
{
    public class FileHandler:IFileHandler
    {
        public FileInfo GetFileFromString(string location)
        {
            return new FileInfo(location);
        }
    }
}
