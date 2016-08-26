using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessSolution.FileHandlingClient.FileHandlerServiceReference;

namespace DataProcessSolution.FileHandlingClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileHandlerServiceClient client = new FileHandlerServiceClient("WSHttpBinding_IFileHandlerService1");
            ProcessedFile file = new ProcessedFile()
            {
                Name = "someFile",
                BlobReference = "someReference"
            };

            Console.WriteLine(client.ProcessFile(file));
            Console.ReadLine();
        }
    }
}
