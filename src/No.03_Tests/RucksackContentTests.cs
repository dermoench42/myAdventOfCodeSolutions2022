using System.IO;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using No._03;

namespace No._03_Tests
{
    [TestClass]
    public class RucksackContentTests
    {
        private readonly string[] testContent =
            File.ReadAllText("exampleContents.txt")
                .Split("\n");

        private readonly int[] expected = new[] { 16, 38, 42, 22, 20, 19, 0 };

        private const int EXPECTED_SUM = 157;

        [TestMethod]
        public void singleTest()
        {
            int sum = 0;
            for (int itemNo = 0; itemNo < this.testContent.Length; itemNo++)
            {
                int result = (new RucksackContent(this.testContent[itemNo]))
                    .calcPrio();
                Assert.AreEqual(this.expected[itemNo], result);
                sum += result;
            }

            Assert.AreEqual(EXPECTED_SUM, sum);
        }

        [TestMethod]
        public void groupTest()
        {
            BadgeFinder bf = new(this.testContent
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList());
            Assert.AreEqual(70, bf.calcPrio());
        }
    }
}