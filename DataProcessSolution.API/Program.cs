using System;
using DataProcessSolution.API.Backend;
using DataProcessSolution.API.Backend.Utilities;

namespace DataProcessSolution.API.Frontend
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.Out.WriteLine("Please enter the file location for the Names file: ");
            name = Console.ReadLine();
            string addresses;
            Console.Out.WriteLine("Please enter the file location for the Addresses file: ");
            addresses = Console.ReadLine();
            Console.Out.WriteLine("Please enter the file location for the Orders file: ");
            string orders = Console.ReadLine();
            Console.Out.WriteLine("Uploading blobs");
            BlobStorageHandler blobHandler = new BlobStorageHandler(new FileHandler());
            var savedBlobFileNames = blobHandler.UploadBlobs(name, addresses, orders);
            Console.Out.WriteLine(savedBlobFileNames);
            ServiceHandler serviceHandler = new ServiceHandler();
            serviceHandler.CallService(savedBlobFileNames);
        }
    }
}
