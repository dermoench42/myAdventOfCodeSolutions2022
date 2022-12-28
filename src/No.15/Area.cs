// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Collections.Generic;
using System.Linq;

namespace No._15
{
    public class Area
    {
        public readonly List<SensorBeacon> sensorBeacons;

        public Area(List<string> lines)
            => this.sensorBeacons = lines
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList()
                .ConvertAll(line => new SensorBeacon(line[10..]
                    .Replace(" closest beacon is at ", ""))
                );


        public long cntPositionsWithNoBeacon(long yRow)
        {
            long result = 0;
            _ = this.sensorBeacons
                .Where(sb => sb.manhattenRadius >= Math.Abs(yRow - sb.sensorPosition.y))
                .ToList()
                .ConvertAll(sb => sb.intersectionWithRow(yRow))
                .Where(inSe => inSe.dx >= 0)
                .OrderBy(inSe => inSe.firstX)
                .ToList()
                .Aggregate(long.MinValue, (lpos, inSe) => addPosition(lpos, ref result, inSe));
            return result - this.sensorBeacons.Where(sb => sb.beaconPosition.y == yRow)
                .GroupBy(sb => sb.beaconPosition.x).Count();
        }

        public static long addPosition(long firstFreePosition, ref long cntPositions,
            (long firstX, long dx, long lastX) inSe)
        {
            long cntNewPositions = inSe.lastX + 1 - Math.Max(firstFreePosition, inSe.firstX);
            cntPositions += Math.Max(0, cntNewPositions);
            return Math.Max(firstFreePosition, inSe.lastX + 1);
        }

        public long calcFrequency(long size)
        {
            // Rider detects 8G used memory on running the tests or programm...
            Position beacon = this.findBeaconPos(size);
            return (beacon.x * 4000000 + beacon.y);
        }

        private Position findBeaconPos(long size)
        {
            List<(long, long)> coordinates = new();
            for (long row = 0; row < size; row++)
            {
                coordinates.AddRange(this.findPositionsWithoutBeacon(row, size).ConvertAll(i => (i, row)));
            }

            if (coordinates.Count > 1)
                throw new InvalidOperationException();

            return new Position(coordinates[0].Item1, coordinates[0].Item2);
        }

        private List<long> findPositionsWithoutBeacon(long yRow, long size)
        {
            // C#: take a look at the memory footprint... 2G of Tuples in Small Object Heap
            // There might be less expensive ways, maybe I take a look at it later
            List<long> freePositions = new();
            _ = this.sensorBeacons
                .Where(sb => Math.Abs(yRow - sb.sensorPosition.y) <= sb.manhattenRadius)
                .ToList()
                .ConvertAll(sb => sb.intersectionWithRow(yRow))
                .Where(inSe => inSe.lastX >= 0 && inSe.firstX <= size)
                .OrderBy(inSe => inSe.firstX)
                .ToList()
                .Aggregate(0L, (lpos, inSe) => this.addFreePosition(lpos, freePositions, inSe));
            return freePositions;
        }

        private long addFreePosition(long lpos, List<long> freePositions, (long firstX, long dx, long lastX) inSe)
        {
            while (lpos < inSe.firstX)
                freePositions.Add(lpos++);
            lpos = Math.Max(lpos, inSe.lastX + 1);
            return lpos;
        }
    }
}