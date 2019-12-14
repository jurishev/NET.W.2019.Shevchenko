using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace NET.W2019.Shevchenko13.BstTask.Tests
{
    [TestClass]
    public class BstIntTests
    {
        private static Random rand = new Random();

        int[] GenerateRandomIntValues()
        {
            var arr = new int[10000];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1, arr.Length);
            }

            return arr;
        }

        [TestMethod]
        public void BstInt_AddsValues()
        {
            var values = this.GenerateRandomIntValues();

            var bst = new BinarySearchTree<int>();

            foreach(int i in values)
            {
                bst.Insert(i);
            }
        }

        [TestMethod]
        public void BstInt_AddsValues_MyComparer()
        {
            var values = this.GenerateRandomIntValues();

            var bst = new BinarySearchTree<int>((x, y) => x < y ? -1 : x > y ? 1 : 0);

            foreach (int i in values)
            {
                bst.Insert(i);
            }
        }

        [TestMethod]
        public void BstInt_ContainsAllValues()
        {
            var values = this.GenerateRandomIntValues();

            var bst = new BinarySearchTree<int>();

            foreach (int i in values)
            {
                bst.Insert(i);
            }

            if (bst.Count != values.Length)
            {
                Assert.Fail();
            }

            foreach(int i in values)
            {
                if (!bst.Contains(i))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void BstInt_ContainsAllValues_MyComparer()
        {
            var values = this.GenerateRandomIntValues();

            var bst = new BinarySearchTree<int>((x, y) => x < y ? -1 : x > y ? 1 : 0);

            foreach (int i in values)
            {
                bst.Insert(i);
            }

            if (bst.Count != values.Length)
            {
                Assert.Fail();
            }

            foreach (int i in values)
            {
                if (!bst.Contains(i))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void BstInt_RemovesValuesForward()
        {
            var values = this.GenerateRandomIntValues();

            var bst = new BinarySearchTree<int>();

            foreach (int i in values)
            {
                bst.Insert(i);
            }

            foreach (int i in values)
            {
                bst.Remove(i);
            }

            if (bst.Count != 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstInt_RemovesValuesForward_MyComparer()
        {
            var values = this.GenerateRandomIntValues();

            var bst = new BinarySearchTree<int>((x, y) => x < y ? -1 : x > y ? 1 : 0);

            foreach (int i in values)
            {
                bst.Insert(i);
            }

            foreach (int i in values)
            {
                bst.Remove(i);
            }

            if (bst.Count != 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstInt_RemovesValuesBackward()
        {
            var values = this.GenerateRandomIntValues();

            var bst = new BinarySearchTree<int>();

            foreach (int i in values)
            {
                bst.Insert(i);
            }

            for (int i = values.Length - 1; i >= 0; i--)
            {
                bst.Remove(values[i]);
            }

            if (bst.Count != 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstInt_RemovesValuesBackward_MyComparer()
        {
            var values = this.GenerateRandomIntValues();

            var bst = new BinarySearchTree<int>((x, y) => x < y ? -1 : x > y ? 1 : 0);

            foreach (int i in values)
            {
                bst.Insert(i);
            }

            for (int i = values.Length - 1; i >= 0; i--)
            {
                bst.Remove(values[i]);
            }

            if (bst.Count != 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstInt_GetsMin()
        {
            var values = this.GenerateRandomIntValues();

            var bst = new BinarySearchTree<int>();

            foreach (int i in values)
            {
                bst.Insert(i);
            }

            if (values.Min() != bst.GetMinValue())
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstInt_GetsMax()
        {
            var values = this.GenerateRandomIntValues();

            var bst = new BinarySearchTree<int>();

            foreach (int i in values)
            {
                bst.Insert(i);
            }

            if (values.Max() != bst.GetMaxValue())
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstInt_IteratesPreorder()
        {
            var expected = this.GenerateRandomIntValues();

            var actual = new int[expected.Length];

            var bst = new BinarySearchTree<int>();

            foreach (int i in expected)
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
        public void BstInt_IteratesInorder()
        {
            var expected = this.GenerateRandomIntValues();

            var actual = new int[expected.Length];

            var bst = new BinarySearchTree<int>();

            foreach (int i in expected)
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
        public void BstInt_IteratesPostorder()
        {
            var expected = this.GenerateRandomIntValues();

            var actual = new int[expected.Length];

            var bst = new BinarySearchTree<int>();

            foreach (int i in expected)
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
