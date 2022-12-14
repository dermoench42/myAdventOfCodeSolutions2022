using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using No._08;

namespace No._08_Tests
{
    [TestClass]
    public class ResultTests
    {
        [DataTestMethod]
        [DataRow("testContent.txt",21)]
        [DataRow("testContent0.txt",25)]
        [DataRow("testContent1.txt",16)]
        [DataRow("testContent2.txt",24)]
        [DataRow("testContent3.txt",24)]
        public void Part1( string fn, int expected)
        {
            List<string> data = File.ReadAllText(fn)
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();

            Checker checker = new Checker(data);

            int visibleTrees = checker.countVisibleTrees();

            Assert.AreEqual(expected, visibleTrees);
        }

        [DataTestMethod]
        [DataRow("testContent.txt",8)]
        [DataRow("testContent0.txt",16)]
        [DataRow("testContent1.txt",1)]
        [DataRow("testContent2.txt",2)]
        [DataRow("testContent3.txt",1)]
        public void Part2(string fn, int expected)
        {
            List<string> data = File.ReadAllText(fn)
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();

            int maxScenic = Checker.calcMaxScenic(data);

            Assert.AreEqual(expected, maxScenic);
        }

    }
}