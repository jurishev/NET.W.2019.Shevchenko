using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace NET.W2019.Shevchenko13.BstTask.Tests
{
    [TestClass]
    public class BstPointTests
    {
        private static Random rand = new Random();

        Point[] GenerateRandomPointValues()
        {
            var arr = new Point[1000];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Point() { X = rand.Next(0, 1000), Y = rand.Next(0, 1000) };
            }

            return arr;
        }

        int PointComparer(Point a, Point b)
        {
            if (a.X + a.Y > b.X + b.Y)
            {
                return 1;
            }

            if (a.X + a.Y < b.X + b.Y)
            {
                return -1;
            }

            return 0;
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void BstPoint_CannotAddValuesWithoutComparer()
        {
            var values = this.GenerateRandomPointValues();

            var bst = new BinarySearchTree<Point>();

            foreach (var i in values)
            {
                bst.Insert(i);
            }
        }

        [TestMethod]
        public void BstPoint_AddsValues()
        {
            var values = this.GenerateRandomPointValues();

            var bst = new BinarySearchTree<Point>(this.PointComparer);

            foreach (var i in values)
            {
                bst.Insert(i);
            }
        }

        [TestMethod]
        public void BstPoint_ContainsAllValues()
        {
            var values = this.GenerateRandomPointValues();

            var bst = new BinarySearchTree<Point>(this.PointComparer);

            foreach (var i in values)
            {
                bst.Insert(i);
            }

            if (bst.Count != values.Length)
            {
                Assert.Fail();
            }

            foreach (var i in values)
            {
                if (!bst.Contains(i))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void BstPoint_RemovesValuesForward()
        {
            var values = this.GenerateRandomPointValues();

            var bst = new BinarySearchTree<Point>(this.PointComparer);

            foreach (var i in values)
            {
                bst.Insert(i);
            }

            foreach (var i in values)
            {
                bst.Remove(i);
            }

            if (bst.Count != 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstPoint_RemovesValuesBackward()
        {
            var values = this.GenerateRandomPointValues();

            var bst = new BinarySearchTree<Point>(this.PointComparer);

            foreach (var i in values)
            {
                bst.Insert(i);
            }

            for (var i = values.Length - 1; i >= 0; i--)
            {
                bst.Remove(values[i]);
            }

            if (bst.Count != 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstPoint_GetsMin()
        {
            var values = this.GenerateRandomPointValues();

            var bst = new BinarySearchTree<Point>(this.PointComparer);

            foreach (var i in values)
            {
                bst.Insert(i);
            }

            bst.GetMinValue();
        }

        [TestMethod]
        public void BstPoint_GetsMax()
        {
            var values = this.GenerateRandomPointValues();

            var bst = new BinarySearchTree<Point>(this.PointComparer);

            foreach (var i in values)
            {
                bst.Insert(i);
            }

            bst.GetMaxValue();
        }

        [TestMethod]
        public void BstPoint_IteratesPreorder()
        {
            var expected = this.GenerateRandomPointValues();

            var actual = new Point[expected.Length];

            var bst = new BinarySearchTree<Point>(this.PointComparer);

            foreach (var i in expected)
            {
                bst.Insert(i);
            }

            int index = 0;

            foreach (var i in bst.GetValuesPreorder())
            {
                actual[index++] = i;
            }

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void BstPoint_IteratesInorder()
        {
            var expected = this.GenerateRandomPointValues();

            var actual = new Point[expected.Length];

            var bst = new BinarySearchTree<Point>(this.PointComparer);

            foreach (var i in expected)
            {
                bst.Insert(i);
            }

            int index = 0;

            foreach (var i in bst.GetValuesInorder())
            {
                actual[index++] = i;
            }

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void BstPoint_IteratesPostorder()
        {
            var expected = this.GenerateRandomPointValues();

            var actual = new Point[expected.Length];

            var bst = new BinarySearchTree<Point>(this.PointComparer);

            foreach (var i in expected)
            {
                bst.Insert(i);
            }

            int index = 0;

            foreach (var i in bst.GetValuesPostorder())
            {
                actual[index++] = i;
            }

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
