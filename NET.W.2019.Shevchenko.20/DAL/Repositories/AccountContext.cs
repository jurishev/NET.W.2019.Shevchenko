namespace DAL.Repositories
{
    using System.Data.Entity;

    /// <inheritdoc/>
    internal class AccountContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountContext"/> class.
        /// </summary>
        public AccountContext()
            : base("AccountStorage")
        {
        }

        /// <summary>
        /// Gets or sets a collection of database records.
        /// </summary>
        public DbSet<AccountRecord> AccountSet { get; set; }
    }
}
