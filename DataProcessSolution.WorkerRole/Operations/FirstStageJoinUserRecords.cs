using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;

namespace DataProcessSolution.WorkerRole.Operations
{
    public class FirstStageJoinUserRecords:JoinOperation
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
