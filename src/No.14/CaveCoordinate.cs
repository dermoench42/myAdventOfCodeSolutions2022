// (c) 2022 Ervin Peters (coder@ervnet.de)

using System.Collections.Generic;

namespace No._14
{
    public class CaveCoordinate
    {
        public int x;
        public int y;
        private readonly ViewPort viewPort;

        public int tx => this.x - this.viewPort.minX;
        public int ty => this.y - this.viewPort.minY;

        private CaveCoordinate(ViewPort viewPort)
            => this.viewPort = viewPort;

        public CaveCoordinate(int x, int y, ViewPort viewPort)
        {
            this.viewPort = viewPort;
            this.x = x;
            this.y = y;
        }

        public CaveCoordinate(IReadOnlyList<int> coList, ViewPort viewPort)
        {
            this.viewPort = viewPort;
            this.x = coList[0];
            this.y = coList[1];
        }


        public (int dx, int dy) distance(CaveCoordinate other)
            => (other.x - this.x, other.y - this.y);

        public CaveCoordinate clone(int dx = 0, int dy = 0)
            => new(this.viewPort) { x = this.x + dx, y = this.y + dy};
    }
}