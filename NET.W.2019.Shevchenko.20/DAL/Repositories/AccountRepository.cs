namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;

    /// <inheritdoc/>
    public class AccountRepository : IAccountRepository
    {
        /// <inheritdoc/>
        public void AddRecord(IAccountDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var record = new AccountRecord()
            {
                Id = dto.Id,
                Type = dto.Type,
                Owner = dto.Owner,
                Balance = dto.Balance,
                Bonus = dto.Bonus,
            };

            using (var db = new AccountContext())
            {
                db.AccountSet.Add(record);
                db.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public void DeleteRecord(Guid id)
        {
            using (var db = new AccountContext())
            {
                var record = db.AccountSet.Find(id);

                if (record is null)
                {
                    throw new ArgumentException($"No such ID: '{id}'.");
                }

                db.AccountSet.Remove(record);
                db.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<IAccountDto> GetAllRecords()
        {
            using (var db = new AccountContext())
            {
                if (!db.AccountSet.Any())
                {
                    yield break;
                }

                foreach (var record in db.AccountSet)
                {
                    yield return record;
                }
            }
        }

        /// <inheritdoc/>
        public IAccountDto GetRecord(Guid id)
        {
            using (var db = new AccountContext())
            {
                var record = db.AccountSet.Find(id);

                if (record is null)
                {
                    throw new ArgumentException($"No such ID: '{id}'.");
                }

                return record;
            }
        }

        /// <inheritdoc/>
        public void UpdateRecord(IAccountDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            using (var db = new AccountContext())
            {
                var record = db.AccountSet.Find(dto.Id);

                if (record is null)
                {
                    throw new ArgumentException($"No such ID: '{dto.Id}'.");
                }

                record.Type = dto.Type;
                record.Owner = dto.Owner;
                record.Balance = dto.Balance;
                record.Bonus = dto.Bonus;

                db.SaveChanges();
            }
        }
    }
}
