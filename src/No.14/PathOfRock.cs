// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace No._14
{
    public class PathOfRock
    {
        private readonly List<CaveCoordinate> coordinates;

        public PathOfRock(string path, ViewPort viewport)
        {
            this.coordinates = path.Split(" -> ")
                .ToList()
                .ConvertAll(coItem => viewport
                    .createCoordinate(coItem.Split(',')
                    .ToList()
                    .ConvertAll(c => Convert.ToInt32(c, CultureInfo.InvariantCulture))));
        }

        public void drawPath(char[,] tiles)
        {
            CaveCoordinate prevPos = null;
            foreach (CaveCoordinate pos in this.coordinates)
            {
                if (prevPos != null)
                {
                    (int dx, int dy) = prevPos.distance(pos);

                    int step = dx > 0 ? 1 : -1;
                    while (dx != 0)
                    {
                        tiles[prevPos.tx + dx, prevPos.ty] = '#';
                        dx -= step;
                    }

                    step = dy > 0 ? 1 : -1;
                    while (dy != 0)
                    {
                        tiles[prevPos.tx, prevPos.ty + dy] = '#';
                        dy -= step;
                    }
                }
                else
                {
                    tiles[pos.tx, pos.ty] = '#';
                }

                prevPos = pos;
            }
        }
    }
}