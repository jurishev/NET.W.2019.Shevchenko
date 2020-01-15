namespace DAL.Interface.Interfaces
{
    using System;
    using System.Collections.Generic;
    using DAL.Interface.DTO;

    /// <summary>
    /// General account repository functionality.
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Stores a record in a repository.
        /// </summary>
        /// <param name="dto">Data to create a new record with.</param>
        void AddRecord(IAccountDto dto);

        /// <summary>
        /// Deletes a record from a repository.
        /// </summary>
        /// <param name="id">Indentifier of a record to delete.</param>
        void DeleteRecord(Guid id);

        /// <summary>
        /// Retrieves a record from a repository.
        /// </summary>
        /// <param name="id">Identifier of a record to retrieve.</param>
        /// <returns><see cref="IAccountDto"/> instance with retrieved data.</returns>
        IAccountDto GetRecord(Guid id);

        /// <summary>
        /// Retrieves all records from a repository.
        /// </summary>
        /// <returns>A collection of <see cref="IAccountDto"/> instances.</returns>
        IEnumerable<IAccountDto> GetAllRecords();

        /// <summary>
        /// Updates an existing record in a repository with new data.
        /// </summary>
        /// <param name="dto">Data to update a record with.</param>
        void UpdateRecord(IAccountDto dto);
    }
}
