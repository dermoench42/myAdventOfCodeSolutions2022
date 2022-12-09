// (c) 2022 QSOFT Development

using System.Collections.Generic;
using System.Linq;

namespace No._03
{
    public class RucksackContent
    {
        private readonly List<char> itemsFound = new();
        private readonly List<char> itemsDone = new();

        public RucksackContent(string content)
        {
            int compartmentLength = content.Length / 2;

            string c0 = content[..(compartmentLength)];
            string c1 = content[compartmentLength..];

            foreach (char item in c0.ToArray())
            {
                if (this.itemsDone.Contains(item))
                    continue;

                if (c1.Contains(item))
                    this.itemsFound.Add(item);

                this.itemsDone.Add(item);
            }
        }

        public int calcPrio()
            => this.itemsFound
                .Sum(item => item >= 'a'
                                    ? item - 'a' + 1
                                    : item - 'A' + 27);
    }
}