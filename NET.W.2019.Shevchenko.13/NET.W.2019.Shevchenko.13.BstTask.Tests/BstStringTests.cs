using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;

namespace NET.W2019.Shevchenko13.BstTask.Tests
{
    [TestClass]
    public class BstStringTests
    {
        private static Random rand = new Random();

        string[] GenerateRandomSringValues()
        {
            var arr = new string[100];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = this.GenerateRandomString();
            }

            return arr;
        }

        string GenerateRandomString()
        {
            var sb = new StringBuilder();

            int numberOfChars = rand.Next(1, 12);

            for (int i = 0; i < numberOfChars; i++)
            {
                sb.Append((char)rand.Next('a', 'z'));
            }

            return sb.ToString();
        }

        [TestMethod]
        public void BstString_AddsValues()
        {
            var values = this.GenerateRandomSringValues();

            var bst = new BinarySearchTree<string>();

            foreach (var i in values)
            {
                bst.Insert(i);
            }
        }

        [TestMethod]
        public void BstString_AddsValues_MyComparer()
        {
            var values = this.GenerateRandomSringValues();

            var bst = new BinarySearchTree<string>(string.Compare);

            foreach (var i in values)
            {
                bst.Insert(i);
            }
        }

        [TestMethod]
        public void BstString_ContainsAllValues()
        {
            var values = this.GenerateRandomSringValues();

            var bst = new BinarySearchTree<string>();

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
        public void BstString_RemovesValuesForward()
        {
            var values = this.GenerateRandomSringValues();

            var bst = new BinarySearchTree<string>();

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
        public void BstString_RemovesValuesBackward()
        {
            var values = this.GenerateRandomSringValues();

            var bst = new BinarySearchTree<string>();

            foreach (var i in values)
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
        public void BstString_GetsMin()
        {
            var values = this.GenerateRandomSringValues();

            var bst = new BinarySearchTree<string>();

            foreach (var i in values)
            {
                bst.Insert(i);
            }

            if (values.Min() != bst.GetMinValue())
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstString_GetsMax()
        {
            var values = this.GenerateRandomSringValues();

            var bst = new BinarySearchTree<string>();

            foreach (var i in values)
            {
                bst.Insert(i);
            }

            if (values.Max() != bst.GetMaxValue())
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstString_IteratesPreorder()
        {
            var expected = this.GenerateRandomSringValues();

            var actual = new string[expected.Length];

            var bst = new BinarySearchTree<string>();

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
        public void BstString_IteratesInorder()
        {
            var expected = this.GenerateRandomSringValues();

            var actual = new string[expected.Length];

            var bst = new BinarySearchTree<string>();

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
        public void BstString_IteratesPostorder()
        {
            var expected = this.GenerateRandomSringValues();

            var actual = new string[expected.Length];

            var bst = new BinarySearchTree<string>();

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
