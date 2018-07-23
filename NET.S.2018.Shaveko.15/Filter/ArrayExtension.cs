using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    /// <summary>
    /// ArrayExtension
    /// </summary>
    public static class ArrayExtension
    {
        #region Public API
        
        /// <summary>
        /// Filter with predicate
        /// </summary>
        /// <typeparam name="T">
        /// Type
        /// </typeparam>
        /// <param name="array">
        /// Array
        /// </param>
        /// <param name="predicate">
        /// Predicate
        /// </param>
        /// <returns>
        /// Filtered array
        /// </returns>
        public static T[] Filter<T>(this T[] array, Predicate<T> predicate)
        {
            Validate(array, predicate);

            if (array.Length == 0)
            {
                return array;
            }

            List<T> list = new List<T>();

            foreach (var item in array)
            {
                if (predicate(item))
                {
                    list.Add(item);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Filter with interface
        /// </summary>
        /// <typeparam name="T">
        /// Type
        /// </typeparam>
        /// <param name="array">
        /// Array
        /// </param>
        /// <param name="predicate">
        /// Interface predicate
        /// </param>
        /// <returns>
        /// Filtered array
        /// </returns>
        public static T[] Filter<T>(this T[] array, IPredicate<T> predicate)
        {
            Validate(array, predicate.IsMatch);

            return array.Filter(predicate.IsMatch);
        }

        #endregion

        #region Validate

        /// <summary>
        /// Validate of parameters
        /// </summary>
        /// <typeparam name="T">
        /// Type
        /// </typeparam>
        /// <param name="array">
        /// Array
        /// </param>
        /// <param name="predicate">
        /// Predicate
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when array or prediate is null
        /// </exception>
        private static void Validate<T>(T[] array, Predicate<T> predicate)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can not be null");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} must be initialized");
            }
        }

        #endregion
    }
}
