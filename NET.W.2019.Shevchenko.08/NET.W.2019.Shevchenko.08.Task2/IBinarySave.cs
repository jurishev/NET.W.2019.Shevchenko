using System.IO;

namespace NET.W2019.Shevchenko08.Task2
{
    /// <summary>
    /// The binary reader/writer interface for account types.
    /// </summary>
    public interface IBinarySave
    {
        /// <summary>
        /// Writes the current account's data to a binary stream.
        /// </summary>
        /// <param name="binWriter">The stream to write to.</param>
        void WriteBinary(BinaryWriter binWriter);

        /// <summary>
        /// Reads data for the current account from a binary stream.
        /// </summary>
        /// <param name="binReader">The sream to read from.</param>
        void ReadBinary(BinaryReader binReader);
    }
}
