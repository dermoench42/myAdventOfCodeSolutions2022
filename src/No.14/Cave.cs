// (c) 2022 Ervin Peters (coder@ervnet.de)

using System.Collections.Generic;
using System.Text;

namespace No._14
{
    public class Cave
    {
        private readonly CaveCoordinate sandHole;
        private readonly char[,] tiles;
        private readonly ViewPort viewPort = new();
        private int cntRestedUnitsOfSand;

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

        public int letItFall()
        {
            bool gonetoVoid = false;
            while (!gonetoVoid && this.tiles[this.sandHole.tx, this.sandHole.ty] == '\0')
            {
                gonetoVoid = this.unitOfSandfalling();
            }

            return this.cntRestedUnitsOfSand;
        }

        private bool unitOfSandfalling()
        {
            CaveCoordinate position = this.sandHole.clone();

            bool rested = false;
            while (!rested)
            {
                (bool goneToVoid, rested) = this.checkVerticalFalling(position);
                if (goneToVoid)
                    return true;
            }

            return false;
        }

        private (bool, bool) checkVerticalFalling(CaveCoordinate position)
        {
            CaveCoordinate nextPosition = this.fallVertically(position);
            bool rested = false;
            if (this.viewPort.isOutOfCave(nextPosition))
                return (true, rested);

            nextPosition.x--;
            if (this.viewPort.isOutOfCave(nextPosition))
                return (true, rested);

            if (this.tiles[nextPosition.tx, nextPosition.ty] == '\0')
            {
                position.x--;
                position.y++;
            }
            else
            {
                nextPosition.x += 2;
                if (this.viewPort.isOutOfCave(nextPosition))
                    return (true, rested);

                if (this.tiles[nextPosition.tx, nextPosition.ty] == '\0')
                {
                    position.x++;
                    position.y++;
                }
                else
                {
                    rested = true;
                    this.cntRestedUnitsOfSand++;
                    this.tiles[position.tx, position.ty] = '0';
                }
            }

            return (this.viewPort.isOutOfCave(position), rested);
        }

        private CaveCoordinate fallVertically(CaveCoordinate position)
        {
            CaveCoordinate nextPosition = position.clone(0, 1);
            while (!this.viewPort.isOutOfCave(nextPosition)
                   && this.tiles[nextPosition.tx, nextPosition.ty] == '\0')
            {
                nextPosition.y++;
                position.y++;
            }

            return nextPosition;
        }

        public int letItFall2()
        {
            while (this.tiles[this.sandHole.tx, this.sandHole.ty] == '\0')
            {
                CaveCoordinate position = this.sandHole.clone();

                bool rested = false;
                while (!rested && (this.tiles[position.tx, position.ty] == '\0'))
                {
                    rested = this.unitOfSandFalling2(position);
                }
            }

            return this.cntRestedUnitsOfSand;
        }

        private bool unitOfSandFalling2(CaveCoordinate position)
        {
            bool rested = false;

            CaveCoordinate nextPosition = position.clone(0, 1);
            while (this.tiles[nextPosition.tx, nextPosition.ty] == '\0')
            {
                nextPosition.y++;
                position.y++;
            }

            nextPosition.x--;

            if (this.tiles[nextPosition.tx, nextPosition.ty] == '\0')
            {
                position.x--;
                position.y++;
            }
            else
            {
                nextPosition.x += 2;

                if (this.tiles[nextPosition.tx, nextPosition.ty] == '\0')
                {
                    position.x++;
                    position.y++;
                }
                else
                {
                    rested = true;
                    this.cntRestedUnitsOfSand++;
                    this.tiles[position.tx, position.ty] = '0';
                }
            }

            return rested;
        }

        public string show()
        {
            StringBuilder sb = new();
            for (int y = 0; y < this.viewPort.sizeY; y++)
            {
                sb.Append(y)
                    .Append(' ');
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