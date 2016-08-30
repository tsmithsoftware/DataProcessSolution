using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessSolution.WorkerRole.Entities;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Files;
using Rhino.Etl.Core.Operations;
using System.IO;

namespace DataProcessSolution.WorkerRole.Operations
{
    public class UserAddressRead:AbstractOperation
    {
        public UserAddressRead(string FilePath)
        {
            if(!File.Exists(FilePath)) throw new FileNotFoundException("There is no file at this location.");
            this.FilePath = FilePath;
        }
        public string FilePath { get; set; }
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            using (FileEngine file = FluentFile.For<UserAddressRecord>().From(FilePath))
            {
                foreach (object record in file)
                {
                    yield return Row.FromObject(record);
                }
            }
        }
    }
}
