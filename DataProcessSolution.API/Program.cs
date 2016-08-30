using System;
using System.Xml.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DataProcessSolution.API.Backend;
using DataProcessSolution.API.Backend.Utilities;
using DataProcessSolution.API.Frontend.Implementations;
using DataProcessSolution.API.Frontend.Interfaces;

namespace DataProcessSolution.API.Frontend
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IUserInterface>().ImplementedBy<ConsoleUserInterface>());
            var userInterface = container.Resolve<IUserInterface>();
            
            string name = userInterface.GetFileLocationForNamesFile();
            string addresses = userInterface.GetFileLocationForAddressesFile();
            string orders = userInterface.GetFileLocationForOrdersFile();

            userInterface.WriteOutput("Uploading blobs");
            BlobStorageHandler blobHandler = new BlobStorageHandler(new FileHandler());
            var savedBlobFileNames = blobHandler.UploadBlobs(name, addresses, orders);
            Console.Out.WriteLine(savedBlobFileNames);
            ServiceHandler serviceHandler = new ServiceHandler();
            serviceHandler.CallService(savedBlobFileNames);
        }
    }
}
