using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace NET.W._2019.Shevchenko._02.MSTests
{
    [TestClass]
    public class Task4Test
    {
        [TestMethod]
        public void FilterDigit_7()
        {
            var collection = new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            var expected = new int[] { 7, 70, 17 };

            var actual = Task4.FilterDigit( collection, 7 ).ToArray();

            CollectionAssert.AreEqual( expected, actual );
        }

        [TestMethod]
        public void FilterDigit_8()
        {
            var collection = new int[] { 8, 81, 67582, 53, 81, 2324, 8, 3335, 81, 86 };
            var expected = new int[] { 8, 81, 67582, 86 };

            var actual = Task4.FilterDigit( collection, 8 ).ToArray();

            CollectionAssert.AreEqual( expected, actual );
        }
    }
}
