using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W2019.Shevchenko06.Tests
{
    [TestClass]
    public class BubbleSortTests
    {
        private int[][] toSort = new int[][]
        {
                new int[] { 1, 11, 18 },
                new int[] { 5, 10, 14 },
                new int[] { 7, 8, 12 },
                new int[] { 3, 9, 16 },
        };

        [TestMethod]
        public void BubbleSort_MinAscending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 1, 11, 18 },
                new int[] { 3, 9, 16 },
                new int[] { 5, 10, 14 },
                new int[] { 7, 8, 12 },
            };

            BubbleSort.Sort(toSort, BubbleSort.SortBy.Min, BubbleSort.Order.Ascending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void BubbleSort_MinDescending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 7, 8, 12 },
                new int[] { 5, 10, 14 },
                new int[] { 3, 9, 16 },
                new int[] { 1, 11, 18 },
            };

            BubbleSort.Sort(toSort, BubbleSort.SortBy.Min, BubbleSort.Order.Descending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void BubbleSort_MaxAscending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 7, 8, 12 },
                new int[] { 5, 10, 14 },
                new int[] { 3, 9, 16 },
                new int[] { 1, 11, 18 },
            };

            BubbleSort.Sort(toSort, BubbleSort.SortBy.Max, BubbleSort.Order.Ascending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void BubbleSort_MaxDescending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 1, 11, 18 },
                new int[] { 3, 9, 16 },
                new int[] { 5, 10, 14 },
                new int[] { 7, 8, 12 },
            };

            BubbleSort.Sort(toSort, BubbleSort.SortBy.Max, BubbleSort.Order.Descending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void BubbleSort_SumAscending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 7, 8, 12 },
                new int[] { 3, 9, 16 },
                new int[] { 5, 10, 14 },
                new int[] { 1, 11, 18 },
            };

            BubbleSort.Sort(toSort, BubbleSort.SortBy.Sum, BubbleSort.Order.Ascending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void BubbleSort_SumDescending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 1, 11, 18 },
                new int[] { 5, 10, 14 },
                new int[] { 3, 9, 16 },
                new int[] { 7, 8, 12 },
            };

            BubbleSort.Sort(toSort, BubbleSort.SortBy.Sum, BubbleSort.Order.Descending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }
    }
}
