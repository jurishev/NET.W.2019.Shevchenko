using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W2019.Shevchenko06.Tests
{
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod]
        public void Polynomial_Create_CreatesInstance()
        {
            Polynomial notExpected = null;

            if (notExpected == Polynomial.Create("12"))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Polynomial_Create_ParsesConstant()
        {
            string formatA = "12";
            string formatB = "12x^0";
            double expected = 12d;
            int index = 0;

            Assert.AreEqual(expected, Polynomial.Create(formatA)[index]);
            Assert.AreEqual(expected, Polynomial.Create(formatB)[index]);
        }

        [TestMethod]
        public void Polynomial_Create_ParsesXpower1()
        {
            string formatA = "12x";
            string formatB = "12x^1";

            int index = 1;
            double expected = 12d;

            Assert.AreEqual(expected, Polynomial.Create(formatA)[index]);
            Assert.AreEqual(expected, Polynomial.Create(formatB)[index]);
        }

        [TestMethod]
        public void Polynomial_Create_ParsesXpower2()
        {
            string format = "12x^2";

            int index = 2;
            double expected = 12d;

            Assert.AreEqual(expected, Polynomial.Create(format)[index]);
        }

        [TestMethod]
        public void Polynomial_Create_ParsesNegativeFractionXpower7()
        {
            string format = "-437,675x^7";

            int index = 7;
            double expected = -437.675d;

            Assert.AreEqual(expected, Polynomial.Create(format)[index]);
        }

        [TestMethod]
        public void Polynomial_Create_Parses0Xpower3Correctly()
        {
            string format = "0x^3";

            int index = 2;
            double expected = 0;

            Assert.AreEqual(expected, Polynomial.Create(format)[index]);
        }

        [TestMethod]
        public void Polynomial_Create_Parses0Xpower543Correctly()
        {
            string format = "0x^543";

            int index = 542;
            double expected = 0;

            Assert.AreEqual(expected, Polynomial.Create(format)[index]);
        }

        [TestMethod]
        public void Polynomial_Create_ParsesSeveralCorrectly()
        {
            string format = "6x^5 4x^5 2x^2";

            int indexA = 5;
            double expectedA = 10d;

            int indexB = 2;
            double expectedB = 2;

            Assert.AreEqual(expectedA, Polynomial.Create(format)[indexA]);
            Assert.AreEqual(expectedB, Polynomial.Create(format)[indexB]);
        }

        [TestMethod]
        public void Polynomial_Create_ParsesManyCorrectly()
        {
            string format = "-343,654x^5 5435,5345 +34,6x^4 -54,45x +232x^2 -543,2x^4 6";

            int index0 = 0;
            double expected0 = 5441.5345d;

            int index1 = 1;
            double expected1 = -54.45d;

            int index2 = 2;
            double expected2 = 232d;

            int index3 = 3;
            double expected3 = 0;

            int index4 = 4;
            double expected4 = -508.6d;

            int index5 = 5;
            double expected5 = -343.654d;

            Assert.AreEqual(expected0, Polynomial.Create(format)[index0]);
            Assert.AreEqual(expected1, Polynomial.Create(format)[index1]);
            Assert.AreEqual(expected2, Polynomial.Create(format)[index2]);
            Assert.AreEqual(expected3, Polynomial.Create(format)[index3]);
            Assert.AreEqual(expected4, Polynomial.Create(format)[index4]);
            Assert.AreEqual(expected5, Polynomial.Create(format)[index5]);
        }

        [TestMethod]
        public void Polynomial_Create_ParsesSingles()
        {
            string format = "-x 3";

            int index0 = 0;
            int expected0 = 3;

            int index1 = 1;
            int expected1 = -1;

            Assert.AreEqual(expected0, Polynomial.Create(format)[index0]);
            Assert.AreEqual(expected1, Polynomial.Create(format)[index1]);
        }

        [TestMethod]
        public void Polynomial_Create_ParsesMinusOneInPower()
        {
            string format = "-x^2 -x -1x^1";

            int index0 = 0;
            int expected0 = 0;

            int index1 = 1;
            int expected1 = -2;

            int index2 = 2;
            int expected2 = -1;

            Assert.AreEqual(expected0, Polynomial.Create(format)[index0]);
            Assert.AreEqual(expected1, Polynomial.Create(format)[index1]);
            Assert.AreEqual(expected2, Polynomial.Create(format)[index2]);
        }

        [TestMethod]
        public void Polynomial_Multiply1()
        {
            var a = Polynomial.Create("x 3");
            var b = Polynomial.Create("2x^3 -4x^2 x 1");
            var expected = Polynomial.Create("2x^4 2x^3 -11x^2 4x 3");

            Assert.AreEqual(expected, a * b);
        }

        [TestMethod]
        public void Polynomial_Multiply2()
        {
            var a = Polynomial.Create("x -1");
            var b = Polynomial.Create("3x^3 -5x^2 6x -1");
            var expected = Polynomial.Create("3x^4 -8x^3 11x^2 -7x 1");

            Assert.AreEqual(expected, a * b);
        }

        [TestMethod]
        public void Polynomial_Multiply3()
        {
            var a = Polynomial.Create("-4x^3 -x^2");
            var b = Polynomial.Create("8x^2 -9");
            var expected = Polynomial.Create("-32x^5 -8x^4 36x^3 9x^2");

            Assert.AreEqual(expected, a * b);

            a *= b;

            Assert.AreEqual(expected, a);
        }

        [TestMethod]
        public void Polynomial_Add1()
        {
            var a = Polynomial.Create("-2x^2 4x -12");
            var b = Polynomial.Create("7x x^2");
            var expected = Polynomial.Create("-x^2 11x -12");

            Assert.AreEqual(expected, a + b);
        }

        [TestMethod]
        public void Polynomial_Add2()
        {
            var a = Polynomial.Create("5x^2 8x -3");
            var b = Polynomial.Create("2x^2 -7x 13x");
            var expected = Polynomial.Create("7x^2 14x -3");

            Assert.AreEqual(expected, a + b);
        }

        [TestMethod]
        public void Polynomial_Subtract1()
        {
            var a = Polynomial.Create("16x 14");
            var b = Polynomial.Create("3x^2 x -9");
            var expected = Polynomial.Create("-3x^2 15x 23");

            Assert.AreEqual(expected, a - b);
        }

        [TestMethod]
        public void Polynomial_ToString()
        {
            var p = Polynomial.Create("-x^2 -12 x");
            Console.WriteLine(p.ToString());
        }

        [TestMethod]
        public void Polynomial_Equals1()
        {
            var a = Polynomial.Create("-x^2 -12 x");
            var b = Polynomial.Create("-x^2 -12 x");

            Assert.AreEqual(a, b);
            Assert.AreEqual(a == b, a.Equals(b));
        }

        [TestMethod]
        public void Polynomial_Equals2()
        {
            var a = Polynomial.Create("-x^2 -12 x");
            var b = Polynomial.Create("-x^2 1 -10 2x -2 -x -1");

            Assert.AreEqual(a, b);
            Assert.AreEqual(a == b, a.Equals(b));
        }

        [TestMethod]
        public void Polynomial_Sum()
        {
            double actual = Math.Round(Polynomial.Create("-3x^2 15x^3 23,567").CalculateSum(4), 3);
            double expected = 935.567;

            Assert.AreEqual(expected, actual);
        }
    }
}
