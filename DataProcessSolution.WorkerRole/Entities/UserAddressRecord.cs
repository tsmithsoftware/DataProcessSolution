namespace DataProcessSolution.WorkerRole.Entities
{
    using FileHelpers;
    [DelimitedRecord(","), IgnoreFirst]
    public class UserAddressRecord
    {
        public int Id { get; set; }
        public string Address { get; set; }
    }
}
