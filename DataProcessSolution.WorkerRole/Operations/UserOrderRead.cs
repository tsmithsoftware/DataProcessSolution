using System.Collections.Generic;
using System.IO;
using DataProcessSolution.WorkerRole.Entities;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Files;
using Rhino.Etl.Core.Operations;

namespace DataProcessSolution.WorkerRole.Operations
{
    public class UserOrderRead:AbstractOperation
    {
        public UserOrderRead(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("There is no file at this location.");
            FilePath = filePath;
        }

        public string FilePath { get; set; }
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            using (FileEngine file = FluentFile.For<UserOrderRecord>().From(FilePath))
            {
                foreach (object obj in file)
                {
                    yield return Row.FromObject(obj);
                }
            }
        }
    }
}
