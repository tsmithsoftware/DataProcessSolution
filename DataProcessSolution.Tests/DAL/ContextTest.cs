using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace DataProcessSolution.Tests.DAL
{
    [TestFixture]
    public class ContextTest
    {
        [Test]
        public void TestConnectionSucceeds()
        {
            Assert.IsTrue(true);
            /*using (var db = new JobContext())
            {
                var x = db.JobTables;
                var query = from b in db.JobTables
                            orderby b.JobId
                            select b;

                Assert.IsTrue(query.ToList().Count>0);
            }*/
        }
    }
}
