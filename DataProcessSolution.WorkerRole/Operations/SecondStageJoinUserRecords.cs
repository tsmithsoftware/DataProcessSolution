using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;

namespace DataProcessSolution.WorkerRole.Operations
{
    //take output of JoinUserRecords and join with Orders file
    public class SecondStageJoinUserRecords:JoinOperation
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

            row["Order"] = rightRow["Order"];

            return row;
        }
    }
}
