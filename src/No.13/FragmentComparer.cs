// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Collections.Generic;

namespace No._13
{
    public class FragmentComparer<T> : IComparer<T> where T : IFragment
    {
        public int Compare(T? left, T? right)
        {
            if (left is null)
                throw new ArgumentNullException(nameof(left));
            if (right is null)
                throw new ArgumentNullException(nameof(right));

            return (int) (right).compare(left);
        }
    }
}