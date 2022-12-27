// (c) 2022 Ervin Peters (coder@ervnet.de)

using System.IO;
using System.Linq;

using No._15;

using Xunit;

namespace No._15_Tests
{
    public class BeaconInAreaTests
    {
        [Theory]
        [InlineData("testSensorData.txt", 26)]
        //[InlineData("sensorData.txt", 0)]
        public void testEndresult(string fileName, int expected)
        {
            Area area = new(File.ReadLines(fileName).ToList());

            long cntPositions = area.cntPositionsWithNoBeacon(10);

            Assert.Equal(expected, cntPositions);
        }
    }
}