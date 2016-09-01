using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using DataProcessSolution.SharedObjects;

namespace DataProcessSolution.SignalR.Server
{
    public class SignalRHub : Hub
    {
        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

        public void Hello()
        {
            Clients.All.GetType();
        }

        public void DetermineLength(string message)
        {

            Console.WriteLine($"Processing message on server...");
            Clients.Caller.ReceiveLength(message);
        }

        public FileReference ProcessFile(JobReference file)
        {
            Console.WriteLine($"Doing something with the file " +
                              $"{file.AddressFileReference.Name} in container {file.AddressFileReference.ContainerName}");
            Thread.Sleep(1000);
            Console.WriteLine("Finished processing");
            return new FileReference()
            {
                Name = "SomeProcessedFile",
                BlockId = "BlockId",
                ContainerName = "djksaol"
            };
        }
    }
}
