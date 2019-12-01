using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace NET.W2019.Shevchenko08.Task2
{
    /// <summary>
    /// The application to demonstrate the work of Account classes.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The assembly entry point.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Task 2 demonstration.");
            Console.WriteLine("EPAM training, winter 2019.");
            Console.WriteLine("By Yuri Shevchenko.\n");

            var bank = new Bank();

            Console.WriteLine("A Bank instance has been created.");

            bank.CreateAccount<GradedAccount>("Ivanov");
            bank.CreateAccount<GradedAccount>("Petrov");
            bank.CreateAccount<PlainAccount>("Sidorov");

            Console.WriteLine("Several accounts have been created.");

            ShowAccounts(bank.GetAccounts());

            bank.PromoteAccount(bank.GetId("Ivanov"), GradedAccount.Grade.Gold);

            Console.WriteLine("Ivanov's account has been promoted to Gold grade.");

            bank.PromoteAccount(bank.GetId("Petrov"), GradedAccount.Grade.Platinum);

            Console.WriteLine("Petrov's account has been promoted to Platinum grade.");

            Console.WriteLine("\nDeposit 100M to every account.");

            foreach (var account in bank.GetAccounts())
            {
                bank.MakeDeposit(account.Id, 100M);
            }

            ShowAccounts(bank.GetAccounts());

            bank.SaveAccountsToFile("accounts");

            Console.WriteLine("Accounts have been saved to a file successfully.");

            bank = new Bank();

            Console.WriteLine("A new Bank instance has been created.");

            bank.LoadAccountsFromFile("accounts");

            Console.WriteLine("Accounts have been loaded from a file to the new bank instance successfully.");

            ShowAccounts(bank.GetAccounts());

            bank.CloseAccount(bank.GetId("Sidorov"));

            Console.WriteLine("Sidorov's account has been closed.");

            Console.WriteLine("\nWithdraw 50M from every account.");

            foreach (var account in bank.GetAccounts())
            {
                bank.MakeWithdrawal(account.Id, 50M);
            }

            ShowAccounts(bank.GetAccounts());

            Console.WriteLine("Thank you for your attention!");

            Console.ReadKey();
        }

        private static void ShowAccounts(ReadOnlyCollection<Account> collection)
        {
            if (collection is null)
            {
                throw new ArgumentException("No collection has been provided.");
            }

            Console.WriteLine();

            foreach (var account in collection)
            {
                Console.Write($"Type: {account.GetType(),-44} #{account.Id,-4} Owner: {account.Owner,-10} ");

                Console.Write($"Balance: {account.Balance.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")),-10} ");

                if (account is GradedAccount)
                {
                    Console.WriteLine($"Bonus points: {((GradedAccount)account).BonusPoints.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")),-10}");
                }
                else
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }
    }
}
