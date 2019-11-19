using System;
using System.Diagnostics;

namespace NET.W._2019.Shevchenko._04
{
    /// <summary>
    /// EPAM training, winter 2019, Day 4 homework.
    /// Yuri Shevchenko.
    /// </summary>
    public class Task1
    {
        /// <summary>
        /// Returns the greatest common denominator of two or more integers.
        /// Euclidean algorithm.
        /// </summary>
        public static int GcdEuclidean(out long time, int a, int b, params int[] more)
        {
            var sw = Stopwatch.StartNew();

            int d = GcdE(a, b);
            foreach (int i in more)
            {
                d = GcdE(d, i);
            }

            sw.Stop();

            time = sw.ElapsedMilliseconds;

            return d;
        }

        /// <summary>
        /// Returns the greatest common denominator of two or more integers.
        /// Binary algorithm.
        /// </summary>
        public static int GcdBinary(out long time, int a, int b, params int[] more)
        {
            var sw = Stopwatch.StartNew();

            int d = GcdB(a, b);
            foreach (int i in more)
            {
                d = GcdB(d, i);
            }

            sw.Stop();

            time = sw.ElapsedMilliseconds;

            return d;
        }

        /// <summary>
        /// Euclidean GCD implementation.
        /// </summary>
        private static int GcdE(int a, int b)
        {
            if (b == 0)
            {
                return Math.Abs(a);
            }

            return GcdE(b, a % b);
        }

        /// <summary>
        /// Binary GCD implementation.
        /// </summary>
        private static int GcdB(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            uint u = (uint)Math.Abs(a);
            uint v = (uint)Math.Abs(b);

            int shift = 0;

            while (((u | v) & 1) == 0)
            {
                shift++;
                u >>= 1;
                v >>= 1;
            }

            while ((u & 1) == 0)
            {
                u >>= 1;
            }

            do
            {
                while ((v & 1) == 0)
                {
                    v >>= 1;
                }

                if (u > v)
                {
                    uint t = v;
                    v = u;
                    u = t;
                }

                v -= u;
            }
            while (v != 0);

            return (int)(u << shift);
        }
    }
}
