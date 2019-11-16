using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NET.W._2019.Shevchenko._02.MSTests
{
    [TestClass]
    public class Task5Test
    {
        [TestMethod]
        public void FindNthRoot_1()
        {
            double expected = 1;
            double actual = Task5.FindNthRoot( 1, 5, 0.0001 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNthRoot_2()
        {
            double expected = 2;
            double actual = Task5.FindNthRoot( 8, 3, 0.0001 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNthRoot_01()
        {
            double expected = 0.1;
            double actual = Task5.FindNthRoot( 0.001, 3, 0.0001 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNthRoot_045()
        {
            double expected = 0.45;
            double actual = Task5.FindNthRoot( 0.04100625, 4, 0.0001 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNthRoot_06()
        {
            double expected = 0.6;
            double actual = Task5.FindNthRoot( 0.0279936, 7, 0.0001 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNthRoot_03()
        {
            double expected = 0.3;
            double actual = Task5.FindNthRoot( 0.0081, 4, 0.1 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNthRoot_m02()
        {
            double expected = -0.2;
            double actual = Task5.FindNthRoot( -0.008, 3, 0.1 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNthRoot_0545()
        {
            double expected = 0.545;
            double actual = Task5.FindNthRoot( 0.004241979, 9, 0.00000001 );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FindNthRoot_m7prec_OOR()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>( () => Task5.FindNthRoot( 8, 15, -7 ) );
        }

        [TestMethod]
        public void FindNthRoot_m06prec_OOR()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>( () => Task5.FindNthRoot( 8, 15, -0.6 ) );
        }
    }
}
