using System.Linq;

namespace NET.W2019.Shevchenko06
{
    /// <summary>
    /// EPAM training, winter 2019.
    /// Day 6 homework.
    /// Task 2.
    /// Yuri Shevchenko.
    /// </summary>
    public static class BubbleSort
    {
        public enum SortBy
        {
            /// <summary>
            /// Sort by a min element in an array.
            /// </summary>
            Min,

            /// <summary>
            /// Sort by a max element in an array.
            /// </summary>
            Max,

            /// <summary>
            /// Sort by sum of all elements in an array.
            /// </summary>
            Sum,
        }

        public enum Order
        {
            /// <summary>
            /// Sort in the ascending order.
            /// </summary>
            Ascending,

            /// <summary>
            /// Sort in the descending order.
            /// </summary>
            Descending,
        }

        /// <summary>
        /// Sorts a jagged array of integers according to given conditions.
        /// </summary>
        /// <param name="matrix">The array of arrays to be sorted.</param>
        /// <param name="criteria">Kind of a value to compare.</param>
        /// <param name="order">Order of sorting.</param>
        public static void Sort(int[][] matrix, SortBy criteria, Order order)
        {
            if (matrix == null)
            {
                return;
            }

            (int, int[])[] data = new (int, int[])[matrix.Length];

            int index = 0;

            foreach (int[] line in matrix)
            {
                if (line == null)
                {
                    return;
                }

                int? value =
                    criteria == SortBy.Min ? line.Min() :
                    criteria == SortBy.Max ? line.Max() :
                    criteria == SortBy.Sum ? line.Sum() :
                    (int?)null;

                if (value == null)
                {
                    return;
                }

                data[index++] = ((int)value, line);
            }

            SortData(data, order);

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = data[i].Item2;
            }

            return;
        }

        private static void SortData((int, int[])[] data, Order order)
        {
            (int, int[]) temp;

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    if ((order == Order.Ascending && data[i].Item1 < data[j].Item1)
                        || (order == Order.Descending && data[i].Item1 > data[j].Item1))
                    {
                        temp = data[i];
                        data[i] = data[j];
                        data[j] = temp;
                    }
                }
            }
        }
    }
}
