// (c) 2022 QSOFT Development

using System.Linq;

namespace No._03
{
    public static class Calculator3Part2
    {
        public static int calc(string data)
            => new BadgeFinder(data.Split("\n")
                .ToList()).calcPrio();
    }
}