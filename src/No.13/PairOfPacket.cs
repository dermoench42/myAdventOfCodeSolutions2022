// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Collections.Generic;
using System.Linq;

namespace No._13
{
    public class PairOfPacket
    {
        private readonly int id;
        private readonly ListFragment packet1;
        private readonly ListFragment packet2;

        public PairOfPacket(int id, string twoLines)
        {
            this.id = id + 1;
            List<string> lines = twoLines.Split('\n')
                .Take(2)
                .ToList();
            this.packet1 = new ListFragment(lines[0]);
            this.packet2 = new ListFragment(lines[1]);
        }

        public int compare()
        {
            CompareResults result = this.packet1.compare(this.packet2);

            if (result == CompareResults.IsEqual)
                throw new InvalidOperationException("should not happen in this puzzle...");

            return result == CompareResults.IsGreater ? this.id : 0;
        }
    }
}