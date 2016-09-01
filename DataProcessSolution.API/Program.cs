using System;
using System.Xml.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DataProcessSolution.API.Backend;
using DataProcessSolution.API.Backend.Utilities;
using DataProcessSolution.API.Frontend.Implementations;
using DataProcessSolution.API.Frontend.Interfaces;
using Microsoft.AspNet.SignalR.Client;
using DataProcessSolution.SharedObjects;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace DataProcessSolution.API.Frontend
{
    public class Program
    {
        private static readonly string BlobContainerName = ConfigurationManager.AppSettings["AzureContainerName"];
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
            //SignalR server application
            CallServerSideApplication(name,addresses,orders);
        }

        private static void CallServerSideApplication(string name, string addresses, string orders)
        {
            IHubProxy _hub;
            string url = @"http://localhost:8080/";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("SignalRHub");
            connection.Start().Wait();
            JobReference job = new JobReference()
            {
                NamesFileReference = new FileReference()
                {
                    BlockId = Guid.NewGuid().ToString(),
                    ContainerName = BlobContainerName,
                    Name = name
                },
                AddressFileReference = new FileReference()
                {
                    BlockId = Guid.NewGuid().ToString(),
                    ContainerName = BlobContainerName,
                    Name = addresses
                },
                OrdersFileReference = new FileReference()
                {
                    BlockId = Guid.NewGuid().ToString(),
                    ContainerName = BlobContainerName,
                    Name = orders
                }
            };
                Task task = _hub.Invoke<FileReference>("ProcessFile", job)
                    .ContinueWith(ProcessTask);
            }

        private static void ProcessTask(Task<FileReference> tsk)
        {
            FileReference returnedFile = tsk.Result;
            Console.WriteLine($"File Name from server: {returnedFile.Name}");
        }
    }
}
