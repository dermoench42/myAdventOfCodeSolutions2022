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
        public void rootSize()
        {
            List<string> data = File.ReadAllText("testContent.txt")
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();

            const int EXPECTED_SIZE = 48381165;

            Calculator calc = new Calculator(data);

            Assert.AreEqual(EXPECTED_SIZE, calc.rootDirSize());
        }

        [TestMethod]
        public void resultPart1()
        {
            List<string> data = File.ReadAllText("testContent.txt")
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();

            const int EXPECTED_SIZE = 95437;

            Calculator calc = new Calculator(data);

            Assert.AreEqual(EXPECTED_SIZE, calc.sizeOfDirsWithContentBelow(100_000));
        }

        [TestMethod]
        public void resultPart2()
        {
            List<string> data = File.ReadAllText("testContent.txt")
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();
            const long FS_SIZE = 70000000;
            const long NEEDED_FREE_SPACE = 30000000;

            Calculator calc = new Calculator(data);
            long usedSpace = calc.rootDirSize();

            long needToFree = usedSpace - (FS_SIZE - NEEDED_FREE_SPACE);

            const int EXPECTED_SIZE = 24933642;

            Assert.AreEqual(EXPECTED_SIZE, calc.findSmallestDirAboveSize(needToFree));

        }
    }
}