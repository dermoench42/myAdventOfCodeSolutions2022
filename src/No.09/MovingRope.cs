// (c) 2022 QSOFT Development

using System;
using System.Collections.Generic;
using System.Globalization;

namespace No._09
{
    public static class MovingRope
    {
        public static int touchedPositions(List<string> moves)
        {
            Viewport viewport = new(moves);
            Rope rope = new(viewport);

            foreach (string moveDef in moves)
            {
                char direction = moveDef[0];
                int countSteps = Convert.ToInt32(moveDef[2..], CultureInfo.CurrentCulture);

                rope.moveHead(direction, countSteps);
            }
            rope.displayTouchedPos();
            return rope.touchedPositions();
        }
    }
}