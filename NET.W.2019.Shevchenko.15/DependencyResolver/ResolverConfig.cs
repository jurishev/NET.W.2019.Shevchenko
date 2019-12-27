namespace DependencyResolver
{
    using System;
    using BLL.Interface.Interfaces;
    using BLL.ServiceImplementation;
    using DAL.Fake.Repositories;
    using DAL.Interface.Interfaces;
    using Ninject;

    /// <summary>
    /// Ninject configuration class.
    /// </summary>
    public static class ResolverConfig
    {
        /// <summary>
        /// Ninject configuration extension method.
        /// </summary>
        /// <param name="kernel"><see cref="IKernel"/> instance to be configured.</param>
        public static void ConfigurateResolver(this IKernel kernel)
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IBonusCalculator>().To<BonusCalculator>();
            kernel.Bind<IAccountRepository>().To<FakeAccountRepository>();
            kernel.Bind<IAccountIdGenerator>().To<AccountIdGenerator>().InSingletonScope();
        }
    }
}
