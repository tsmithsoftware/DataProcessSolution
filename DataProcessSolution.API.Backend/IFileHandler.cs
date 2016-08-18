using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessSolution.API.Backend
{
    public interface IFileHandler
    {
        FileInfo GetFileFromString(string location);
    }
}
