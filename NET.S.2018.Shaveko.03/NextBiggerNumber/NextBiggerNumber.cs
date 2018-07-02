using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextBiggerNumber
{
    /// <summary>
    /// Find next biger number than our
    /// </summary>
    public static class NextBiggerNumber
    {
        /// <summary>
        /// Find next bigger number
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throw when our number is negative
        /// </exception>
        /// <returns>
        /// Return bigger number or -1 when our number is the biggest
        /// </returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException($"Number must be positive");
            }

            if (IsBiggest(number))
            {
                return -1;
            }

            int[] array = ToArray(number);

            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] > array[i - 1])
                {
                    Array.Sort(array, i, array.Length - i);
                    SwapElement(array, i - 1);
                    break;
                }
            }

            return ToNumber(array);
        }

        /// <summary>
        /// Check that our number is biggest
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <returns>
        /// Return true if number is the biggest or return false when conversely
        /// </returns>
        private static bool IsBiggest(int number)
        {
            int[] tmp = ToArray(number);
            for (int i = 0; i < tmp.Length - 1; i++)
            {
                if (tmp[i] < tmp[i+1])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Splits a number into an array
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <returns>
        /// Return array 
        /// </returns>
        private static int[] ToArray(int number)
        {
            int[] tmp = new int[number.ToString().Length];
            int i = tmp.Length - 1;
            while (number != 0)
            {
                tmp[i--] = number % 10;
                number /= 10;
            }

            return tmp;
        }

        /// <summary>
        /// Swap element
        /// </summary>
        /// <param name="array">
        /// The array
        /// </param>
        /// <param name="index">
        /// Index of element
        /// </param>
        private static void SwapElement(int[] array, int index)
        {
            for (int i = index; i < array.Length; i++)
            {
                if (array[i] > array[index])
                {
                    Swap(ref array[i], ref array[index]);
                    break;
                }
            }
        }

        /// <summary>
        /// Make our array to number
        /// </summary>
        /// <param name="array">
        /// The array
        /// </param>
        /// <returns>
        /// Return number
        /// </returns>
        private static int ToNumber(int[] array)
        {
            int number = 0;
            int degree = 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                number += array[i] * degree;
                degree *= 10;
            }

            return number;
        }

        /// <summary>
        /// Swap two elements of an array
        /// </summary>
        /// <param name="i">
        /// First element
        /// </param>
        /// <param name="j">
        /// Second element
        /// </param>
        private static void Swap(ref int i, ref int j)
        {
            int tmp = i;
            i = j;
            j = tmp;
        }
    }
}
