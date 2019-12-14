using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W2019.Shevchenko13.QueueTask.Tests
{
    [TestClass]
    public class QueueTests
    {
        private int[] intArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private string[] stringArray = new string[] { "one", "two", "three", "four", "five" };

        [TestMethod]
        public void Test_QueueOneElement()
        {
            var queue = new Queue<double>();

            double expected = 3.1416;

            queue.Enqueue(expected);

            double actual = queue.Dequeue();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_QueueSeveralElements()
        {
            var queue = new Queue<int>();
            var expected = this.intArray;

            foreach (int i in expected)
            {
                queue.Enqueue(i);
            }

            var actual = new int[expected.Length];

            for (int i = 0; i < expected.Length; i++)
            {
                actual[i] = queue.Dequeue();
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Iteration()
        {
            var queue = new Queue<int>();
            var expected = this.intArray;

            foreach (int i in expected)
            {
                queue.Enqueue(i);
            }

            var actual = new int[expected.Length];
            int index = 0;

            foreach (int i in queue)
            {
                actual[index++] = i;
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ReferenceItemsQueue()
        {
            var queue = new Queue<string>();
            var expected = this.stringArray;

            foreach(var s in expected)
            {
                queue.Enqueue(s);
            }

            var actual = new string[expected.Length];

            for (int i = 0; i < expected.Length; i++)
            {
                actual[i] = queue.Dequeue();
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ReferenceItemsIteration()
        {
            var queue = new Queue<string>();
            var expected = this.stringArray;

            foreach (var s in expected)
            {
                queue.Enqueue(s);
            }

            var actual = new string[expected.Length];
            int index = 0;

            foreach (var s in queue)
            {
                actual[index++] = s;
            }

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
