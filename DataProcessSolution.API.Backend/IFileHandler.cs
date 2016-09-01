using System.IO;

namespace DataProcessSolution.API.Backend
{
    public interface IFileHandler
    {
        FileInfo GetFileFromString(string location);
    }
}
