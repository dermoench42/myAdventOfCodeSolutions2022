// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Globalization;

namespace No._13
{
    public class IntFragment : IFragment
    {
        public readonly string source;
        private readonly int value;

        public int cntCharsParsed { get; private set; }

        public IntFragment(string s)
        {
            int pos;
            for (pos = 0; pos < s.Length; pos++)
            {
                if (!char.IsDigit(s[pos]))
                    break;
            }

            this.source = s;
            this.cntCharsParsed = pos;
            this.value = Convert.ToInt32(s[..pos], CultureInfo.InvariantCulture);
        }

        public CompareResults compare(IFragment other)
            => other switch
            {
                IntFragment rightInt when rightInt.value < this.value => CompareResults.IsLower,
                IntFragment rightInt when rightInt.value > this.value => CompareResults.IsGreater,
                ListFragment rightList => new ListFragment(this).compare(rightList),
                _ => CompareResults.IsEqual
            };
    }
}