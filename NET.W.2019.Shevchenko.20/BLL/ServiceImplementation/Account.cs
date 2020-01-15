namespace BLL.ServiceImplementation
{
    using System;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;

    /// <inheritdoc/>
    public class Account : IAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="id">An account's ID.</param>
        /// <param name="grade">An account's grade.</param>
        /// <param name="owner">An account's owner.</param>
        /// <param name="balance">An account's current balance.</param>
        /// <param name="bonus">An account's current bonus value.</param>
        public Account(Guid id, AccountGrade grade, string owner, decimal balance, decimal bonus)
        {
            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentNullException(nameof(owner));
            }

            this.Id = id;
            this.Grade = grade;
            this.Owner = owner;
            this.Balance = balance;
            this.Bonus = bonus;
        }

        /// <inheritdoc/>
        public Guid Id { get; }

        /// <inheritdoc/>
        public AccountGrade Grade { get; }

        /// <inheritdoc/>
        public string Owner { get; }

        /// <inheritdoc/>
        public decimal Balance { get; }

        /// <inheritdoc/>
        public decimal Bonus { get; }
    }
}
