using System;
using System.Collections.Generic;

namespace NET.W2019.Shevchenko10.TaskSort
{
    /// <summary>
    /// Implements bubble sort algorithm for a jagged array of integers.
    /// </summary>
    public static class BubbleIComparer
    {
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
        /// IComparer implementation of the jagged int array bubble sort.
        /// Uses IComparer<int[]> to order arrays.
        /// </summary>
        public static void IComparerSort(int[][] array, IComparer<int[]> comparer, Order order)
        {
            int[] temp;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if ((order == Order.Ascending && comparer.Compare(array[i], array[j]) < 0)
                        || (order == Order.Descending && comparer.Compare(array[i], array[j]) > 0))
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Delegate implementation of the jagged int array bubble sort.
        /// Uses Func<int[], int[], int> delegate to compare arrays.
        /// </summary>
        public static void DelegateSort(int[][] array, Func<int[], int[], int> comparer, Order order)
        {
            IComparerSort(array, new ArrayComparer(comparer), order);
        }
    }
}
