using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters;

namespace DataProcessSolution.API.Frontend.Interfaces
{
    public interface IUserInterface
    {
        String GetFileLocationForNamesFile();
        String GetFileLocationForAddressesFile();
        String GetFileLocationForOrdersFile();
        void WriteOutput(string output);
    }
}
