// (c) 2022 QSOFT Development

using System;
using System.Collections.Generic;
using System.IO;

namespace No._09
{
    public class Rope
    {
        private readonly Playground playground;
        private readonly Knot head;

        public Rope(Playground playground, int cntKnots)
        {
            this.playground = playground;
            this.head = new('H', playground, null);
            _ = new Knot('T', playground, this.head);
            this.playground.touch(0,0,'0');
            cntKnots -= 2;
            for (int idx = cntKnots; idx > 0; idx--)
            {
                _ = new Knot((char) ('0' + (char) idx), playground, this.head);
            }
        }

        public void moveHead(char direction, int countSteps)
        {
            switch (direction)
            {
                case 'U':
                    this.head.stepY(countSteps);
                    break;
                case 'D':
                    this.head.stepY(-countSteps);
                    break;
                case 'R':
                    this.head.stepX(countSteps);
                    break;
                case 'L':
                    this.head.stepX(-countSteps);
                    break;
                default:
                    throw new InvalidDataException();
            }
            /*Console.WriteLine($"{direction} {countSteps}");
            this.playground.displayRope(this.head);*/
        }

        public int touchedPositions()
            => this.playground.cntTouchedPositions;
    }
}