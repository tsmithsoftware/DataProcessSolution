using System.Collections.Generic;
using DataProcessSolution.WorkerRole.Entities;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Files;
using Rhino.Etl.Core.Operations;

namespace DataProcessSolution.WorkerRole.Operations
{
    public class FirstStageUserFullWrite:AbstractOperation
    {
        public string FilePath { get; set; }
        public FirstStageUserFullWrite(string path)
        {
            FilePath = path;
        }
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            FluentFile engine = FluentFile.For<UserFullRecord>();
            engine.HeaderText = "Name,Address,Order";
            using (FileEngine file = engine.To(FilePath))
            {
                foreach (Row row in rows)
                {
                    //var testObject = row.ToObject<UserFullRecord>();
                    //file.Write(testObject);
                    UserFullRecord record = new UserFullRecord()
                    {
                        UserName = $"{row["FirstName"]} {row["LastName"]}",
                        UserAddress = $"{row["Address"]}",
                        UserOrder = $"{row["Order"]}"
                    };

                    file.Write(record);
                    //pass through rows to next step if needed
                    yield return row;
                }
            }
        }
    }
}
