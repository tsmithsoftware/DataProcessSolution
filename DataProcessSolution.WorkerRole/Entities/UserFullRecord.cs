using FileHelpers;

namespace DataProcessSolution.WorkerRole.Entities
{
    [DelimitedRecord(",")]
    public class UserFullRecord
    {
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserOrder { get; set; }
    }
}
