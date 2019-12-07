using System.Collections.Generic;
using System.Linq;

namespace NET.W2019.Shevchenko10.TaskSort
{
    public class MinArrayValue : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            int xMin = x.Min();
            int yMin = y.Min();

            return xMin < yMin ? -1 : xMin > yMin ? 1 : 0;
        }
    }
}
