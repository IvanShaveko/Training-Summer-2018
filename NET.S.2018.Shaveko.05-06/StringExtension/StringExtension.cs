using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    /// <summary>
    /// Class to convert string representation of number to decimal number 
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Convert string representation of number with help of basis to decimal number
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <param name="basis">
        /// The basis
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throw when number is null or empty
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws when the basis less the 2 or more than 16 or when number is in a larger number system  
        /// </exception>
        /// <returns>
        /// Return decimal number
        /// </returns>
        public static int ConvertToDecimal(this string number, int basis)
        {
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException($"{nameof(number)} is empty or null");
            }

            if (basis < 2 || basis > 16)
            {
                throw new ArgumentException($"{nameof(basis)} must be from 2 to 16");
            }

            if (number.Length > 31)
            {
                throw new OverflowException($"Number is not a 32 bits");
            }

            const string SCALE = "0123456789ABCDEF";
            int result = 0;

            for (int i = 0; i < number.Length ; i++)
            {
                int symbol = SCALE.IndexOf(number[i]);

                if (symbol > basis)
                {
                    throw new ArgumentException($"Wrong {nameof(number)}");
                }

                result += symbol * (int) Math.Pow(basis, number.Length - i - 1);
            }

            return result;
        }
    }
}
