using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;

namespace DataProcessSolution.WorkerRole.Operations
{
    public class JoinUserRecords:JoinOperation
    {
        protected override void SetupJoinConditions()
        {
            InnerJoin
                .Left("Id")
                .Right("Id");
        }
        protected override Row MergeRows(Row leftRow, Row rightRow)
        {
            Row row = new Row();
            row.Copy(leftRow);

            row["Address"] = rightRow["Address"];

            return row;
        }
    }
}
