using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessSolution.SharedObjects
{
    public class JobReference
    {
        public FileReference NamesFileReference { get; set; }
        public FileReference AddressFileReference { get; set; }
        public FileReference OrdersFileReference { get; set; }
    }
}
