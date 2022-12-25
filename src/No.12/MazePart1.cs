// (c) 2022 Ervin Peters (coder@ervnet.de)

using System.Collections.Generic;
using System.IO;

namespace No._12
{
    public class MazePart1
    {
        private readonly string[] topoData;
        private Position? start;
        private Position? ziel;
        private readonly Position[,] map;
        private readonly int width;
        private readonly int height;
        private readonly Queue<Position> toExplore = new();


        public MazePart1(string[] topoData)
        {
            this.topoData = topoData;
            this.width = topoData[0].Length;
            this.height = topoData.Length;
            this.map = new Position[this.width, this.height];
            this.createMitStartUndZiel();
        }

        private void createMitStartUndZiel()
        {
            for (uint rowIdx = 0; rowIdx < this.height; rowIdx++)
            {
                for (uint colIdx = 0; colIdx < this.width; colIdx++)
                {
                    Position position = this.createPosition(colIdx, rowIdx);

                    if (colIdx > 0)
                        this.checkRelationLeft(colIdx, rowIdx, position);

                    if (rowIdx > 0)
                        this.checkRelationTop(rowIdx, colIdx, position);
                }
            }
        }

        private void checkRelationTop(uint rowIdx, uint colIdx, Position position)
        {
            Position top = this.map[colIdx, rowIdx - 1];
            int dheight = position.height - top.height;

            if (dheight <= 1)
                top.bottom = position;

            if (dheight >= -1)
                position.top = top;
        }

        private void checkRelationLeft(uint colIdx, uint rowIdx, Position position)
        {
            Position left = this.map[colIdx - 1, rowIdx];
            int dHeight = position.height - left.height;

            if (dHeight <= 1)
                left.right = position;

            if (dHeight >= -1)
                position.left = left;
        }

        private Position createPosition(uint colIdx, uint rowIdx)
        {
            Position position = new();
            this.map[colIdx, rowIdx] = position;
            char heightMeta = this.topoData[rowIdx][(int) colIdx];

            switch (heightMeta)
            {
                case 'S':
                    this.start = position;
                    position.distance = 0;
                    position.touched = true;
                    position.height = 'a';
                    break;
                case 'E':
                    this.ziel = position;
                    position.height = 'z';
                    break;
                default:
                    position.height = heightMeta;
                    break;
            }

            return position;
        }

        public uint findPath()
        {
            if (this.start is null || this.ziel is null)
                throw new InvalidDataException("start, ziel fehlen");

            Position pos = this.start;
            pos.touched = true;
            pos.distance = 0;

            while (pos != this.ziel)
            {
                pos.checkNeighbours(this.toExplore.Enqueue, ++pos.distance);
                pos = this.toExplore.Dequeue();
            }

            return this.ziel.distance;
        }
    }
}