using System;
using System.Collections.Generic;

namespace Norbit.Practice
{
    /// <summary>
    /// Калькулятор вклада.
    /// </summary>
    public class DepositCalculator
    {
        /// <summary>
        /// Рассчитывает накопления с учетом сложных процентов.
        /// </summary>
        /// <param name="initialDeposit">Начальная сумма.</param>
        /// <param name="years">Количество лет.</param>
        /// <param name="interestRate">Годовая ставка в процентах.</param>
        /// <returns>Список кортежей с номером года и суммой накоплений.</returns>
        public static List<(int Year, decimal Amount)>
            CalculateCompoundInterest(
                decimal initialDeposit,
                int years,
                decimal interestRate)
        {
            CheckIsPositive(
                initialDeposit,
                "Стартовый размер вклада должен быть больше нуля.");
            CheckIsPositive(
                years,
                "Количество лет должно быть больше нуля.");
            CheckIsPositive(
                interestRate,
                "Ставка должна быть больше нуля.");

            var balances = new List<(int Year, decimal Amount)>();
            decimal balance = initialDeposit;
            decimal annualRate = interestRate / 100m;

            for (var yearIndex = 0; yearIndex < years; yearIndex++)
            {
                balance += balance * annualRate;
                balances.Add((yearIndex + 1, balance));
            }

            return balances;
        }

        /// <summary>
        /// Проверяет, что значение больше нуля.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="errorMessage">Сообщение об ошибке.</param>
        private static void CheckIsPositive(
            decimal value, string errorMessage)
        {
            if (value < 0)
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }
}