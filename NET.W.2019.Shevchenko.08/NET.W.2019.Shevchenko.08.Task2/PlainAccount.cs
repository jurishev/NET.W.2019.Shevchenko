using System;
using System.IO;

namespace NET.W2019.Shevchenko08.Task2
{
    /// <summary>
    /// Represents a plain bank account without any fancy features.
    /// </summary>
    public class PlainAccount : Account
    {
        /// <inheritdoc/>
        public override void Activate(int id, string owner)
        {
            if (this.IsActivated)
            {
                throw new ArgumentException("The account is already activated");
            }

            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentException("No owner name has been provided.");
            }

            this.Id = id;
            this.Owner = owner;
            this.IsActivated = true;
        }

        /// <inheritdoc/>
        public override void MakeDeposit(decimal amount)
        {
            this.Balance += amount;
        }

        /// <inheritdoc/>
        public override void MakeWithdrawal(decimal amount)
        {
            this.Balance -= amount;
        }

        /// <inheritdoc/>
        public override void WriteBinary(BinaryWriter binWriter)
        {
            if (binWriter is null)
            {
                throw new ArgumentException("No BinaryWriter has been provided.");
            }

            binWriter.Write(this.Id);
            binWriter.Write(this.Owner);
            binWriter.Write(this.Balance);
            binWriter.Write(this.IsActivated);
        }

        /// <inheritdoc/>
        public override void ReadBinary(BinaryReader binReader)
        {
            if (binReader is null)
            {
                throw new ArgumentException("No BinaryReader has been provided.");
            }

            this.Id = binReader.ReadInt32();
            this.Owner = binReader.ReadString();
            this.Balance = binReader.ReadDecimal();
            this.IsActivated = binReader.ReadBoolean();
        }
    }
}
