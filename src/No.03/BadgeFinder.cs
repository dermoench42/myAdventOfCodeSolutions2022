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
            if (content.Count % 3 > 0)
                throw new InvalidOperationException($"Count Lines error (mod 3 => {content.Count % 3})");

            int idx = 0;

            while (idx < content.Count)
            {
                char found = '\0';
                foreach (char item in content[idx].ToArray())
                {
                    if (found != '\0')
                        break;

                    if (!content[idx + 1].Contains(item)
                        || !content[idx + 2].Contains(item)) continue;

                    this.itemsFound.Add(item);
                    found = item;
                }

                idx += 3;
            }
        }

        public int calcPrio()
            => this.itemsFound
                .Sum(item => item >= 'a'
                    ? item - 'a' + 1
                    : item - 'A' + 27);
    }
}