using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W._2019.Shevchenko._01.Tests
{
    /// <summary>
    /// Unit tests for Sorting Class in NET.W.2019.Shevchenko.01 project.
    /// </summary>
    [TestClass]
    public class SortingTests
    {
        private readonly int[] threeDigits = new int[] { 3, 2, 1 };
        private readonly int[] tenDigits = new int[] { 5, 3, 1, 6, 4, 2, 9, 8, 7, 0 };
        private readonly int[] tenDigitsWorstCase = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        private int[] RandomNumbers()
        {
            int[] numbers = new int[ 100 ];
            Random random = new Random();

            for ( int i = 0; i < numbers.Length; i++ ) {
                numbers[ i ] = random.Next( int.MinValue, int.MaxValue );
            }

            return numbers;
        }
        private void ShowData( string msg, int[] data )
        {
            Console.WriteLine( msg );
            foreach ( int i in data )
                Console.Write( $"{i} " );
            Console.WriteLine();
        }

        /// <summary>
        /// Simple case with three integers
        /// </summary>
        [TestMethod]
        public void QuickSort_ThreeDigits()
        {
            // Arrange

            int[] actual = threeDigits.ToArray();
            int[] expected = actual.ToArray();
            Array.Sort( expected );

            ShowData( "Initial array:", actual );

            // Act

            actual = Sorting.QuickSort( actual );

            ShowData( "Sorted array:", actual );

            // Assert

            CollectionAssert.AreEqual( expected, actual );
        }

        /// <summary>
        /// Ten unsorted integers
        /// </summary>
        [TestMethod]
        public void QuickSort_TenDigits()
        {
            // Arrange

            int[] actual = tenDigits.ToArray();
            int[] expected = actual.ToArray();
            Array.Sort( expected );

            ShowData( "Initial array:", actual );

            // Act

            actual = Sorting.QuickSort( actual );

            ShowData( "Sorted array:", actual );

            // Assert

            CollectionAssert.AreEqual( expected, actual );
        }

        /// <summary>
        /// Ten integers in descending order
        /// </summary>
        [TestMethod]
        public void QuickSort_TenDigitsWorstCase()
        {
            // Arrange

            int[] actual = tenDigitsWorstCase.ToArray();
            int[] expected = actual.ToArray();
            Array.Sort( expected );

            ShowData( "Initial array:", actual );

            // Act

            actual = Sorting.QuickSort( actual );

            ShowData( "Sorted array:", actual );

            // Assert

            CollectionAssert.AreEqual( expected, actual );
        }

        /// <summary>
        /// 100 random integers in random order
        /// </summary>
        [TestMethod]
        public void QuickSort_RandomNumbers()
        {
            // Arrange

            int[] actual = RandomNumbers();
            int[] expected = actual.ToArray();
            Array.Sort( expected );

            ShowData( "Initial array:", actual );

            // Act

            actual = Sorting.QuickSort( actual );

            ShowData( "Sorted array:", actual );

            // Assert

            CollectionAssert.AreEqual( expected, actual );
        }

        /// <summary>
        /// Simple case with three integers
        /// </summary>
        [TestMethod]
        public void MergeSort_ThreeDigits()
        {
            // Arrange

            int[] actual = new int[] { 5, 3, 1 };
            int[] expected = new int[] { 1, 3, 5 };

            ShowData( "Initial array:", actual );

            // Act

            actual = Sorting.MergeSort( actual );

            ShowData( "Sorted array:", actual );

            // Assert

            CollectionAssert.AreEqual( expected, actual );
        }

        /// <summary>
        /// Ten unsorted integers
        /// </summary>
        [TestMethod]
        public void MergeSort_TenDigits()
        {
            // Arrange

            int[] actual = tenDigits.ToArray();
            int[] expected = actual.ToArray();
            Array.Sort( expected );

            ShowData( "Initial array:", actual );

            // Act

            actual = Sorting.MergeSort( actual );

            ShowData( "Sorted array:", actual );

            // Assert

            CollectionAssert.AreEqual( expected, actual );
        }

        /// <summary>
        /// Ten integers in descending order
        /// </summary>
        [TestMethod]
        public void MergeSort_TenDigitsWorstCase()
        {
            // Arrange

            int[] actual = tenDigitsWorstCase.ToArray();
            int[] expected = actual.ToArray();
            Array.Sort( expected );

            ShowData( "Initial array:", actual );

            // Act

            actual = Sorting.MergeSort( actual );

            ShowData( "Sorted array:", actual );

            // Assert

            CollectionAssert.AreEqual( expected, actual );
        }

        /// <summary>
        /// 100 random integers in random order
        /// </summary>
        [TestMethod]
        public void MergeSort_RandomNumbers()
        {
            // Arrange

            int[] actual = RandomNumbers();
            int[] expected = actual.ToArray();
            Array.Sort( expected );

            ShowData( "Initial array:", actual );

            // Act

            actual = Sorting.MergeSort( actual );

            ShowData( "Sorted array:", actual );

            // Assert

            CollectionAssert.AreEqual( expected, actual );
        }
    }
}
