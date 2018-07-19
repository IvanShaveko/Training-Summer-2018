using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayExtencion
{
    /// <summary>
    /// Jagged array extencion
    /// </summary>
    public static class JaggedArrayExtencion
    {
        /// <summary>
        /// Start bubble sort with help of delegate
        /// </summary>
        /// <param name="array">
        /// Array
        /// </param>
        /// <param name="comparison">
        /// Condition
        /// </param>
        public static void DelegateSort(this int[][] array, SortByDelegate comparison) =>
            array.Sort(comparison);

        /// <summary>
        /// Bubble sort
        /// </summary>
        /// <param name="array">
        /// Array
        /// </param>
        /// <param name="condition">
        /// Condition to sort
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throw when array or condition in null
        /// </exception>
        public static void Sort(this int[][] array, IComparer<int[]> condition)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can not be null");
            }

            if (condition == null)
            {
                throw new ArgumentNullException($"{nameof(condition)}");
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (condition.Compare(array[i], array[j]) > 0)
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Sum of elements array
        /// </summary>
        /// <param name="array">
        /// Array
        /// </param>
        /// <returns>
        /// Sum
        /// </returns>
        private static int Sum(int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        /// <summary>
        /// Swap two arrays of jagged array
        /// </summary>
        /// <param name="lhs">
        /// First array
        /// </param>
        /// <param name="rhs">
        /// Second array
        /// </param>
        private static void Swap(ref int[] lhs, ref int[] rhs)
        {
            int[] tmp = lhs;
            lhs = rhs;
            rhs = tmp;
        }

        /// <summary>
        /// Min element of array
        /// </summary>
        /// <param name="array">
        /// Array
        /// </param>
        /// <returns>
        /// Minimum
        /// </returns>
        private static int Min(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Max element of array
        /// </summary>
        /// <param name="array">
        /// Array
        /// </param>
        /// <returns>
        /// Maximum
        /// </returns>
        private static int Max(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (max > array[i])
                {
                    max = array[i];
                }
            }

            return max;
        }
    }
}
