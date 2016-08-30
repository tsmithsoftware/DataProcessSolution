using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessSolution.WorkerRole.Entities
{
    using FileHelpers;
    [DelimitedRecord(","), IgnoreFirst]
    public class UserOrderRecord
    {
        public int Id { get; set; }
        public string Order { get; set; }
    }
}
