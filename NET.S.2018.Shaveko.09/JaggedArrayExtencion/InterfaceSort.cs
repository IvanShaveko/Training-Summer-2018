using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayExtencion
{
    public static class InterfaceSort
    {
        public static void SortByInterface(this int[][] array, IComparer<int[]> comparer)
        {
            array.Sort(comparer);
        }

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
        public static void Sort(this int[][] array, Comparison<int[]> condition)
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
                    if (condition(array[i], array[j]) > 0)
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
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
    }
}
