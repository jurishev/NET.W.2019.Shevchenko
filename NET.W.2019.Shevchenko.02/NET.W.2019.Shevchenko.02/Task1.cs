using System;

namespace NET.W._2019.Shevchenko._02
{
    /// <summary>
    /// EPAM training, winter 2019, Day 2 homework.
    /// </summary>
    public static class Task1
    {
        /// <summary>
        /// Inserts a group of bits from one number to another.
        /// </summary>
        /// <param name="numSrc">Number which takes the bits</param>
        /// <param name="numIn">Bits are taken from this number, starting from 0 position</param>
        /// <param name="i">Statring bit position for numSrc</param>
        /// <param name="j">Ending bit position for numSrc</param>
        /// <returns>numSrc with a group of bits from numIn</returns>
        public static int InsertNumber( int numSrc, int numIn, int i, int j )
        {
            const int minPos = 0;
            const int maxPos = 31;

            if ( j < i || i < minPos || j < minPos || i > maxPos || j > maxPos )
                throw new Exception( "Wrong boundaries" );

            // Convert to unsigned int for logical right shift

            uint uNumIn = ( uint ) numIn;

            // Left shift and restore to cut off the useless data

            int useless = maxPos - ( j - i );

            uNumIn = uNumIn << useless >> useless;

            // Left shift to set at the proper place

            uNumIn <<= i;

            // Insert the data inside the source number

            return numSrc | ( int ) uNumIn;
        }
    }
}
