// (c) 2022 QSOFT Development

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace No._04
{
    public static class Calculator
    {
        public static int calc(List<string> data)
            => data.ConvertAll(row
                    => row.Split(',')
                        .ToList()
                        .ConvertAll(sec => new Section(sec)))
                .Sum(secs
                    => secs[0].contains(secs[1]) || secs[1].contains(secs[0]) ? 1 : 0);

        public static int calc2(List<string> data)
            => data.ConvertAll(row
                    => row.Split(',')
                        .ToList()
                        .ConvertAll(sec => new Section(sec)))
                .Sum(secs
                    => secs[0].overlaps(secs[1]) || secs[1].overlaps(secs[0]) ? 1 : 0);
    }

    public class Section
    {
        private readonly int start;
        private readonly int end;

        public Section(string sec)
        {
            string[] d = sec.Split('-');
            this.start = Convert.ToInt32(d[0], CultureInfo.CurrentCulture);
            this.end = Convert.ToInt32(d[1], CultureInfo.CurrentCulture);
        }

        public bool overlaps(Section sec2)
            => !(sec2.end < this.start || sec2.start > this.end);

        public bool contains(Section sec2)
            => this.start <= sec2.start && this.end >= sec2.end;
    }
}