using System;
using System.Linq;

namespace NET.W._2019.Shevchenko._02
{
    /// <summary>
    /// EPAM training, winter 2019, Day 2 homework.
    /// </summary>
    public static class Task2
    {
        /// <summary>
        /// Finds next bigger number consisting from the same digits
        /// </summary>
        public static int FindNextBiggerNumber( int num )
        {
            if ( num < 0 )
                throw new Exception( "The input number must be positive" );

            if ( num < 12 )
                return -1;

            // Convert the number to a string and convert each symbol into an integer

            int[] arr = num.ToString().ToArray().Select( c => c - '0' ).ToArray();

            // Iterate from the end of the array

            for ( int i = arr.Length - 1; i > 0; i-- ) {

                // When a previous number is bigger than the next one, swap them

                if ( arr[ i ] > arr[ i - 1 ] ) {

                    int temp = arr[ i ];
                    arr[ i ] = arr[ i - 1 ];
                    arr[ i - 1 ] = temp;

                    // Sort and attach the tail

                    var tail = arr.Skip( i ).OrderBy( x => x );
                    arr = arr.Take( i ).Concat( tail ).ToArray();

                    // Yield the number

                    int result = 0;

                    for ( int j = arr.Length - 1, power = 1; j >= 0; j-- ) {
                        result += arr[ j ] * power;
                        power *= 10;
                    }

                    return result;
                }
            }

            return -1;
        }
    }
}
