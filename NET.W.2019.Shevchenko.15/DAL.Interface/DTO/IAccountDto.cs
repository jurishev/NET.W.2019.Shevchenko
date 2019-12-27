namespace DAL.Interface.DTO
{
    using System;

    /// <summary>
    /// Account data transfer object template.
    /// </summary>
    public interface IAccountDto
    {
        /// <summary>
        /// Gets or sets an account's ID.
        /// </summary>
        /// <value>An account's ID.</value>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets an account's type identifier.
        /// </summary>
        /// <value>An account's type identifier.</value>
        int Type { get; set; }

        /// <summary>
        /// Gets or sets an account's owner.
        /// </summary>
        /// <value>An account's owner.</value>
        string Owner { get; set; }

        /// <summary>
        /// Gets or sets an account's current balance.
        /// </summary>
        /// <value>An account's current balance.</value>
        decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets an account's current bonus amount.
        /// </summary>
        /// <value>An account's current bonus amount.</value>
        decimal Bonus { get; set; }
    }
}
