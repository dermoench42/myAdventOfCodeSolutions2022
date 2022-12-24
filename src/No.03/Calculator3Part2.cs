// (c) 2022 Ervin Peters (coder@ervnet.de)

using System.Linq;

namespace No._03
{
    public static class Calculator3Part2
    {
        public static int calc(string data)
            => new BadgeFinder(data.Split("\n")
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList()).calcPrio();
    }
}