// (c) 2022 Ervin Peters (coder@ervnet.de)

using System.Collections.Generic;

namespace No._14
{
    public class ViewPort
    {
        public int sizeX;
        public int sizeY;
        public int minX = int.MaxValue;
        public int minY = int.MaxValue;
        private int maxX = int.MinValue;
        private int maxY = int.MinValue;

        public CaveCoordinate createCoordinate(int x, int y)
        {
            CaveCoordinate coord = new(x, y, this);
            this.updateViewPort(coord);
            return coord;
        }

        public CaveCoordinate createCoordinate(List<int> coList)
        {
            CaveCoordinate coord = new(coList, this);
            this.updateViewPort(coord);
            return coord;
        }

        private void updateViewPort(CaveCoordinate coord)
        {
            if (coord.x > this.maxX)
                this.maxX = coord.x;
            if (coord.x < this.minX)
                this.minX = coord.x;

            if (coord.y > this.maxY)
                this.maxY = coord.y;
            if (coord.y < this.minY)
                this.minY = coord.y;

            this.sizeX = this.maxX - this.minX + 1;
            this.sizeY = this.maxY - this.minY + 1;
        }

        public bool isOutOfCave(CaveCoordinate coord)
            => coord.x > this.maxX || coord.x < this.minX || coord.y > this.maxY || coord.y < this.minY;

    }
}