namespace BLL.Interface.Interfaces
{
    using BLL.Interface.Entities;

    /// <summary>
    /// Bonus calculation functionality.
    /// </summary>
    public interface IBonusCalculator
    {
        /// <summary>
        /// Calculates a bonus value depending on the provided amount.
        /// </summary>
        /// <param name="grade">Grade to depend upon.</param>
        /// <param name="depositAmount">Amount to calculate a value upon.</param>
        /// <returns>Bonus value.</returns>
        decimal CalculateDepositBonus(AccountGrade grade, decimal depositAmount);

        /// <summary>
        /// Calculates a cost value depending on the provided amount.
        /// </summary>
        /// <param name="grade">Grade to depend upon.</param>
        /// <param name="withdrawalAmount">Amount to calculate a value upon.</param>
        /// <returns>Cost value.</returns>
        decimal CalculateWithdrawalCost(AccountGrade grade, decimal withdrawalAmount);
    }
}
