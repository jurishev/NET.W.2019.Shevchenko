﻿namespace DAL.Fake.Repositories
{
    using System;
    using System.Collections.Generic;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;

    /// <inheritdoc/>
    public class FakeAccountRepository : IAccountRepository
    {
        private readonly Dictionary<Guid, FakeAccountDto> storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeAccountRepository"/> class.
        /// </summary>
        public FakeAccountRepository()
        {
            this.storage = new Dictionary<Guid, FakeAccountDto>();
        }

        /// <inheritdoc/>
        public void AddRecord(IAccountDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (this.storage.ContainsKey(dto.Id))
            {
                throw new ArgumentException($"ID '{dto.Id}' already exists.");
            }

            var data = new FakeAccountDto()
            {
                Id = dto.Id,
                Type = dto.Type,
                Owner = dto.Owner,
                Balance = dto.Balance,
                Bonus = dto.Bonus,
            };

            this.storage.Add(data.Id, data);
        }

        /// <inheritdoc/>
        public void DeleteRecord(Guid id)
        {
            if (!this.storage.ContainsKey(id))
            {
                throw new ArgumentException($"No such ID: '{id}'.");
            }

            this.storage.Remove(id);
        }

        /// <inheritdoc/>
        public IAccountDto GetRecord(Guid id)
        {
            if (this.storage.TryGetValue(id, out var dto))
            {
                return dto;
            }

            throw new ArgumentException($"No such ID: '{id}'.");
        }

        /// <inheritdoc/>
        public IEnumerable<IAccountDto> GetAllRecords()
        {
            foreach (var id in this.storage.Keys)
            {
                if (this.storage.TryGetValue(id, out var dto))
                {
                    yield return dto;
                }
                else
                {
                    yield break;
                }
            }
        }

        /// <inheritdoc/>
        public void UpdateRecord(IAccountDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (!this.storage.ContainsKey(dto.Id))
            {
                throw new ArgumentException($"No such ID: '{dto.Id}'.");
            }

            var data = new FakeAccountDto()
            {
                Id = dto.Id,
                Type = dto.Type,
                Owner = dto.Owner,
                Balance = dto.Balance,
                Bonus = dto.Bonus,
            };

            this.storage.Remove(dto.Id);
            this.storage.Add(data.Id, data);
        }
    }
}
