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
        /// Fibonacci sequence
        /// </summary>
        /// <param name="n">
        /// Count of memners
        /// </param>
        /// <returns>
        /// Fibonacci sequence
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throw when n less than 0
        /// </exception>
        public static IEnumerable<BigInteger> FibonacciSequence(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException($"{nameof(n)} must be bigger than 0");
            }


            if (n == 0)
            {
                return null;
            }

            return Fibonacci(n);
        }

        /// <summary>
        /// Fibba
        /// </summary>
        /// <param name="n">
        /// Count of Fibonacci sequence
        /// </param>
        /// <returns>
        /// Fibonacci sequence
        /// </returns>
        private static IEnumerable<BigInteger> Fibonacci(int n)
        {   
            BigInteger prev = 0;
            BigInteger next = 1;

            for (int i = 0; i < n; i++)
            {
                yield return prev;
                BigInteger tmp = prev + next;
                prev = next;
                next = tmp;
            }
        }
    }
}
