using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessSolution.WorkerRole.Entities;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Files;
using Rhino.Etl.Core.Operations;

namespace DataProcessSolution.WorkerRole.Operations
{
        public class UserNameRead : AbstractOperation
        {
            public UserNameRead(string filePath)
            {
            if (!File.Exists(filePath)) throw new FileNotFoundException("There is no file at this location.");
            FilePath = filePath;
            }

            public string FilePath { get; set; }

            public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
            {
                using (FileEngine file = FluentFile.For<UserNameRecord>().From(FilePath))
                {
                    foreach (object obj in file)
                    {
                        yield return Row.FromObject(obj);
                    }
                }
            }
        }
    }
