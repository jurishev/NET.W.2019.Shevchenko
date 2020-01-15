namespace BLL.Interface.Interfaces
{
    using System;
    using System.Collections.Generic;
    using BLL.Interface.Entities;

    /// <summary>
    /// Account manipulation functionality.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Creates a new account.
        /// </summary>
        /// <param name="owner">The account's owner name.</param>
        /// <param name="grade">The account's grade.</param>
        /// <param name="generator">ID generator service.</param>
        void OpenAccount(string owner, AccountGrade grade, IAccountIdGenerator generator);

        /// <summary>
        /// Deletes an account.
        /// </summary>
        /// <param name="id">ID of an account to delete.</param>
        void CloseAccount(Guid id);

        /// <summary>
        /// Deposits provided value to an account.
        /// </summary>
        /// <param name="id">ID of the account to deposit to.</param>
        /// <param name="amount">Value to deposit.</param>
        void MakeDeposit(Guid id, decimal amount);

        /// <summary>
        /// Withdraw provided value from an account.
        /// </summary>
        /// <param name="id">ID of the account to withdraw from.</param>
        /// <param name="amount">Value to withdraw.</param>
        void MakeWithdrawal(Guid id, decimal amount);

        /// <summary>
        /// Sets an account's grade to a certain value.
        /// </summary>
        /// <param name="id">ID of the account to be set.</param>
        /// <param name="grade">The value to set.</param>
        void SetGrade(Guid id, AccountGrade grade);

        /// <summary>
        /// Gets a certain account from an underlying repository.
        /// </summary>
        /// <param name="id">ID of the account to get.</param>
        /// <returns>Retrieved account.</returns>
        IAccount GetAccount(Guid id);

        /// <summary>
        /// Gets all available accounts in an underlying repository.
        /// </summary>
        /// <returns>Collection of <see cref="IAccount"/> instances.</returns>
        IEnumerable<IAccount> GetAllAccounts();
    }
}
