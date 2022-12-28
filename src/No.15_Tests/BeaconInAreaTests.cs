// (c) 2022 Ervin Peters (coder@ervnet.de)

using System.Collections.Generic;
using System.IO;
using System.Linq;

using No._15;

using Xunit;

namespace No._15_Tests
{
    public class BeaconInAreaTests
    {
        [Theory]
        [InlineData("testSensorData.txt", 10, 26)]
        [InlineData("sensorData.txt", 2000000, 4879972)]
        public void endresultPart1(string fileName, int row, int expected)
        {
            Area area = new(File.ReadLines(fileName).ToList());

            long cntPositions = area.cntPositionsWithNoBeacon(row);

            Assert.Equal(expected, cntPositions);
        }

        [Theory]
        [InlineData("testSensorData.txt", 20, 56000011)]
        [InlineData("sensorData.txt", 4000000, 12525726647448)]
        public void endresultPart2(string fileName, int size, long expected)
        {
            Area area = new(File.ReadLines(fileName).ToList());

            long cntPositions = area.calcFrequency(size);

            Assert.Equal(expected, cntPositions);
        }

        [Theory]
        [InlineData("Sensor at x=2, y=18: closest beacon is at x=-2, y=15", "", 2, 18, -2, 15, 7)]
        [InlineData("Sensor at x=8, y=7: closest beacon is at x=2, y=10", "", 8, 7, 2, 10, 9)]
        public void testReadSensors(string line1, string line2, int x1, int y1, int x2, int y2, int dist)
        {
            Area area = new(new List<string>() { line1, line2 });
            SensorBeacon sensorBeacon = area.sensorBeacons[0];
            Assert.Equal(x1, sensorBeacon.sensorPosition.x);
            Assert.Equal(y1, sensorBeacon.sensorPosition.y);
            Assert.Equal(x2, sensorBeacon.beaconPosition.x);
            Assert.Equal(y2, sensorBeacon.beaconPosition.y);
            Assert.Equal(dist, sensorBeacon.manhattenRadius);
        }

        [Theory]
        // ...#...
        // ..#SB..
        // ...#..  ...Beacons are not included
        [InlineData("Sensor at x=1, y=1: closest beacon is at x=2, y=1", 1, 0, 2, 1, 2)]
        [InlineData("Sensor at x=1, y=1: closest beacon is at x=1, y=0", 1, 0, 2, 1, 3)]
        public void testReadSensorsResults(string line1, int row, long expectedX0, long expectedX1,
            long expectedDist, long expectedCnt)
        {
            Area area = new(new List<string>() { line1 });
            SensorBeacon sensorBeacon = area.sensorBeacons[0];
            Assert.Equal(expectedDist, sensorBeacon.manhattenRadius);
            (long x0, long dx, long x1) = sensorBeacon.intersectionWithRow(row);
            Assert.Equal(expectedDist, dx);
            Assert.Equal(expectedX0, x0);
            Assert.Equal(expectedX1, x1);
            Assert.Equal(expectedCnt, area.cntPositionsWithNoBeacon(row));
        }

        [Theory]
        [InlineData(0, 1, 2, 3, 3, 4)]
        [InlineData(1, 1, 2, 3, 3, 4)]
        [InlineData(2, 1, 2, 3, 2, 4)]
        [InlineData(3, 1, 2, 3, 1, 4)]
        [InlineData(4, 1, 2, 3, 0, 4)]
        [InlineData(5, 1, 2, 3, 0, 5)]
        [InlineData(6, 1, 2, 3, 0, 6)]
        public void testAddPosition(long firstFreePosition, long firstX, long dx, long x2, long addToResult,
            long newLPos)
        {
            long result = 0;
            long nPos = Area.addPosition(firstFreePosition, ref result, (firstX, dx, x2));
            Assert.Equal(newLPos, nPos);
            Assert.Equal(addToResult, result);
        }
    }
}