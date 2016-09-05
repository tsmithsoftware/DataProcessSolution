using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataProcessSolution.DAL;

namespace DataProcessSolution.Tests.DAL
{
    [TestClass]
    public class ContextTest
    {
        [TestMethod]
        public void TestConnectionSucceeds()
        {
            using (var db = new JobContext())
            {
                var query = from b in db.JobTables
                            orderby b.JobId
                            select b;

                Assert.IsTrue(query.ToList().Count>0);
            }
        }
    }
}
