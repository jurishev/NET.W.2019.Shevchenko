using NUnit.Framework;
using NET.W._2019.Shevchenko._02;

namespace Tests
{
    public class Task1TestNUnit
    {
        [Test]
        public void InsertNumber_15_15_0_0___15()
        {
            int expected = 15;
            int actual = Task1.InsertNumber( 15, 15, 0, 0 );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void InsertNumber_8_15_0_0___9()
        {
            int expected = 9;
            int actual = Task1.InsertNumber( 8, 15, 0, 0 );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void InsertNumber_8_15_3_8___120()
        {
            int expected = 120;
            int actual = Task1.InsertNumber( 8, 15, 3, 8 );
            Assert.AreEqual( expected, actual );
        }
    }
}