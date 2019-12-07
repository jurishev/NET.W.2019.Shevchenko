using System.Collections.Generic;
using System.Linq;

namespace NET.W2019.Shevchenko10.TaskSort
{
    public class SumArrayValue : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            int xSum = x.Sum();
            int ySum = y.Sum();

            return xSum < ySum ? -1 : xSum > ySum ? 1 : 0;
        }
    }
}
