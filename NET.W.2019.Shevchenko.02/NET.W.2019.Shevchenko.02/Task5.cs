using System;

namespace NET.W._2019.Shevchenko._02
{
    /// <summary>
    /// EPAM training, winter 2019, Day 2 homework.
    /// </summary>
    public static class Task5
    {
        /// <summary>
        /// Finds a given degree number root with a given precision
        /// </summary>
        public static double FindNthRoot( double number, double degree, double precision )
        {
            // Check the arguments

            if ( number == 0 )
                throw new ArgumentOutOfRangeException( nameof( number ), "Must not be zero" );

            if ( degree <= 0 )
                throw new ArgumentOutOfRangeException( nameof( degree ), "Must be positive" );

            if ( precision <= 0 )
                throw new ArgumentOutOfRangeException( nameof( precision ), "Must be positive" );

            // Prepare

            double guess = Math.Sign( number ); // 1 or -1
            double rate = 1;

            double check;
            int digits = 0;

            // Set rounding precision for check

            if ( Math.Round( number ) != number )
                digits = Math.Abs( number ).ToString().Length - 2;

            // Increase guess by rate while it's less than number

            while ( true ) {

                check = Math.Pow( guess, degree );

                // Return exact number

                if ( Math.Round( check, digits ) == number )
                    return Math.Round( guess, 4 );

                if ( check < number ) {
                    guess += rate;
                    continue;
                }

                // Lower guess increase rate until it's lower than precision

                guess -= rate;
                rate *= 0.1;

                if ( rate < precision )
                    break;

                guess += rate;
            }

            // Return most precise number

            return Math.Round( guess, 4 );
        }
    }
}
