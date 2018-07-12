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
        /// Convert string representation of number with help of _base to decimal number
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <param name="_base">
        /// The _base
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throw when number is null or empty
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws when the _base less the 2 or more than 16 or when number is in a larger number system  
        /// </exception>
        /// <returns>
        /// Return decimal number
        /// </returns>
        public static int ConvertToDecimal(this string number, int _base)
        {
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException($"{nameof(number)} is empty or null");
            }

            if (_base < 2 || _base > 16)
            {
                throw new ArgumentException($"{nameof(_base)} must be from 2 to 16");
            }

            if (number.Length > 31)
            {
                throw new OverflowException($"Number is not a 32 bits");
            }

            string alphabet = GetAlphabet(_base);
            int result = 0;
            int product = 1;

            for (int i = number.Length - 1; i >= 0  ; i--)
            {
                checked
                {
                    if (alphabet.IndexOf(number[i]) == -1)
                    {
                        throw new ArgumentException($"Invalid symbol {number[i]}");
                    }
                    result += alphabet.IndexOf(number[i]) * product;
                    product *= _base;
                }
            }

            return result;
        }

        private static string GetAlphabet(int length)
        {
            int symbol = 'A';
            StringBuilder str = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                if (i <= 9)
                {
                    str.Append(i);
                }
                else
                {
                    str.Append((char) symbol++);
                }
            }

            return str.ToString();
        }
    }
}
