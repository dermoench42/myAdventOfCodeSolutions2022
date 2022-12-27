// (c) 2022 Ervin Peters (coder@ervnet.de)

using System.Collections.Generic;

namespace No._14
{
    public class CaveCoordinate
    {
        public int x;
        public int y;
        private ViewPort viewport;

        public int tx => this.x - this.viewport.minX;
        public int ty => this.y - this.viewport.minY;

        private CaveCoordinate() { }

        public CaveCoordinate(int x, int y, ViewPort viewport)
        {
            this.viewport = viewport;
            this.x = x;
            this.y = y;
        }

        public CaveCoordinate(List<int> coList, ViewPort viewport)
        {
            this.viewport = viewport;
            this.x = coList[0];
            this.y = coList[1];
        }


        public (int dx, int dy) distance(CaveCoordinate other)
            => (other.x - this.x, other.y - this.y);

        public CaveCoordinate clone(int dx = 0, int dy = 0)
            => new() { x = this.x + dx, y = this.y + dy, viewport = this.viewport };
    }
}