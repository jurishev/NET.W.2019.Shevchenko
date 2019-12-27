namespace DAL.Fake.Repositories
{
    using System;
    using DAL.Interface.DTO;

    /// <inheritdoc/>
    internal class FakeAccountDto : IAccountDto
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
