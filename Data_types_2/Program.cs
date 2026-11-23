using System;

namespace Norbit.Practice
{
    /// <summary>
    /// Вход в консольное приложение.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Читает длину диагонали и выводит ромб.
        /// </summary>
        public static void Main()
        {
            Console.Write("Введите длину диагонали: ");

            if (!int.TryParse(Console.ReadLine(), out int size))
            {
                Console.WriteLine(
                    "Ошибка валидации: введите целое число.");
                return;
            }

            try
            {
                string diamond = DiamondPrinter.CreateDiamond(size);
                Console.WriteLine(diamond);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка валидации: {ex.Message}");
            }
        }
    }
}