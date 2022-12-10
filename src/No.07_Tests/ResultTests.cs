using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using No._07;

namespace No._07_Tests
{
    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void resultPart1()
        {
            List<string> data = File.ReadAllText("content.txt")
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();

            const int EXPECTED_SIZE = 95437;

            Calculator calc = new Calculator(data);

            Assert.AreEqual(EXPECTED_SIZE, calc.sizeOfDirsWithContentBelow(100_000));
        }
    }
}