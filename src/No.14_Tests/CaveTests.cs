using System.Collections.Generic;
using System.IO;
using System.Linq;

using No._14;

using Xunit;

namespace No._14_Tests
{
    public class CaveTests
    {
        [Fact]
        public void part1Endresult()
        {
            Cave cave = new(File.ReadLines("testCaveData.txt").ToList());
            int result = cave.letItFall();
            Assert.Equal(24,result);
        }

        [Fact]
        public void part2Endresult()
        {
            Cave cave = new(File.ReadLines("testCaveData.txt").ToList(), true);
            int result = cave.letItFall2();
            Assert.Equal(93,result);
        }

        [Theory]
        [InlineData("499,2 -> 499,3", 0)]
        [InlineData("500,2 -> 500,3", 0)]
        [InlineData("499,2 -> 501,2", 1)]
        [InlineData("499,1 -> 501,1", 1)]
        [InlineData("499,2 -> 499,3 -> 501,3 -> 501,2", 2)]
        [InlineData("499,2 -> 499,4 -> 501,4 -> 501,3", 2)]
        [InlineData("499,3 -> 499,4 -> 501,4 -> 501,2", 2)]
        public void testTheAbyss(string wallPath, int expected)
        {
            Cave cave = new(new List<string>() { wallPath });
            int result = cave.letItFall();
            Assert.Equal(expected,result);
        }
    }
}