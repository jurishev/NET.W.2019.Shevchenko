namespace BLL.ServiceImplementation
{
    using System;
    using System.Collections.Generic;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;

    /// <inheritdoc/>
    public class BonusCalculator : IBonusCalculator
    {
        private readonly Dictionary<AccountGrade, Rules> ruleSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="BonusCalculator"/> class.
        /// </summary>
        public BonusCalculator()
        {
            this.ruleSet = new Dictionary<AccountGrade, Rules>()
            {
                { AccountGrade.Base, new Rules(2, 8, 0.01M) },
                { AccountGrade.Silver, new Rules(4, 6, 0.012M) },
                { AccountGrade.Gold, new Rules(6, 4, 0.014M) },
                { AccountGrade.Platinum, new Rules(8, 2, 0.016M) },
            };
        }

        /// <inheritdoc/>
        public decimal CalculateDepositBonus(AccountGrade grade, decimal depositAmount)
        {
            if (!Enum.IsDefined(typeof(AccountGrade), grade))
            {
                throw new ArgumentException($"Grade value '{grade}' is not defined.");
            }

            if (!this.ruleSet.TryGetValue(grade, out var rules))
            {
                throw new InvalidOperationException();
            }

            return (depositAmount * rules.Factor) * (rules.DepoistBonus * rules.Factor);
        }

        /// <inheritdoc/>
        public decimal CalculateWithdrawalCost(AccountGrade grade, decimal withdrawalAmount)
        {
            if (!Enum.IsDefined(typeof(AccountGrade), grade))
            {
                throw new ArgumentException($"Grade value '{grade}' is not defined.");
            }

            if (!this.ruleSet.TryGetValue(grade, out var rules))
            {
                throw new InvalidOperationException();
            }

            return (withdrawalAmount * rules.Factor) * (rules.WithdrawalCharge * rules.Factor);
        }

        private class Rules
        {
            public Rules(int bonus, int charge, decimal factor)
            {
                this.DepoistBonus = bonus;
                this.WithdrawalCharge = charge;
                this.Factor = factor;
            }

            public int DepoistBonus { get; }

            public int WithdrawalCharge { get; }

            public decimal Factor { get; }
        }
    }
}
