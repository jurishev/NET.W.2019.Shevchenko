using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W._2019.Shevchenko._02.MSTests
{
    [TestClass]
    public class Task2Test
    {
        [TestMethod]
        public void FindNextBiggerNumber_12_21()
        {
            int expected = 21;
            int actual = Task2.FindNextBiggerNumber( 12 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNextBiggerNumber_513_531()
        {
            int expected = 531;
            int actual = Task2.FindNextBiggerNumber( 513 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNextBiggerNumber_2017_2071()
        {
            int expected = 2071;
            int actual = Task2.FindNextBiggerNumber( 2017 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNextBiggerNumber_414_441()
        {
            int expected = 441;
            int actual = Task2.FindNextBiggerNumber( 414 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNextBiggerNumber_144_414()
        {
            int expected = 414;
            int actual = Task2.FindNextBiggerNumber( 144 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNextBiggerNumber_1234321_1241233()
        {
            int expected = 1241233;
            int actual = Task2.FindNextBiggerNumber( 1234321 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNextBiggerNumber_1234126_1234162()
        {
            int expected = 1234162;
            int actual = Task2.FindNextBiggerNumber( 1234126 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNextBiggerNumber_3456432_3462345()
        {
            int expected = 3462345;
            int actual = Task2.FindNextBiggerNumber( 3456432 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNextBiggerNumber_10_m1()
        {
            int expected = -1;
            int actual = Task2.FindNextBiggerNumber( 10 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNextBiggerNumber_20_m1()
        {
            int expected = -1;
            int actual = Task2.FindNextBiggerNumber( 20 );
            Assert.AreEqual( expected, actual );
        }
    }
}
