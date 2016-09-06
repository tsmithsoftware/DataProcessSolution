using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Threading.Tasks;
using DataProcessSolution.FileHandlingService;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;

namespace WCFWorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent _runCompleteEvent = new ManualResetEvent(false);
        private ServiceHost _serviceHost;

        public override void Run()
        {
            Trace.TraceInformation("WCFWorkerRole is running");

            try
            {
                this.RunAsync(this._cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this._runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();
            Trace.TraceInformation("WCFWorkerRole has been started");
            try
            {
                Trace.TraceInformation("Creating WCF Host...");
                CreateServiceHost();
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
            }
            Trace.TraceInformation("WCF Host Created.");
            return result;
        }

        //http://www.codeproject.com/Articles/188464/Host-WCF-Services-in-an-Azure-Worker-Role
        private void CreateServiceHost()
        {
            ServicePointManager.DefaultConnectionLimit = 12;
            _serviceHost = new ServiceHost(typeof(FileHandlerService));

            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            RoleInstanceEndpoint externalEndPoint =
                RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["WCFEndpoint"];
            string endpoint = $"net.tcp://{externalEndPoint.IPEndpoint}/FileProcessingService";

            Trace.TraceInformation($"Service endpoint running at {endpoint}");

            _serviceHost.AddServiceEndpoint(typeof(IFileHandlerService), binding, endpoint);
            
            Trace.TraceInformation("Opening host...");

            _serviceHost.Open();
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WCFWorkerRole is stopping");

            this._cancellationTokenSource.Cancel();
            this._runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WCFWorkerRole has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                await Task.Delay(1000);
            }
        }
    }
}
