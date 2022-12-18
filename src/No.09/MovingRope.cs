// (c) 2022 QSOFT Development

using System;
using System.Collections.Generic;
using System.Globalization;

namespace No._09
{
    public static class MovingRope
    {
        public static int touchedPositions(List<string> moves, int cntKnots)
        {
            Viewport viewport = new(moves);
            Playground playground = new(viewport);

            Rope rope = new(playground, cntKnots);

            foreach (string moveDef in moves)
            {
                char direction = moveDef[0];
                int countSteps = Convert.ToInt32(moveDef[2..], CultureInfo.CurrentCulture);

                rope.moveHead(direction, countSteps);
            }

            playground.displayPos();

            return rope.touchedPositions();
        }
    }
}