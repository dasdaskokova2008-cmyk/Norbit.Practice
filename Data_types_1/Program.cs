using System;
using System.Globalization;

namespace Norbit.Practice
{
    /// <summary>
    /// Вход в консольное приложение.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Читает параметры вклада и выводит суммы по годам.
        /// </summary>
        public static void Main()
        {
            try
            {
                Console.Write("Введите начальную сумму вклада: ");
                if (!decimal.TryParse(
                    Console.ReadLine(), out decimal initialDeposit))
                {
                    throw new ArgumentException(
                        "Введите начальную сумму числом.");
                }

                Console.Write("Введите количество лет: ");
                if (!int.TryParse(Console.ReadLine(), out int years))
                {
                    throw new ArgumentException(
                        "Введите количество лет целым числом.");
                }

                Console.Write("Введите годовую ставку: ");
                if (!decimal.TryParse(
                    Console.ReadLine(), out decimal interestRate))
                {
                    throw new ArgumentException(
                        "Введите годовую ставку числом.");
                }

                var balances =
                    DepositCalculator.CalculateCompoundInterest(
                        initialDeposit, years, interestRate);

                foreach ((int year, decimal amount) in balances)
                {
                    string formattedAmount = amount.ToString(
                        "F2", CultureInfo.InvariantCulture);

                    Console.WriteLine(
                        $"Год {year}: {formattedAmount} руб.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка валидации: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}