using System;
using System.IO;

namespace NET.W2019.Shevchenko08.Task2
{
    /// <summary>
    /// Represents a graded account type.
    /// Deposits and withdrawals influence the amount of the bonus points.
    /// </summary>
    public class GradedAccount : Account
    {
        /// <summary>
        /// Grade types of accounts.
        /// </summary>
        public enum Grade
        {
            /// <summary>
            /// You lose more points when withdraw than gain some when deposit.
            /// </summary>
            Base,

            /// <summary>
            /// You gain a bit more point when deposit than lose when withdraw.
            /// </summary>
            Gold,

            /// <summary>
            /// You gain considrably more points when deposit than lose when withdaw.
            /// </summary>
            Platinum,
        }

        /// <summary>
        /// Gets the account's current grade.
        /// </summary>
        /// <value>The account's current grade.</value>
        public Grade CurrentGrade { get; private set; }

        /// <summary>
        /// Gets the account's bonus points.
        /// </summary>
        /// <value>The account's bonus points.</value>
        public decimal BonusPoints { get; private set; }

        /// <summary>
        /// Gets the account's bonus factor.
        /// </summary>
        /// <value>The account's bonus factor.</value>
        public decimal BonusFactor { get; private set; }

        private int BalanceCost { get; set; }

        private int DepositCost { get; set; }

        /// <summary>
        /// Sets the account's current grade.
        /// </summary>
        /// <param name="value">The grade value to set.</param>
        public void SetGrade(Grade value)
        {
            switch (value)
            {
                case Grade.Base:
                    this.BalanceCost = 30;
                    this.DepositCost = 20;
                    this.BonusFactor = 0.01M;
                    break;

                case Grade.Gold:
                    this.BalanceCost = 20;
                    this.DepositCost = 30;
                    this.BonusFactor = 0.02M;
                    break;

                case Grade.Platinum:
                    this.BalanceCost = 10;
                    this.DepositCost = 40;
                    this.BonusFactor = 0.03M;
                    break;

                default:
                    throw new ArgumentException("Wrong grade value.");
            }

            this.CurrentGrade = value;
        }

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
            if (amount <= 0)
            {
                throw new ArgumentException("Amount for a deposit must be positive.");
            }

            this.Balance += amount;
            this.BonusPoints += this.CalculateDepositBonus(amount);
        }

        /// <inheritdoc/>
        public override void MakeWithdrawal(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount for a withdrawal must be positive.");
            }

            if (amount > this.Balance)
            {
                throw new ArgumentException("Amount for a withdrawal is too high.");
            }

            this.Balance -= amount;
            this.BonusPoints -= this.CalculateWithdrawalCost(amount);
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
            binWriter.Write(this.BonusPoints);
            binWriter.Write((int)this.CurrentGrade);
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
            this.BonusPoints = binReader.ReadDecimal();
            this.SetGrade((Grade)binReader.ReadInt32());
        }

        private decimal CalculateDepositBonus(decimal depositAmount)
        {
            return (depositAmount * this.BonusFactor) * (this.DepositCost * this.BonusFactor);
        }

        private decimal CalculateWithdrawalCost(decimal withdrawalAmount)
        {
            return (withdrawalAmount * this.BonusFactor) * (this.BalanceCost * this.BonusFactor);
        }
    }
}
