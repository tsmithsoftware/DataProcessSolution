using System;
using System.Configuration;
using DataProcessSolution.WorkerRole.Processes;

namespace DataProcessSolution.WorkerRole
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainProcess process = new MainProcess();
            process.NamesFile = ConfigurationManager.AppSettings["NamesFileLocation"];
            process.AddressesFile = ConfigurationManager.AppSettings["AddressesFileLocation"];
            process.OrdersFile = ConfigurationManager.AppSettings["OrdersFileLocation"];
            process.FirstStageOutputFile = ConfigurationManager.AppSettings["OutputFileLocation"];

            process.Execute();
        }
    }
}
