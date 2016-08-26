using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using EvalServiceLibrary.Interfaces;

namespace EvalServiceLibrary.ConsoleHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            //construct service host
            //ServiceHost host = new ServiceHost(typeof(EvalService));

            //configure endpoints, moved to config file
            /**
            host.AddServiceEndpoint(typeof(IEvalService),
                new BasicHttpBinding(),
                "http://localhost:8080/evals/basic"
                );

            host.AddServiceEndpoint(typeof(IEvalService),
                new WSHttpBinding(), 
                "http://localhost:8080/evals/ws"
                );

            host.AddServiceEndpoint(typeof(IEvalService),
                new NetTcpBinding(), 
                "net.tcp://localhost:8081/evals"
                );
    **/
            /**try
            {
                //magic code
                host.Open();
                PrintServiceInfo(host);
                Console.ReadLine();
                host.Close();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
                Console.ReadLine();
                host.Abort();
            }**/
            //Configuring WCF services for REST
            /**ServiceHost host = new ServiceHost(typeof(EvalService),
                new Uri("http://localhost:8080/evals"));
            host.AddServiceEndpoint(typeof(IEval),
               new WebHttpBinding(),
               "");
            host.Description.Endpoints[0].Behaviors.Add(
                new WebHttpBehavior()
                );

            host.Open();
            Console.ReadLine();**/
            WebServiceHost host = new WebServiceHost(
                typeof(EvalService),
                new Uri("http://localhost:8080/evals")
                );
            host.Open();
            Console.ReadLine();
        }

        static void PrintServiceInfo(ServiceHost host)
        {
            Console.Out.WriteLine($"{host.Description.ServiceType} is running with " +
                                  $"the following endpoints:");

            foreach (var endpoint in host.Description.Endpoints)
            {
                Console.Out.WriteLine(endpoint.Address);
            }
        }
    }
}
