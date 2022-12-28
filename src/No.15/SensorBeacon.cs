// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Collections.Generic;
using System.Linq;

namespace No._15
{
    public class SensorBeacon
    {
        public readonly Position sensorPosition;
        public readonly Position beaconPosition;
        public readonly long manhattenRadius;

        public SensorBeacon(string reducedData)
        {
            List<string> dataParts = reducedData.Split((':')).ToList();
            this.sensorPosition = new Position(dataParts[0]);
            this.beaconPosition = new Position(dataParts[1]);
            this.manhattenRadius = this.sensorPosition.manhattenDistance(this.beaconPosition);
        }

        public (long firstX, long dx, long lastX) intersectionWithRow(long yRow)
        {
            long dx = Math.Max(0,this.manhattenRadius - Math.Abs(yRow - this.sensorPosition.y));
            return (this.sensorPosition.x - dx, dx, this.sensorPosition.x + dx);
        }
    }
}