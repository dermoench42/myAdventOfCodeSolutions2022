// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Collections.Generic;

namespace No._13
{
    public class ListFragment : IFragment
    {
        public readonly string source;
        public int idx;
        public List<IFragment> fragments { get; private set; } = new();
        public int cntCharsParsed { get; private set; }

        public ListFragment(string line)
        {
            if (line[0] != '[')
                throw new ArgumentException("wrong data");
            this.source = line;

            this.cntCharsParsed = 1;

            bool done = false;
            while (this.cntCharsParsed < line.Length && !done)
            {
                IFragment fragment;
                switch (line[this.cntCharsParsed])
                {
                    case '[':
                        fragment = new ListFragment(line[this.cntCharsParsed..]);
                        this.fragments.Add(fragment);
                        this.cntCharsParsed += fragment.cntCharsParsed;
                        break;
                    case ']':
                        this.cntCharsParsed++;
                        done = true;
                        break;
                    case ',':
                        this.cntCharsParsed++;
                        break;
                    default:
                        if (char.IsDigit(line[this.cntCharsParsed]))
                        {
                            fragment = new IntFragment(line[this.cntCharsParsed..]);
                            this.fragments.Add(fragment);
                            this.cntCharsParsed += fragment.cntCharsParsed;
                        }
                        else
                            throw new InvalidOperationException();

                        break;
                }
            }
        }

        public ListFragment(IntFragment intFragment)
        {
            this.source = intFragment.source;
            this.fragments.Add(intFragment);
            this.cntCharsParsed = intFragment.cntCharsParsed;
        }

        public CompareResults compare(IFragment other)
            => other switch
            {
                ListFragment rightList => this.compareListFragments(rightList),
                IntFragment rightInt => this.compare(new ListFragment(rightInt)),
                _ => CompareResults.IsEqual
            };

        private CompareResults compareListFragments(ListFragment rightList)
        {
            int pos = 0;
            int cntLeft = this.fragments.Count;
            int cntRight = rightList.fragments.Count;

            if (cntLeft == 0 && cntRight > 0)
                return CompareResults.IsGreater;

            while (pos < cntLeft)
            {
                if (pos >= cntRight)
                    return CompareResults.IsLower;

                CompareResults result = this.fragments[pos].compare(rightList.fragments[pos]);

                if (result != CompareResults.IsEqual)
                    return result;

                pos++;
            }

            return cntRight > cntLeft
                ? CompareResults.IsGreater
                : CompareResults.IsEqual;
        }
    }
}