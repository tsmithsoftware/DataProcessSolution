using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DataProcessSolution.WorkerRole.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Etl.Core;
using Assert = NUnit.Framework.Assert;

namespace DataProcessSolution.Tests.WorkerRoleTests
{
    [TestFixture]
    [DeploymentItem(@".\TestFiles\Addresses.csv")]
    [DeploymentItem(@".\TestFiles\Names.csv")]
    [DeploymentItem(@".\TestFiles\Orders.csv")]
    public class UserAddressReadTests
    {
        [Test]
        public void TestUserAddressReadCanReadRecords()
        {
            UserAddressRead read = new UserAddressRead(AppDomain.CurrentDomain.BaseDirectory + "\\TestFiles\\Addresses.csv");
            var result = read.Execute(null);
            List<Row> extractedRows = result.ToList();
            Assert.IsTrue(extractedRows.Count == 3);
            Assert.IsTrue(extractedRows[0]["Id"].Equals(1));
            Assert.IsTrue(extractedRows[0]["Address"].Equals(" 34 Viscount Road"));
        }

        [Test]
        public void TestUserNameReadCanReadRecords()
        {
            UserNameRead read = new UserNameRead(AppDomain.CurrentDomain.BaseDirectory + "\\TestFiles\\Names.csv");
            var result = read.Execute(null);
            List<Row> extractedRows = result.ToList();
            Assert.IsTrue(extractedRows.Count == 3);
            Assert.IsTrue(extractedRows[0]["Id"].Equals(1));
            Assert.IsTrue(extractedRows[0]["FirstName"].Equals("Timothy"));
            Assert.IsTrue(extractedRows[0]["LastName"].Equals("Smith"));
        }

        [Test]
        public void TestUserOrderReadCanReadRecords()
        {
            UserOrderRead read = new UserOrderRead(AppDomain.CurrentDomain.BaseDirectory + "\\TestFiles\\Orders.csv");
            var result = read.Execute(null);
            List<Row> extractedRows = result.ToList();
            Assert.IsTrue(extractedRows.Count == 2);
            Assert.IsTrue(extractedRows[1]["Id"].Equals(2));
            Assert.IsTrue(extractedRows[1]["Order"].Equals(" An actual puppy"));

        }
    }
}
