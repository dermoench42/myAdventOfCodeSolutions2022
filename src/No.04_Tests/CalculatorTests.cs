using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using No._04;

namespace No._4_Tests
{
    [TestClass]
    public class CalculatorTests
    {
        readonly List<string> data = File.ReadAllText("testContent.txt")
            .Split("\n")
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();

        [TestMethod]
        public void endresultTest()
        {
            const int EXPECTED = 2;

            Assert.AreEqual(EXPECTED, Calculator.calc(this.data));
        }

        [TestMethod]
        public void endresult2Test()
        {
            const int EXPECTED = 4;

            Assert.AreEqual(EXPECTED, Calculator.calc2(this.data));
        }
    }
}