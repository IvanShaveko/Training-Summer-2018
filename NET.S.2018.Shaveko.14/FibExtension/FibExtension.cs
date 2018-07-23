﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
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
        public static IEnumerable<BigInteger?> Fibonacci(int n)
        {
            Validation(n);
            
            if (n == 0)
            {
                yield return null;
            }

            long prev = 0;
            long next = 1;

            for (int i = 0; i < n; i++)
            {
                yield return prev;
                long tmp = prev + next;
                prev = next;
                next = tmp;
            }
        }

        private static void Validation(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException($"{nameof(n)} must be bigger than 0");

            }
        }
    }
}
