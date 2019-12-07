using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W2019.Shevchenko10.TaskSort.Tests
{
    [TestClass]
    public class BubbleIComparerTests
    {
        private int[][] toSort = new int[][]
        {
                new int[] { 1, 11, 18 },
                new int[] { 5, 10, 14 },
                new int[] { 7, 8, 12 },
                new int[] { 3, 9, 16 },
        };

        [TestMethod]
        public void DelegateSort_MinAscending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 1, 11, 18 },
                new int[] { 3, 9, 16 },
                new int[] { 5, 10, 14 },
                new int[] { 7, 8, 12 },
            };

            BubbleIComparer.DelegateSort(toSort, new MinArrayValue().Compare, BubbleIComparer.Order.Ascending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void DelegateSort_MinDescending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 7, 8, 12 },
                new int[] { 5, 10, 14 },
                new int[] { 3, 9, 16 },
                new int[] { 1, 11, 18 },
            };

            BubbleIComparer.DelegateSort(toSort, new MinArrayValue().Compare, BubbleIComparer.Order.Descending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void DelegateSort_MaxAscending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 7, 8, 12 },
                new int[] { 5, 10, 14 },
                new int[] { 3, 9, 16 },
                new int[] { 1, 11, 18 },
            };

            BubbleIComparer.DelegateSort(toSort, new MaxArrayValue().Compare, BubbleIComparer.Order.Ascending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void DelegateSort_MaxDescending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 1, 11, 18 },
                new int[] { 3, 9, 16 },
                new int[] { 5, 10, 14 },
                new int[] { 7, 8, 12 },
            };

            BubbleIComparer.DelegateSort(toSort, new MaxArrayValue().Compare, BubbleIComparer.Order.Descending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void DelegateSort_SumAscending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 7, 8, 12 },
                new int[] { 3, 9, 16 },
                new int[] { 5, 10, 14 },
                new int[] { 1, 11, 18 },
            };

            BubbleIComparer.DelegateSort(toSort, new SumArrayValue().Compare, BubbleIComparer.Order.Ascending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }

        [TestMethod]
        public void DelegateSort_SumDescending()
        {
            int[][] expected = new int[][]
            {
                new int[] { 1, 11, 18 },
                new int[] { 5, 10, 14 },
                new int[] { 3, 9, 16 },
                new int[] { 7, 8, 12 },
            };

            BubbleIComparer.DelegateSort(toSort, new SumArrayValue().Compare, BubbleIComparer.Order.Descending);

            for (int i = 0; i < toSort.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], toSort[i]);
            }
        }
    }
}
