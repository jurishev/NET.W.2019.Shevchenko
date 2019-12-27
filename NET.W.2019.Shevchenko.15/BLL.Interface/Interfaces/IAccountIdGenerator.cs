namespace BLL.Interface.Interfaces
{
    using System;

    /// <summary>
    /// Basic ID generating functionality.
    /// </summary>
    public interface IAccountIdGenerator
    {
        /// <summary>
        /// Generates a <see cref="Guid"/> type identifier.
        /// </summary>
        /// <returns>New <see cref="Guid"/> identifier.</returns>
        Guid GenerateGuidId();
    }
}
