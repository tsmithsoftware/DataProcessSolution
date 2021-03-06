﻿using System.Collections.Generic;
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
                    UserFullRecord record = new UserFullRecord()
                    {
                        UserName = $"{row["UserName"]}",
                        UserAddress = $"{row["UserAddress"]}",
                        UserOrder = $"{row["UserOrder"]}"
                    };

                    file.Write(record);
                    yield return row;
                }
            }
        }
    }
}
