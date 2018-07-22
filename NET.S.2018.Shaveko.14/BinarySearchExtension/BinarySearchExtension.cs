using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchExtension
{
    /// <summary>
    /// Generic binary search extension
    /// </summary>
    public static class BinarySearchExtension
    {
        /// <summary>
        /// Binary search
        /// </summary>
        /// <typeparam name="T">
        /// Type of elements
        /// </typeparam>
        /// <param name="array">
        /// Sorted array
        /// </param>
        /// <param name="item">
        /// Item which search
        /// </param>
        /// <param name="comparer">
        /// Interface to compare type T
        /// </param>
        /// <returns>
        /// Index of <see cref="item"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throw when array or item is null
        /// </exception>
        public static int BinarySearch<T>(this T[] array, T item, IComparer<T> comparer)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException($"{nameof(array)} must be initialized");
            }
                
            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException($"{nameof(item)} can not be null");
            }

            if (array.Length == 0)
            {
                return -1;
            }

            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            int left = 0;
            int right = array.Length - 1;
            int mid = left + (right - left) / 2;

            while (left <= right)
            {
                int result = comparer.Compare(array[mid], item);
                if (result == 0)
                {
                    return mid;
                }

                if (result < 0)
                {
                    left = mid + 1;
                    mid =left + (right - left) / 2;
                }
                else
                {
                    right = mid - 1;
                    mid = left + (right - left) / 2;
                }
            }

            return -1;
        }

        /// <summary>
        /// Binary search whith delegate
        /// </summary>
        /// <typeparam name="T">
        /// Type of parameters
        /// </typeparam>
        /// <param name="array">
        /// Sorted array
        /// </param>
        /// <param name="item">
        /// Element which searched
        /// </param>
        /// <param name="comparison">
        /// Delegate
        /// </param>
        /// <returns>
        /// Index of <see cref="item"/>
        /// </returns>
        public static int BinarySearch<T>(this T[] array, T item, Comparison<T> comparison)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException($"{nameof(array)} must be initialized");
            }

            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException($"{nameof(item)} can not be null");
            }

            return array.BinarySearch(item, Comparer<T>.Create(comparison));
        }

        /// <summary>
        /// Binary search whithout interface
        /// </summary>
        /// <typeparam name="T">
        /// Type of parameters
        /// </typeparam>
        /// <param name="array">
        /// Sorted array
        /// </param>
        /// <param name="item">
        /// Element which searched
        /// </param>
        /// <returns>
        /// Index of <see cref="item"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throw when array or item is null
        /// </exception>
        /// <exception cref="IndexOutOfRangeException">
        /// Throw when item don't realised interface
        /// </exception>
        public static int BinarySearch<T>(this T[] array, T item)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException($"{nameof(array)} must be initialized");
            }

            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException($"{nameof(item)} can not be null");
            }

            if (item is IComparable)
            {
                return array.BinarySearch(item, Comparer<T>.Default);
            }

            throw new InvalidOperationException($"{item.GetType()} is not realised interface IComparer");
        }
    }
}
