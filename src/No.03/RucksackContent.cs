// (c) 2022 QSOFT Development

using System.Collections.Generic;
using System.Linq;

namespace No._03
{
    public class RucksackContent
    {
        private List<char> itemsFound;

        public RucksackContent(string content)
        {
            int compartmentLength = content.Length / 2;

            string c0 = content[..compartmentLength];
            string c1 = content[compartmentLength..];



        }

        public int calcPrio()
            => this.itemsFound.Sum(item => item);
    }
}