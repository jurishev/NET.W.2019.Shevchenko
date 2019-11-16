using System.Diagnostics;

namespace NET.W._2019.Shevchenko._02
{
    /// <summary>
    /// EPAM training, winter 2019, Day 2 homework.
    /// </summary>
    public static class Task3
    {
        /// <summary>
        /// FindNextBiggerNumber method with execution time measuring
        /// </summary>
        public static int FindNextBiggerNumberTimer( int num, out long time )
        {
            var sw = Stopwatch.StartNew();
            num = Task2.FindNextBiggerNumber( num );
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return num;
        }
    }
}
