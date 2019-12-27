namespace ConsolePL
{
    using System;
    using System.Globalization;
    using System.Linq;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;
    using DependencyResolver;
    using Ninject;

    /// <summary>
    /// Engine module.
    /// </summary>
    internal class Program
    {
        private static readonly IKernel Resolver = new StandardKernel();

        static Program()
        {
            Resolver.ConfigurateResolver();
        }

        /// <summary>
        /// The assembly entry point.
        /// </summary>
        internal static void Main()
        {
            IAccountService service = Resolver.Get<IAccountService>();
            IAccountIdGenerator generator = Resolver.Get<IAccountIdGenerator>();

            service.OpenAccount("Ivan Petrovich Sidorov", AccountGrade.Base, generator);
            service.OpenAccount("Sidor Ivanovich Petrov", AccountGrade.Silver, generator);
            service.OpenAccount("Petr Sidorovich Ivanov", AccountGrade.Gold, generator);
            service.OpenAccount("William Henry Gates", AccountGrade.Platinum, generator);

            var accountIdSet = service.GetAllAccounts().Select(acc => acc.Id).ToArray();

            Console.WriteLine(new string('-', 15));
            Console.WriteLine("Depositing 100:");
            Console.WriteLine(new string('-', 15));
            Console.WriteLine();

            foreach (var id in accountIdSet)
            {
                service.MakeDeposit(id, 100);
            }

            foreach (var account in service.GetAllAccounts())
            {
                ShowAccount(account);
            }

            Console.WriteLine(new string('-', 15));
            Console.WriteLine("Withdrawing 10:");
            Console.WriteLine(new string('-', 15));
            Console.WriteLine();

            foreach (var id in accountIdSet)
            {
                service.MakeWithdrawal(id, 10);
            }

            foreach (var account in service.GetAllAccounts())
            {
                ShowAccount(account);
            }

            Console.ReadKey();
        }

        private static void ShowAccount(IAccountRepresentation account)
        {
            Console.WriteLine($"ID: {account.Id}");
            Console.WriteLine($"Grade: {account.Grade}");
            Console.WriteLine($"Owner: {account.Owner}");
            Console.WriteLine($"Balance: {account.Balance.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"))}");
            Console.WriteLine($"Bonus: {account.Bonus.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"))}");
            Console.WriteLine();
        }
    }
}
