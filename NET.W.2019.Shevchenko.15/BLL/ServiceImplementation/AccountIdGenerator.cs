namespace BLL.ServiceImplementation
{
    using System;
    using BLL.Interface.Interfaces;

    /// <inheritdoc/>
    public class AccountIdGenerator : IAccountIdGenerator
    {
        /// <inheritdoc/>
        public Guid GenerateGuidId()
        {
            return Guid.NewGuid();
        }
    }
}
