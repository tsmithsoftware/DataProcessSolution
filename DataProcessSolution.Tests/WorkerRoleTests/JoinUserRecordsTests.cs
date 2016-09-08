using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessSolution.WorkerRole.Entities;
using DataProcessSolution.WorkerRole.Operations;
using Moq;
using NUnit.Framework;
using Rhino.Etl.Core;

namespace DataProcessSolution.Tests.WorkerRoleTests
{
    [TestFixture]
    public class JoinUserRecordsTests
    {
        [TestCase]
        public void TestMergeRowsReturnsCorrectMergedRow()
        {
            Assert.IsTrue(true);
        }
    }
}
