// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;

namespace No._09
{
    public class Playground
    {
        private readonly int sizeX;
        private readonly int sizeY;
        private readonly int dx;
        private readonly int dy;

        private readonly char[,] touchedPositions;
        public int cntTouchedPositions;

        public Playground(Viewport viewport)
        {
            this.sizeX = viewport.sizeX + 1;
            this.sizeY = viewport.sizeY + 1;
            this.dx = viewport.xMin;
            this.dy = viewport.yMin;
            this.touchedPositions = new char[this.sizeX, this.sizeY];
        }

        public void touch(int x, int y, char sym = '#')
        {
            if (this.touchedPositions[x - this.dx, y - this.dy] != '\0')
                return;
            this.touchedPositions[x - this.dx, y - this.dy] = sym;
            if (sym is '#' or '0' or 'T')
                this.cntTouchedPositions++;
        }

        public void displayPos()
        {
            for (int ly = this.sizeY - 1; ly >= 0; ly--)
            {
                for (int lx = 0; lx < this.sizeX; lx++)
                {
                    Console.Write(this.touchedPositions[lx, ly] == '\0'
                        ? '·'
                        : this.touchedPositions[lx, ly]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void displayRope(Knot? knot)
        {
            char[,] ropes = new char[this.sizeX, this.sizeY];
            ropes[-this.dx, -this.dy] = 's';
            while (knot != null)
            {
                ropes[knot.x - this.dx, knot.y - this.dy] = knot.id;

                knot = knot.nextKnot;
            }

            for (int ly = this.sizeY - 1; ly >= 0; ly--)
            {
                for (int lx = 0; lx < this.sizeX; lx++)
                {
                    Console.Write(ropes[lx, ly]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}