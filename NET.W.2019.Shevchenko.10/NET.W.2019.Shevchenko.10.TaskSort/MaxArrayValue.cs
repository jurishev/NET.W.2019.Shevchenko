using System.Collections.Generic;
using System.Linq;

namespace NET.W2019.Shevchenko10.TaskSort
{
    public class MaxArrayValue : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            int xMax = x.Max();
            int yMax = y.Max();

            return xMax < yMax ? -1 : xMax > yMax ? 1 : 0;
        }
    }
}
