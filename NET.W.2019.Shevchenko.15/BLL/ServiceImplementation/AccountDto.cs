namespace BLL.ServiceImplementation
{
    using System;
    using DAL.Interface.DTO;

    /// <inheritdoc/>
    public class AccountDto : IAccountDto
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
