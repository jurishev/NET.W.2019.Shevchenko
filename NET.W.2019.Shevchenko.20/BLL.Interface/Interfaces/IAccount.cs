namespace BLL.Interface.Interfaces
{
    using System;
    using BLL.Interface.Entities;

    /// <summary>
    /// Propetries to represent an account.
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// Gets an account's unique identifier.
        /// </summary>
        /// <value>An account's unique identifier.</value>
        Guid Id { get; }

        /// <summary>
        /// Gets an account's grade.
        /// </summary>
        /// <value>An account's grade.</value>
        AccountGrade Grade { get; }

        /// <summary>
        /// Gets an account's owner.
        /// </summary>
        /// <value>An account's owner.</value>
        string Owner { get; }

        /// <summary>
        /// Gets current balance on an account.
        /// </summary>
        /// <value>Current balance on an account.</value>
        decimal Balance { get; }

        /// <summary>
        /// Gets current bonus value on an account.
        /// </summary>
        /// <value>Current bonus value on an account.</value>
        decimal Bonus { get; }
    }
}
