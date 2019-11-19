using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W._2019.Shevchenko._04.Tests
{
    /// <summary>
    /// EPAM training, winter 2019, Day 4 homework.
    /// Yuri Shevchenko.
    /// </summary>
    [TestClass]
    public class Task1Tests
    {
        [TestMethod]
        public void GcdEuclid_4numbers()
        {
            int expected = 6;
            Assert.AreEqual(expected, Task1.GcdEuclidean(out long time, 78, 294, 570, 36));
            Console.WriteLine(time + " ms");
        }

        [TestMethod]
        public void GcdEuclid_m231_m140()
        {
            int expected = 7;
            Assert.AreEqual(expected, Task1.GcdEuclidean(out long time, -231, -140));
            Console.WriteLine(time + " ms");
        }

        [TestMethod]
        public void GcdBinary_4numbers()
        {
            int expected = 6;
            Assert.AreEqual(expected, Task1.GcdBinary(out long time, 78, 294, 570, 36));
            Console.WriteLine(time + " ms");
        }

        [TestMethod]
        public void GcdBinary_m231_m140()
        {
            int expected = 7;
            Assert.AreEqual(expected, Task1.GcdBinary(out long time, -231, -140));
            Console.WriteLine(time + " ms");
        }
    }
}
