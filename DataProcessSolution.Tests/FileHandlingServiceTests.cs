using System.Data.Entity;
using DataProcessSolution.DAL;
using DataProcessSolution.FileHandlingService;
using DataProcessSolution.SharedObjects;
using Moq;
using NUnit.Framework;

namespace DataProcessSolution.Tests
{
    [TestFixture]
    public class FileHandlingServiceTests
    {
        [Test]
        public void TestProcessFileAddsNewJobToContext()
        {
            Mock<JobContext> mockContext = new Mock<JobContext>();
            Mock<DbSet<JobTable>> mockTable = new Mock<DbSet<JobTable>>();
            mockContext.Setup(x => x.JobTables).Returns(mockTable.Object);
            mockTable.Setup(x => x.Add(It.IsAny<JobTable>()));

            Mock<JobReference> job = new Mock<JobReference>();

            FileHandlerService service = new FileHandlerService()
            {
                _context = mockContext.Object
            };

            service.ProcessFile(job.Object,"1");

            mockTable.Verify(x=>x.Add(It.IsAny<JobTable>()));
        }
    }
}
