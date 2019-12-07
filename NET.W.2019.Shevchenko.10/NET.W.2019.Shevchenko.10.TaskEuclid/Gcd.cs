using System;
using System.Diagnostics;

namespace NET.W2019.Shevchenko10.TaskEuclid
{
    /// <summary>
    /// Implements the greatest common denominator search for two or more integers.
    /// </summary>
    public class Gcd
    {
        /// <summary>
        /// Finds the GCD of two or more integers using the Euclidean algorithm.
        /// </summary>
        public static int Euclidean(out long time, int a, int b, params int[] more)
        {
            return CalculateGcd(EuclidianGcdImplementation, out time, a, b, more);
        }

        /// <summary>
        /// Finds the GCD of two or more integers using the binary algorithm.
        /// </summary>
        public static int Binary(out long time, int a, int b, params int[] more)
        {
            return CalculateGcd(BinaryGcdImplementation, out time, a, b, more);
        }

        private static int CalculateGcd(Func<int, int, int> gcdImp, out long time, int a, int b, params int[] more)
        {
            var sw = Stopwatch.StartNew();

            int d = gcdImp(a, b);

            foreach (int i in more)
            {
                d = gcdImp(d, i);
            }

            sw.Stop();

            time = sw.ElapsedMilliseconds;

            return d;
        }

        private static int EuclidianGcdImplementation(int a, int b)
        {
            if (b == 0)
            {
                return Math.Abs(a);
            }

            return EuclidianGcdImplementation(b, a % b);
        }

        private static int BinaryGcdImplementation(int a, int b)
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
