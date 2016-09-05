namespace DataProcessSolution.SharedObjects
{
    public class JobReference
    {
        public string ClientId { get; set; }
        public FileReference NamesFileReference { get; set; }
        public FileReference AddressFileReference { get; set; }
        public FileReference OrdersFileReference { get; set; }
        public FileReference ItemsFileReference { get; set; }
    }
}
