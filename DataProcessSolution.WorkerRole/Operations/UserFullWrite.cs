using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessSolution.WorkerRole.Entities;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Files;
using Rhino.Etl.Core.Operations;

namespace DataProcessSolution.WorkerRole.Operations
{
    public class UserFullWrite:AbstractOperation
    {
        public string FilePath { get; set; }
        public UserFullWrite(string path)
        {
            FilePath = path;
        }
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            FluentFile engine = FluentFile.For<UserFullRecord>();
            engine.HeaderText = "Id\tName\tAddress";
            using (FileEngine file = engine.To(FilePath))
            {
                foreach (Row row in rows)
                {
                    file.Write(row.ToObject<UserFullRecord>());
                    
                    //pass through rows to next step if needed
                    yield return row;
                }
            }
        }
    }
}
