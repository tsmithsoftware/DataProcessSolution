using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessSolution.API.Frontend.Interfaces;

namespace DataProcessSolution.API.Frontend.Implementations
{
    public class ConsoleUserInterface:IUserInterface
    {
        public string GetFileLocationForNamesFile()
        {
            return PrintOutputAndReturnInput("Please enter the file location for the Names file: ");
        }

        public string GetFileLocationForAddressesFile()
        {
            return PrintOutputAndReturnInput("Please enter the file location for the Addresses file: ");
        }

        public string GetFileLocationForOrdersFile()
        {
            return PrintOutputAndReturnInput("Please enter the file location for the Orders file: ");
        }

        public void WriteOutput(string output)
        {
            Console.Out.WriteLine(output);
        }

        private string PrintOutputAndReturnInput(string output)
        {
            Console.Out.WriteLine(output);
            return Console.ReadLine();
        }
    }
}
