// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Globalization;
using System.Linq;

namespace No._15
{
    public class Position
    {
        public readonly long x;
        public readonly long y;

        public Position(string input)
        {
            long[] coords = input.Trim().Split(", ").ToList()
                .ConvertAll(a => Convert.ToInt64(a.Split("=")[1], CultureInfo.InvariantCulture))
                .ToArray();
            this.x = coords[0];
            this.y = coords[1];
        }

        public Position(long x, long y)
        {
            this.x = x;
            this.y = y;
        }

        public long manhattenDistance(Position other)
            => Math.Abs(this.x - other.x) + Math.Abs(this.y - other.y);
    }
}