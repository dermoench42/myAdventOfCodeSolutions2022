// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;

namespace No._12
{
    public class Position
    {
        public char height;
        public bool touched;
        public uint distance;
        public Position? right;
        public Position? left;
        public Position? top;
        public Position? bottom;

        public void checkNeighbours(Action<Position> checkNeighbour, uint dist)
        {
            foreach (Position? pos in new[] { this.right, this.left, this.top, this.bottom })
            {
                if (pos == null || pos.touched)
                    continue;
                pos.distance = dist;
                pos.touched = true;
                checkNeighbour(pos);
            }
        }
    }
}