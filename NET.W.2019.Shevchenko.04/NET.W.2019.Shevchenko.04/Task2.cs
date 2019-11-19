using System.Text;

namespace NET.W._2019.Shevchenko._04
{
    /// <summary>
    /// EPAM training, winter 2019, Day 4 homework.
    /// Yuri Shevchenko.
    public static class Task2
    {
        /// <summary>
        /// Converts a double to a string representation of its bits.
        /// </summary>
        public static string DoubleConverter(this double instance)
        {
            // Get integer from float
            ulong bitSequence;
            unsafe
            {
                ulong* ulongPointer = (ulong*)&instance;
                bitSequence = *ulongPointer;
            }

            // Set the mask
            ulong bit = (ulong)1 << 63;

            // Parse the bit line
            var sb = new StringBuilder();

            for (int i = 0; i < 64; i++)
            {
                if ((bitSequence & bit) == bit)
                {
                    sb.Append('1');
                }
                else
                {
                    sb.Append('0');
                }

                bit >>= 1;
            }

            return sb.ToString();
        }
    }
}
