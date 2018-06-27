using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterByDigit
{

    /// <summary>
    /// Filter array by the digit
    /// </summary>
    public static class FilterByDigit
    {
        /// <summary>
        /// Start filter array by digit
        /// </summary>
        /// <param name="array">
        /// Array of integers
        /// </param>
        /// <param name="digit">
        /// Digit by which filter
        /// </param>
        /// <returns>
        /// Return filtered array
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throw when array is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throw when digit is out fo range 0 to 9
        /// </exception>
        public static int[] FilterDigit(this int[] array, int digit)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (digit<0 || digit>9)
            {
                throw new ArgumentOutOfRangeException();
            }

            List<int> list = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (IsDigit(array[i], digit))
                {
                    list.Add(array[i]);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Check contains number this digit
        /// </summary>
        /// <param name="number">
        /// Number which checked
        /// </param>
        /// <param name="digit">
        /// Digit 
        /// </param>
        /// <returns>
        /// Return true if number contains digit or return false if number doesn't contains digit
        /// </returns>
        private static bool IsDigit(int number, int digit)
        {
            while (number != 0) 
            {
                int t = Math.Abs(number % 10);
                if (t == digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
