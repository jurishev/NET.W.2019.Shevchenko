using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W._2019.Shevchenko._04.Tests
{
    /// <summary>
    /// EPAM training, winter 2019, Day 4 homework.
    /// Yuri Shevchenko.
    /// </summary>
    [TestClass]
    public class Task2Tests
    {
        [TestMethod]
        public void DoubleConverter_m255d255()
        {
            double input = -255.255;
            string expected = "1100000001101111111010000010100011110101110000101000111101011100";
            Assert.AreEqual(expected, input.DoubleConverter());
        }

        [TestMethod]
        public void DoubleConverter_255d255()
        {
            double input = 255.255;
            string expected = "0100000001101111111010000010100011110101110000101000111101011100";
            Assert.AreEqual(expected, input.DoubleConverter());
        }

        [TestMethod]
        public void DoubleConverter_4294967295d0()
        {
            double input = 4294967295.0;
            string expected = "0100000111101111111111111111111111111111111000000000000000000000";
            Assert.AreEqual(expected, input.DoubleConverter());
        }

        [TestMethod]
        public void DoubleConverter_MinVal()
        {
            double input = double.MinValue;
            string expected = "1111111111101111111111111111111111111111111111111111111111111111";
            Assert.AreEqual(expected, input.DoubleConverter());
        }

        [TestMethod]
        public void DoubleConverter_MaxVal()
        {
            double input = double.MaxValue;
            string expected = "0111111111101111111111111111111111111111111111111111111111111111";
            Assert.AreEqual(expected, input.DoubleConverter());
        }

        [TestMethod]
        public void DoubleConverter_Epsilon()
        {
            double input = double.Epsilon;
            string expected = "0000000000000000000000000000000000000000000000000000000000000001";
            Assert.AreEqual(expected, input.DoubleConverter());
        }

        [TestMethod]
        public void DoubleConverter_NaN()
        {
            double input = double.NaN;
            string expected = "1111111111111000000000000000000000000000000000000000000000000000";
            Assert.AreEqual(expected, input.DoubleConverter());
        }

        [TestMethod]
        public void DoubleConverter_NegativeInfinity()
        {
            double input = double.NegativeInfinity;
            string expected = "1111111111110000000000000000000000000000000000000000000000000000";
            Assert.AreEqual(expected, input.DoubleConverter());
        }

        [TestMethod]
        public void DoubleConverter_PositiveInfinity()
        {
            double input = double.PositiveInfinity;
            string expected = "0111111111110000000000000000000000000000000000000000000000000000";
            Assert.AreEqual(expected, input.DoubleConverter());
        }

        [TestMethod]
        public void DoubleConverter_m0()
        {
            double input = -0.0;
            string expected = "1000000000000000000000000000000000000000000000000000000000000000";
            Assert.AreEqual(expected, input.DoubleConverter());
        }

        [TestMethod]
        public void DoubleConverter_0()
        {
            double input = 0.0;
            string expected = "0000000000000000000000000000000000000000000000000000000000000000";
            Assert.AreEqual(expected, input.DoubleConverter());
        }
    }
}
