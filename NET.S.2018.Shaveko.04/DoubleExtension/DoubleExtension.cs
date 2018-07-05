using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleExtension
{
    /// <summary>
    /// Convert to IEEE
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Method to convert ro IEEE
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <returns>
        /// Return IEEE
        /// </returns>
        public static string ConvertToBit(this double number)
        {
            string s = "";

            s = string.Concat(s, ConvertToBitWholePart(Math.Abs(Math.Truncate(number)), out int index));
            s = string.Concat(s, ConvertToBitFractionalPart(Math.Abs(number) - Math.Abs(Math.Truncate(number))));

            s = ConvertToIeee(s, index);

            return number.AddSign(s);
        }

        /// <summary>
        /// Convert whole part to binary code
        /// </summary>
        /// <param name="number">
        /// The number 
        /// </param>
        /// <param name="i">
        /// Count of bit
        /// </param>
        /// <returns>
        /// The string of binary code
        /// </returns>
        private static string ConvertToBitWholePart(this double number, out int i)
        {
            i = 0;
            string str = "";
            while (number > 0)
            {
                str = String.Concat(Convert.ToString(number % 2), str);
                number = Math.Truncate(number / 2);
                i++;
            }

            return str;
        }

        /// <summary>
        /// Convert fraction part to bit
        /// </summary>
        /// <param name="fraction">
        /// The fraction
        /// </param>
        /// <returns>
        /// String of fraction bits
        /// </returns>
        private static string ConvertToBitFractionalPart(this double fraction)
        {
            string list = "";
            while (list.Length < 52)
            {
                fraction *= 2;
                long c = Convert.ToInt64(Math.Truncate(fraction));
                list = string.Concat(list, Convert.ToString(c));
                fraction -= c;
            }

            char[] tmp = list.ToCharArray();
            int i = 0;

            while (tmp[tmp.Length - 1 - i] == '0' && i != tmp.Length - 1)
            {
                i++;
            }

            list = list.Remove(tmp.Length - i);

            return list;
        }

        /// <summary>
        /// Convert bits to IEEE
        /// </summary>
        /// <param name="s">
        /// The string of bits
        /// </param>
        /// <param name="index">
        /// The index
        /// </param>
        /// <returns>
        /// Returns IEEE code
        /// </returns>
        private static string ConvertToIeee(string s, int index)
        {
            double order = 1023 + index - 1;
            string str = ConvertToBitWholePart(order, out _);
            while (str.Length < 11)
            {
                str = string.Concat(str, "0");
            }

            str = string.Concat(str, s.Remove(0, 1));

            while (str.Length < 63)
            {
                str = string.Concat(str, "0");
            }

            return str;
        }

        /// <summary>
        /// Add sign to IEEE code
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <param name="s">
        /// The string 
        /// </param>
        /// <returns>
        /// IEEE code with sign
        /// </returns>
        private static string AddSign(this double number, string s)
        {
            if (number > 0)
            {
                s = string.Concat("0", s);
            }
            else
            {
                s = string.Concat("1", s);
            }

            return s;
        }
    }
}
