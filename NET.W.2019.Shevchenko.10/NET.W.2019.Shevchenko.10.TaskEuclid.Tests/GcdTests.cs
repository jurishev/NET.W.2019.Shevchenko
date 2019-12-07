using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W2019.Shevchenko10.TaskEuclid.Tests
{
    [TestClass]
    public class GcdTests
    {
        [TestMethod]
        public void GcdEuclid_4numbers()
        {
            int expected = 6;
            int actual = Gcd.Euclidean(out long time, 78, 294, 570, 36);

            Assert.AreEqual(expected, actual);

            Console.WriteLine(time + " ms");
        }

        [TestMethod]
        public void GcdEuclid_m231_m140()
        {
            int expected = 7;
            int actual = Gcd.Euclidean(out long time, -231, -140);

            Assert.AreEqual(expected, actual);

            Console.WriteLine(time + " ms");
        }

        [TestMethod]
        public void GcdBinary_4numbers()
        {
            int expected = 6;
            int actual = Gcd.Binary(out long time, 78, 294, 570, 36);

            Assert.AreEqual(expected, actual);

            Console.WriteLine(time + " ms");
        }

        [TestMethod]
        public void GcdBinary_m231_m140()
        {
            int expected = 7;
            int actual = Gcd.Binary(out long time, -231, -140);

            Assert.AreEqual(expected, actual);

            Console.WriteLine(time + " ms");
        }
    }
}
