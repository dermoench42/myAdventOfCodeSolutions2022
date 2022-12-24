// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace No._09
{
    public class Viewport
    {
        private readonly int xMax;
        private readonly int yMax;
        public readonly int xMin;
        public readonly int yMin;

        public Viewport(List<string> moves)
        {
            int x = 0;
            int y = 0;

            foreach (string moveDef in moves)
            {
                char direction = moveDef[0];
                int countSteps = Convert.ToInt32(moveDef[2..], CultureInfo.CurrentCulture);

                switch (direction)
                {
                    case 'U':
                        y += countSteps;
                        break;
                    case 'D':
                        y -= countSteps;
                        break;
                    case 'R':
                        x += countSteps;
                        break;
                    case 'L':
                        x -= countSteps;
                        break;
                    default:
                        throw new InvalidDataException();
                }

                if (this.xMax < x)
                    this.xMax = x;
                if (this.xMin > x)
                    this.xMin = x;
                if (this.yMax < y)
                    this.yMax = y;
                if (this.yMin > y)
                    this.yMin = y;
            }
        }

        public int sizeX
            => this.xMax - this.xMin + 1;

        public int sizeY
            => this.yMax - this.yMin + 1;
    }
}