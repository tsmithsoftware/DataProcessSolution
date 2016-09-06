namespace DataProcessSolution.DAL
{
    using System.Data.Entity;

    public partial class JobContext : DbContext
    {
        public JobContext()
            : base("Data Source=dataprocessing.database.windows.net;Initial Catalog=DataProcessingDatabase;persist security info=True;user id=useradmin;password=Jacky007;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<JobTable> JobTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTable>()
                .Property(e => e.Status);
        }
    }
}
