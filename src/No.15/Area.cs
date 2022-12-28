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
            return result - this.sensorBeacons.Where(sb => sb.beaconPosition.y == yRow).GroupBy(sb => sb.beaconPosition.x).Count();
        }

        public static long addPosition(long firstFreePosition, ref long cntPositions, (long firstX, long dx, long lastX) inSe)
        {
            long cntNewPositions = inSe.lastX + 1 - Math.Max(firstFreePosition, inSe.firstX);
            cntPositions += Math.Max(0, cntNewPositions);
            return Math.Max(firstFreePosition, inSe.lastX + 1);
        }

        public long calcFrequency(long size)
        {
            Position beacon = this.findBeaconPos(size);
            return (beacon.x * 4000000 + beacon.y);
        }

        private Position findBeaconPos(long size)
        {
            return new Position(0, 0);
        }
    }
}