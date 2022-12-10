using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using No._05;

namespace No._05_Tests
{
    [TestClass]
    public class EndresultTests
    {
        readonly List<string> data = File.ReadAllText("content.txt")
            .Split("\n\n")
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();

        [TestMethod]
        public void endresultPart1_Test()
        {
            const string EXPECTED = "CMZ";

            Assert.AreEqual(EXPECTED, Calculator.calc(this.data[0], this.data[1]));
        }

        [TestMethod]
        public void endresultPart2_Test()
        {
            const string EXPECTED = "MCD";

            Assert.AreEqual(EXPECTED, Calculator.calc2(this.data[0], this.data[1]));
        }
    }
}