// (c) 2022 QSOFT Development

using System;
using System.IO;

namespace No._09
{
    public class Rope
    {
        private int xHead;
        private int yHead;

        readonly Knot tail;

        public Rope(Viewport viewport)
            => this.tail = new(viewport);

        public void moveHead(char direction, int countSteps)
        {
            switch (direction)
            {
                case 'U':
                    this.yHead += countSteps;
                    if (this.length() > 1)
                    {
                        if (this.tail.x != this.xHead)
                        {
                            this.tail.step( this.xHead - this.tail.x,1);
                        }

                        this.tail.stepY(this.yHead - 1 - this.tail.y);
                    }

                    break;
                case 'D':
                    this.yHead -= countSteps;
                    if (this.length() > 1)
                    {
                        if (this.tail.x != this.xHead)
                        {
                            this.tail.step(this.xHead - this.tail.x,-1);
                        }

                        this.tail.stepY(this.yHead + 1 - this.tail.y);
                    }

                    break;
                case 'R':
                    this.xHead += countSteps;
                    if (this.length() > 1)
                    {
                        if (this.tail.y != this.yHead)
                        {
                            this.tail.step(1,this.yHead - this.tail.y);
                        }

                        this.tail.stepX(this.xHead - 1 - this.tail.x);
                    }

                    break;
                case 'L':
                    this.xHead -= countSteps;
                    if (this.length() > 1)
                    {
                        if (this.tail.y != this.yHead)
                        {
                            this.tail.step(-1,this.yHead - this.tail.y);
                        }

                        this.tail.stepX(this.xHead + 1 - this.tail.x);
                    }

                    break;
                default:
                    throw new InvalidDataException();
            }
        }

        private long length()
        {
            long dx = Math.Abs(this.tail.x - this.xHead);
            long dy = Math.Abs(this.tail.y - this.yHead);
            return Math.Max(dx, dy);
        }

        public int touchedPositions()
            => this.tail.cntTouchedPositions;

        public void displayTouchedPos()
            => this.tail.displayPos();
    }
}