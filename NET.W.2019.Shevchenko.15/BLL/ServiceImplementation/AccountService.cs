namespace BLL.ServiceImplementation
{
    using System;
    using System.Collections.Generic;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;

    /// <inheritdoc/>
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;
        private readonly IBonusCalculator bonusCalculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="repository"><see cref="IAccountRepository"/> instance.</param>
        /// <param name="bonusCalculator"><see cref="IBonusCalculator"/> instance.</param>
        public AccountService(IAccountRepository repository, IBonusCalculator bonusCalculator)
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (bonusCalculator is null)
            {
                throw new ArgumentNullException(nameof(bonusCalculator));
            }

            this.repository = repository;
            this.bonusCalculator = bonusCalculator;
        }

        /// <inheritdoc/>
        public void OpenAccount(string owner, AccountGrade grade, IAccountIdGenerator generator)
        {
            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if (!Enum.IsDefined(typeof(AccountGrade), grade))
            {
                throw new ArgumentException($"Value '{grade}' is not defined.");
            }

            if (generator is null)
            {
                throw new ArgumentNullException(nameof(generator));
            }

            var dto = new AccountDto()
            {
                Id = generator.GenerateGuidId(),
                Type = (int)grade,
                Owner = owner,
                Balance = 0,
                Bonus = 0,
            };

            this.repository.AddRecord(dto);
        }

        /// <inheritdoc/>
        public void CloseAccount(Guid id)
        {
            this.repository.DeleteRecord(id);
        }

        /// <inheritdoc/>
        public void MakeDeposit(Guid id, decimal amount)
        {
            var dto = this.repository.GetRecord(id);

            dto.Balance += amount;
            dto.Bonus += this.bonusCalculator.CalculateDepositBonus((AccountGrade)dto.Type, amount);

            this.repository.UpdateRecord(dto);
        }

        /// <inheritdoc/>
        public void MakeWithdrawal(Guid id, decimal amount)
        {
            var dto = this.repository.GetRecord(id);

            dto.Balance -= amount;
            dto.Bonus -= this.bonusCalculator.CalculateWithdrawalCost((AccountGrade)dto.Type, amount);

            this.repository.UpdateRecord(dto);
        }

        /// <inheritdoc/>
        public void SetGrade(Guid id, AccountGrade grade)
        {
            var dto = this.repository.GetRecord(id);
            dto.Type = (int)grade;
            this.repository.UpdateRecord(dto);
        }

        /// <inheritdoc/>
        public IAccountRepresentation GetAccount(Guid id)
        {
            var dto = this.repository.GetRecord(id);

            return AccountService.RepresentAccount(dto);
        }

        /// <inheritdoc/>
        public IEnumerable<IAccountRepresentation> GetAllAccounts()
        {
            foreach (var dto in this.repository.GetAllRecords())
            {
                yield return AccountService.RepresentAccount(dto);
            }
        }

        private static AccountRepresentation RepresentAccount(IAccountDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new AccountRepresentation(dto.Id, (AccountGrade)dto.Type, dto.Owner, dto.Balance, dto.Bonus);
        }
    }
}
