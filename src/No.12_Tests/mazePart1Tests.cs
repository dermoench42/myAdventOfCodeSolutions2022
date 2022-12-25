// (c) 2022 Ervin Peters (coder@ervnet.de)

using System.IO;
using System.Linq;

using No._12;

namespace No._12_Tests
{
    using Xunit;

    public class MazePart1Tests
    {
        [Fact]
        public void findTestPathSteps()
        {
            string[] topoData = File.ReadAllText("testContent.txt")
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row)).ToArray();

            MazePart1 mazePart1 = new(topoData);

            uint result = mazePart1.findPath();

            Assert.Equal(31u, result);
        }
    }
}