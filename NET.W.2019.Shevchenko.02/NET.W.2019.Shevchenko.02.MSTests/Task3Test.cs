using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NET.W._2019.Shevchenko._02.MSTests
{
    [TestClass]
    public class Task3Test
    {
        [TestMethod]
        public void FindNextBiggerNumberTimer_12_21()
        {
            int expected = 21;
            int actual = Task3.FindNextBiggerNumberTimer( 12, out long time );
            Console.WriteLine( $"Time of execution: {time} ms" );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNextBiggerNumberTimer_2017_2071()
        {
            int expected = 2071;
            int actual = Task3.FindNextBiggerNumberTimer( 2017, out long time );
            Console.WriteLine( $"Time of execution: {time} ms" );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNextBiggerNumberTimer_3456432_3462345()
        {
            int expected = 3462345;
            int actual = Task3.FindNextBiggerNumberTimer( 3456432, out long time );
            Console.WriteLine( $"Time of execution: {time} ms" );
            Assert.AreEqual( expected, actual );
        }
    }
}
