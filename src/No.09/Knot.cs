// (c) 2022 QSOFT Development

using System;

namespace No._09
{
    public class Knot
    {
        public int x;
        public int y;
        private readonly char[,] touchedPositions;
        public int cntTouchedPositions;
        private readonly Viewport vp;
        private readonly int sizeX;
        private readonly int sizeY;

        public Knot(Viewport vp)
        {
            this.vp = vp;
            this.sizeX = vp.sizeX + 1;
            this.sizeY = vp.sizeY + 1;
            this.touchedPositions = new char[this.sizeX, this.sizeY];
            this.x = 0;
            this.y = 0;
            this.touchedPositions[this.x - this.vp.xMin, this.y - this.vp.yMin] = '0';
            this.cntTouchedPositions++;
        }

        public void step(int dx, int dy)
        {
            this.x += dx;
            this.y += dy;
            this.touch();
        }

        private void touch()
        {
            if (this.touchedPositions[this.x - this.vp.xMin, this.y - this.vp.yMin] == '#' || this.touchedPositions[this.x - this.vp.xMin, this.y - this.vp.yMin] == '0')
                return;
            this.touchedPositions[this.x - this.vp.xMin, this.y - this.vp.yMin] = '#';
            this.cntTouchedPositions++;
        }

        public void stepX(long dX)
        {
            int step = dX > 0 ? 1 : -1;
            while (dX != 0)
            {
                this.x += step;
                this.touch();
                dX -= step;
            }
        }

        public void stepY(long dY)
        {
            int step = dY > 0 ? 1 : -1;
            while (dY != 0)
            {
                this.y += step;
                this.touch();
                dY -= step;
            }
        }

        public void displayPos()
        {
            for (int ly = this.sizeY-1; ly >= 0; ly--)
            {
                for (int lx = 0; lx < this.sizeX; lx++)
                {
                    Console.Write(this.touchedPositions[lx, ly]);
                }

                Console.WriteLine();
            }
        }
    }
}