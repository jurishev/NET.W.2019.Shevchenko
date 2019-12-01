using System.IO;

namespace NET.W2019.Shevchenko08.Task2
{
    /// <summary>
    /// The base class to create various types of bank accounts.
    /// </summary>
    public abstract class Account : IBinarySave
    {
        /// <summary>
        /// Gets or sets an account's ID.
        /// </summary>
        /// <value>An account's ID.</value>
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Gets or sets an account's owner name.
        /// </summary>
        /// <value>An account's owner name.</value>
        public virtual string Owner { get; protected set; }

        /// <summary>
        /// Gets or sets an account's balance.
        /// </summary>
        /// <value>An account's balance.</value>
        public virtual decimal Balance { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether an account is activated.
        /// </summary>
        /// <value>An account's activation status.</value>
        public virtual bool IsActivated { get; protected set; }

        /// <summary>
        /// Activates an account. An account myst be activated right after creation by a bank class.
        /// </summary>
        /// <param name="id">An account's ID.</param>
        /// <param name="owner">An account's owner name.</param>
        public abstract void Activate(int id, string owner);

        /// <summary>
        /// Makes a deposit to the current account.
        /// </summary>
        /// <param name="amount">Amount of money to be deposited.</param>
        public abstract void MakeDeposit(decimal amount);

        /// <summary>
        /// Makes a withdrawal from the current account.
        /// </summary>
        /// <param name="amount">Amount of money to be withdrawed.</param>
        public abstract void MakeWithdrawal(decimal amount);

        /// <inheritdoc/>
        public abstract void WriteBinary(BinaryWriter binWriter);

        /// <inheritdoc/>
        public abstract void ReadBinary(BinaryReader binReader);
    }
}
