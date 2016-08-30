
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DataProcessSolution.Tests.WorkerRoleTests
{
    [TestFixture]
    public class NumberGeneratorTests
    {
        private class NumberGen
        {
            public int NumberGenerated { get; set; }

            public IEnumerable<int> GenerateNumbers()
            {
                for (int i = 0; i < 10; i++)
                {
                    NumberGenerated++;
                    yield return i;
                }
            }
        }

        [Test]
        public void TestNumbersGeneratedSuccessfully()
        {
            var generator = new NumberGen();
            generator.GenerateNumbers();
            Assert.AreEqual(0,generator.NumberGenerated);
        }

        [Test]
        public void TestFiveNumbersGeneratedSuccessfully()
        {
            var generator = new NumberGen();
            foreach(int num in generator.GenerateNumbers())
            {
                if (num == 5) break;
            }
            Assert.AreEqual(6, generator.NumberGenerated);
        }
    }
}
