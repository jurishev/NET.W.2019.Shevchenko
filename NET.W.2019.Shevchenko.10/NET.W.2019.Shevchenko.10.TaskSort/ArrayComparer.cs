using System;
using System.Collections.Generic;

namespace NET.W2019.Shevchenko10.TaskSort
{
    internal class ArrayComparer : IComparer<int[]>
    {
        private readonly Func<int[], int[], int> comparer;

        public ArrayComparer(Func<int[], int[], int> comparer) => this.comparer = comparer;

        public int Compare(int[] x, int[] y) => this.comparer(x, y);
    }
}
