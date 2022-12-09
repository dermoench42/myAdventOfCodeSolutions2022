// (c) 2022 QSOFT Development

using System.Collections.Generic;
using System.Linq;
using System;

namespace No._03
{
    public class BadgeFinder
    {
        private readonly List<char> itemsFound = new();

        public BadgeFinder(List<string> content)
        {
            int cntGroups = content.Count/3;
            if (content.Count % 3 > 0)
                throw new InvalidOperationException("Count Lines error (mod 3)");

            int idxGroup = 0;

            while (idxGroup < cntGroups)
            {
                //string badge = this.find(content.GetRange(idxGroup,3))

            }
        }

        public int calcPrio()
            => this.itemsFound
                .Sum(item => item >= 'a'
                                    ? item - 'a' + 1
                                    : item - 'A' + 27);
    }
}