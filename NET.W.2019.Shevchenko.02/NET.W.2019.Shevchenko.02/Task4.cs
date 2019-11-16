using System;
using System.Collections.Generic;

namespace NET.W._2019.Shevchenko._02
{
    /// <summary>
    /// EPAM training, winter 2019, Day 2 homework.
    /// </summary>
    public static class Task4
    {
        /// <summary>
        /// Returns numbers from a given list that contain a given digit
        /// </summary>
        public static HashSet<int> FilterDigit( IEnumerable<int> list, int digit )
        {
            // Check

            if ( list == null )
                throw new Exception( "Nothing to filter" );

            if ( digit < 0 || digit > 9 )
                throw new Exception( "The digit is out of range (must be from 0 to 9)" );

            // Filter

            var set = new HashSet<int>();
            string check = digit.ToString();

            foreach ( int i in list )
                if ( i.ToString().Contains( check ) )
                    if ( !set.Contains( i ) )
                        set.Add( i );

            return set;
        }
    }
}
