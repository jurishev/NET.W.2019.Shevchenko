using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W2019.Shevchenko10.TaskSort.Tests
{
    [TestClass]
    public class BubbleDelegateTests
    {
        private int[][] toSort = new int[][]
        {
                new int[] { 1, 11, 18 },
                new int[] { 5, 10, 14 },
                new int[] { 7, 8, 12 },
                new int[] { 3, 9, 16 },
        };

        [TestMethod]
        public void IComparerSort_MinAscending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 1, 11, 18 },
                new int[] { 3, 9, 16 },
                new int[] { 5, 10, 14 },
                new int[] { 7, 8, 12 },
            };

            BubbleDelegate.IComparerSort(toSort, new MinArrayValue(), BubbleDelegate.Order.Ascending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void IComparerSort_MinDescending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 7, 8, 12 },
                new int[] { 5, 10, 14 },
                new int[] { 3, 9, 16 },
                new int[] { 1, 11, 18 },
            };

            BubbleDelegate.IComparerSort(toSort, new MinArrayValue(), BubbleDelegate.Order.Descending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void IComparerSort_MaxAscending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 7, 8, 12 },
                new int[] { 5, 10, 14 },
                new int[] { 3, 9, 16 },
                new int[] { 1, 11, 18 },
            };

            BubbleDelegate.IComparerSort(toSort, new MaxArrayValue(), BubbleDelegate.Order.Ascending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void IComparerSort_MaxDescending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 1, 11, 18 },
                new int[] { 3, 9, 16 },
                new int[] { 5, 10, 14 },
                new int[] { 7, 8, 12 },
            };

            BubbleDelegate.IComparerSort(toSort, new MaxArrayValue(), BubbleDelegate.Order.Descending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void IComparerSort_SumAscending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 7, 8, 12 },
                new int[] { 3, 9, 16 },
                new int[] { 5, 10, 14 },
                new int[] { 1, 11, 18 },
            };

            BubbleDelegate.IComparerSort(toSort, new SumArrayValue(), BubbleDelegate.Order.Ascending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void IComparerSort_SumDescending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 1, 11, 18 },
                new int[] { 5, 10, 14 },
                new int[] { 3, 9, 16 },
                new int[] { 7, 8, 12 },
            };

            BubbleDelegate.IComparerSort(toSort, new SumArrayValue(), BubbleDelegate.Order.Descending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }
    }
}
