namespace DAL.Repositories
{
    using System;
    using DAL.Interface.DTO;

    /// <summary>
    /// Database record representation.
    /// </summary>
    public class AccountRecord : IAccountDto
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <inheritdoc/>
        public int Type { get; set; }

        /// <inheritdoc/>
        public string Owner { get; set; }

        /// <inheritdoc/>
        public decimal Balance { get; set; }

        /// <inheritdoc/>
        public decimal Bonus { get; set; }
    }
}
