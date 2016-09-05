namespace DataProcessSolution.DAL
{
    using System.Data.Entity;

    public partial class JobContext : DbContext
    {
        public JobContext()
            : base("name=JobModel")
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
