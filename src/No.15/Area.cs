// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Collections.Generic;
using System.Linq;

namespace No._15
{
    public class Area
    {
        private readonly List<SensorBeacon> sensorBeacons;

        public Area(List<string> lines)
            => this.sensorBeacons = lines
                .ConvertAll(line => new SensorBeacon(line[10..]
                .Replace(" closest beacon is at ", ""))
            );

        public long cntPositionsWithNoBeacon(long yRow)
        {
            long result = 0;
            _ = this.sensorBeacons
                .ConvertAll(sb => sb.intersectionWithRow(yRow))
                .Where(inSe => inSe.dx > 0)
                .OrderBy(inSe => inSe.x)
                .ToList()
                .Aggregate(long.MinValue, (lpos, inSe) =>
                {
                    {
                        result += inSe.x + inSe.dx - Math.Max(lpos, inSe.x - inSe.dx);
                        return inSe.x + inSe.dx;
                    }
                });
            return result;
        }
    }

    public class SensorBeacon
    {
        private readonly Position sensorPosition;
        private readonly Position beaconPosition;
        private readonly long manhattenRadius;

        public SensorBeacon(string reducedData)
        {
            List<string> dataParts = reducedData.Split((':')).ToList();
            this.sensorPosition = new Position(dataParts[0]);
            this.beaconPosition = new Position(dataParts[1]);
            this.manhattenRadius = this.sensorPosition.manhattenDistance(this.beaconPosition);
        }

        public (long x, long dx) intersectionWithRow(long yRow)
        {
            long dx = this.manhattenRadius - Math.Abs(yRow - this.sensorPosition.y);
            return (this.sensorPosition.x, dx);
        }
    }
}