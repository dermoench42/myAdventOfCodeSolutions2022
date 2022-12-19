// (c) 2022 QSOFT Development

using System;
using System.Collections.Generic;
using System.Linq;

namespace No._08
{
    public class VisiblePos
    {
        private readonly List<HeightPos> heightPositions = new();

        public bool checkIncreasing(char height, int pos)
        {
            if (this.heightPositions.Count > 0 && this.heightPositions.Last().height > height)
                return false;

            this.heightPositions.Add(new HeightPos() { height = height, pos = pos });
            return true;
        }

        public bool isVisible(char height, int pos)
        {
            HeightPos hp = this.heightPositions.FirstOrDefault(hp => hp.height >= height)
                           ?? throw new InvalidOperationException("Error in Analyze");

            return hp.pos == pos;
        }
    }
}