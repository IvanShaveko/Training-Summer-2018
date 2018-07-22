using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibExtension
{
    /// <summary>
    /// Fibonacci sequence
    /// </summary>
    public static class FibExtension
    {
        /// <summary>
        /// Fibba
        /// </summary>
        /// <param name="n">
        /// Count of Fibonacci sequence
        /// </param>
        /// <returns>
        /// Array of Fibonacci sequence
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throw when n less than 0
        /// </exception>
        public static int[] Fibonacci(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException($"{nameof(n)} must be bigger than 0");
            }

            if (n == 1 || n == 0)
            {
                return new []{ n };
            }

            List<int> list = new List<int> {1, 1};
            for (int i = 2; i < n; i++)
            {
                list.Add(list[i - 1] + list[i - 2]);
            }

            return list.ToArray();
        }
    }
}
