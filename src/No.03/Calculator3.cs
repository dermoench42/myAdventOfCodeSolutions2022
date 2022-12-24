// (c) 2022 Ervin Peters (coder@ervnet.de)

using System.Linq;

namespace No._03
{
    public static class Calculator3
    {
        public static int calc(string data)
            => data.Split("\n")
                .ToList()
                .ConvertAll(content => new RucksackContent(content))
                .Sum(r => r.calcPrio());
    }
}