// (c) 2022 Ervin Peters (coder@ervnet.de)

using System.Collections.Generic;
using System.Linq;

namespace No._13
{
    public static class SignalDecoder
    {
        public static int countRightOrderOfPairs(string data)
            => data.Split("\n\n")
                .Select((item, idx) => new PairOfPacket(idx++, item))
                .ToList()
                .Sum(p => p.compare());

        public static int sortedInputResult(string data)
        {
            List<string> keyNames = new() { "[[2]]", "[[6]]" };
            return data.Split("\n")
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Append(keyNames[0])
                .Append(keyNames[1])
                .ToList()
                .ConvertAll(line => new ListFragment(line))
                .OrderBy(fragment => fragment, new FragmentComparer<IFragment>())
                .Select((f, idx) =>
                {
                    f.idx = ++idx;
                    return f;
                })
                .Where(f => keyNames.Contains(f.source))
                .Aggregate(1, (p, f) => p * f.idx);
        }
    }
}