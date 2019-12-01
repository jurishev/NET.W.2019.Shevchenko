using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace NET.W2019.Shevchenko08.Task2
{
    /// <summary>
    /// Represents a bank which operates with various kinds of accounts.
    /// </summary>
    public class Bank
    {
        private readonly Type[] accountTypes = new Type[]
        {
            typeof(PlainAccount),
            typeof(GradedAccount),
        };

        private Dictionary<int, Account> accountCollection = new Dictionary<int, Account>();

        /// <summary>
        /// Gets the ID of an account by the name of the account's owner.
        /// </summary>
        /// <param name="owner">The name of the account's owner.</param>
        /// <returns>The account's ID.</returns>
        public int GetId(string owner)
        {
            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentException("No owner name has been provided.");
            }

            foreach (var account in this.accountCollection.Values)
            {
                if (account.Owner == owner)
                {
                    return account.Id;
                }
            }

            throw new ArgumentException($"No account with owner {owner} has been found.");
        }

        /// <summary>
        /// Gets a list of all the accounts currently stored in the bank.
        /// </summary>
        /// <returns>A read only collection of accounts.</returns>
        public ReadOnlyCollection<Account> GetAccounts()
        {
            return new ReadOnlyCollection<Account>(this.accountCollection.Values.ToList());
        }

        /// <summary>
        /// Creates an account of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of an account.</typeparam>
        /// <param name="owner">The name of the account's owner.</param>
        /// <returns>The ID of the created account.</returns>
        public int CreateAccount<T>(string owner)
            where T : Account, new()
        {
            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentException("The owner name has not been provided.");
            }

            int id = 1;

            foreach (int key in this.accountCollection.Keys)
            {
                if (id != key)
                {
                    break;
                }

                id++;
            }

            var newAccount = new T();

            newAccount.Activate(id, owner);

            this.accountCollection.Add(id, newAccount);

            return id;
        }

        /// <summary>
        /// Closes and account.
        /// </summary>
        /// <param name="id">The ID of the account to be closed.</param>
        public void CloseAccount(int id)
        {
            if (!this.accountCollection.ContainsKey(id))
            {
                throw new ArgumentException($"No account with id #{id}.");
            }

            this.accountCollection.Remove(id);
        }

        /// <summary>
        /// Promotes a GradedAccount to the specified grade.
        /// </summary>
        /// <param name="id">The account's ID.</param>
        /// <param name="newGrage">The grade to promote to.</param>
        public void PromoteAccount(int id, GradedAccount.Grade newGrage)
        {
            if (!this.accountCollection.ContainsKey(id))
            {
                throw new ArgumentException($"No account with id #{id}.");
            }

            if (this.accountCollection.TryGetValue(id, out Account account))
            {
                if (account is GradedAccount graded)
                {
                    graded.SetGrade(newGrage);
                }
                else
                {
                    throw new ArgumentException($"The type of the account #{id} is not Graded.");
                }
            }
        }

        /// <summary>
        /// Makes a deposit to an account specified by the ID.
        /// </summary>
        /// <param name="id">The account's ID.</param>
        /// <param name="amount">The amount of money to be deposited.</param>
        public void MakeDeposit(int id, decimal amount)
        {
            if (!this.accountCollection.ContainsKey(id))
            {
                throw new ArgumentException($"No account with id #{id}.");
            }

            if (this.accountCollection.TryGetValue(id, out Account account))
            {
                account.MakeDeposit(amount);
            }
            else
            {
                throw new ArgumentException($"Failed to get an account by id #{id}.");
            }
        }

        /// <summary>
        /// Makes a withdrawal from an account specified by the ID.
        /// </summary>
        /// <param name="id">The account's ID.</param>
        /// <param name="amount">The amount of money to be withdrawed.</param>
        public void MakeWithdrawal(int id, decimal amount)
        {
            if (!this.accountCollection.ContainsKey(id))
            {
                throw new ArgumentException($"No account with id #{id}.");
            }

            if (this.accountCollection.TryGetValue(id, out Account account))
            {
                account.MakeWithdrawal(amount);
            }
            else
            {
                throw new ArgumentException($"Failed to get an account by id #{id}.");
            }
        }

        /// <summary>
        /// Save all the accounts of the current bank instance to a file.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        public void SaveAccountsToFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("No file name has been provided.");
            }

            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                using (BinaryWriter binWriter = new BinaryWriter(fileStream))
                {
                    binWriter.Write(this.accountCollection.Count);

                    foreach (var account in this.accountCollection.Values)
                    {
                        int typeNumber = -1;

                        for (int i = 0; i < this.accountTypes.Length; i++)
                        {
                            if (account.GetType() == this.accountTypes[i])
                            {
                                typeNumber = i;
                                break;
                            }
                        }

                        if (typeNumber < 0)
                        {
                            throw new ApplicationException("Invalid type of an account.");
                        }

                        binWriter.Write(typeNumber);
                        account.WriteBinary(binWriter);
                    }
                }
            }
        }

        /// <summary>
        /// Load all the accounts from a file.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        public void LoadAccountsFromFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("No file name has been provided.");
            }

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                using (BinaryReader binReader = new BinaryReader(fileStream))
                {
                    var newCollection = new Dictionary<int, Account>();

                    int numberOfAccounts = binReader.ReadInt32();

                    while (numberOfAccounts-- > 0)
                    {
                        int typeNumber = binReader.ReadInt32();

                        var ctor = this.accountTypes[typeNumber].GetConstructor(Type.EmptyTypes);

                        var newAccount = ctor.Invoke(ctor.GetParameters()) as Account;

                        if (newAccount is null)
                        {
                            throw new ApplicationException("Invalid object to load from a file.");
                        }

                        newAccount.ReadBinary(binReader);

                        newCollection.Add(newAccount.Id, newAccount);
                    }

                    this.accountCollection = newCollection;
                }
            }
        }
    }
}
