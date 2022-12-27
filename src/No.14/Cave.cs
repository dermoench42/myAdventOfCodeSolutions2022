// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Collections.Generic;
using System.Text;

namespace No._14
{
    public class Cave
    {
        private readonly CaveCoordinate sandHole;
        private readonly char[,] tiles;
        private readonly ViewPort viewPort = new();

        public Cave(List<string> wallPaths, bool hasBottom = false)
        {
            List<PathOfRock> paths = wallPaths.ConvertAll(path => new PathOfRock(path, this.viewPort));
            this.sandHole = this.viewPort.createCoordinate(500, 0);

            if (hasBottom)
            {
                int height = this.viewPort.sizeY + 1;
                string bottom = $"{500 - height},{height} -> {500 + height},{height}";
                paths.Add(new PathOfRock(bottom, this.viewPort));
            }

            this.tiles = new char[this.viewPort.sizeX, this.viewPort.sizeY];
            paths.ForEach(path => path.drawPath(this.tiles));
        }

        public int letItFall(bool show = false)
        {
            bool gonetoVoid = false;
            int cntRestedUnitsOfSand = 0;
            while (!gonetoVoid && this.tiles[this.sandHole.tx, this.sandHole.ty] == '\0')
            {
                gonetoVoid = this.unitOfSandfalling(show, ref cntRestedUnitsOfSand);
            }

            return cntRestedUnitsOfSand;
        }

        private bool unitOfSandfalling(bool show, ref int cntRestedUnitsOfSand)
        {
            bool gonetoVoid = false;
            CaveCoordinate position = this.sandHole.clone();

            bool rested = false;
            while (!rested && !gonetoVoid)
            {
                CaveCoordinate nextPosition = position.clone(0, 1);
                while (!this.viewPort.isOutOfCave(nextPosition)
                       && this.tiles[nextPosition.tx, nextPosition.ty] == '\0')
                {
                    nextPosition.y++;
                    position.y++;
                }

                if (this.viewPort.isOutOfCave(nextPosition))
                    gonetoVoid = true;
                else
                {
                    nextPosition.x--;
                    if (this.viewPort.isOutOfCave(nextPosition))
                        gonetoVoid = true;
                    else if (this.tiles[nextPosition.tx, nextPosition.ty] == '\0')
                    {
                        position.x--;
                        position.y++;
                    }
                    else
                    {
                        nextPosition.x += 2;
                        if (this.viewPort.isOutOfCave(nextPosition))
                            gonetoVoid = true;
                        else if (this.tiles[nextPosition.tx, nextPosition.ty] == '\0')
                        {
                            position.x++;
                            position.y++;
                        }
                        else
                        {
                            rested = true;
                            cntRestedUnitsOfSand++;
                            this.tiles[position.tx, position.ty] = '0';
                        }
                    }

                    if (show)
                    {
                        Console.WriteLine(this.show());
                    }

                    if (this.viewPort.isOutOfCave(position))
                        gonetoVoid = true;
                }
            }

            return gonetoVoid;
        }

        public int letItFall2(bool show = false)
        {
            int cntRestedUnitsOfSand = 0;

            while (this.tiles[this.sandHole.tx, this.sandHole.ty] == '\0')
            {
                CaveCoordinate position = this.sandHole.clone();

                bool rested = false;
                while (!rested && (this.tiles[position.tx, position.ty] == '\0'))
                {
                    CaveCoordinate nextPosition = position.clone(0, 1);
                    while (this.tiles[nextPosition.tx, nextPosition.ty] == '\0')
                    {
                        nextPosition.y++;
                        position.y++;
                    }

                    if (this.viewPort.isOutOfCave(nextPosition))
                        throw new InvalidOperationException();

                    nextPosition.x--;
                    if (this.viewPort.isOutOfCave(nextPosition))
                        throw new InvalidOperationException();

                    if (this.tiles[nextPosition.tx, nextPosition.ty] == '\0')
                    {
                        position.x--;
                        position.y++;
                    }
                    else
                    {
                        nextPosition.x += 2;
                        if (this.viewPort.isOutOfCave(nextPosition))
                            throw new InvalidOperationException();

                        if (this.tiles[nextPosition.tx, nextPosition.ty] == '\0')
                        {
                            position.x++;
                            position.y++;
                        }
                        else
                        {
                            rested = true;
                            cntRestedUnitsOfSand++;
                            this.tiles[position.tx, position.ty] = '0';
                        }
                    }

                    if (show)
                    {
                        Console.WriteLine(this.show());
                    }

                    if (this.viewPort.isOutOfCave(position))
                        throw new InvalidOperationException();
                }
            }

            return cntRestedUnitsOfSand;
        }

        public string show()
        {
            StringBuilder sb = new();
            for (int y = 0; y < this.viewPort.sizeY; y++)
            {
                sb.Append($"{y} ");
                for (int x = 0; x < this.viewPort.sizeX; x++)
                {
                    sb.Append(this.tiles[x, y] == '\0' ? '.' : this.tiles[x, y]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}