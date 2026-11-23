using System;
using System.Text;

namespace Norbit.Practice
{
    /// <summary>
    /// Формирует ромб из символов X.
    /// </summary>
    public static class DiamondPrinter
    {
        /// <summary>
        /// Формирует контур ромба с пустым центром.
        /// </summary>
        /// <param name="size">Длина каждой диагонали.</param>
        /// <returns>Строка с контуром ромба.</returns>
        /// <exception cref="ArgumentException">
        /// Длина диагонали неположительная или четная.
        /// </exception>
        public static string CreateDiamond(int size)
        {
            if (size <= 0 || size % 2 == 0)
            {
                throw new ArgumentException(
                    "Длина должна быть положительной и нечетной.");
            }

            if (size == 1)
            {
                return "Х";
            }

            var diamond = new StringBuilder();
            int middle = size / 2;

            for (var row = 0; row < size; row++)
            {
                if (row > 0)
                {
                    diamond.AppendLine();
                }

                int indent = Math.Abs(middle - row);
                int halfWidth = middle - indent;

                diamond.Append(' ', indent);
                diamond.Append('X');

                if (halfWidth > 0)
                {
                    diamond.Append(' ', 2 * halfWidth - 1);
                    diamond.Append('X');
                }
            }

            return diamond.ToString();
        }
    }
}