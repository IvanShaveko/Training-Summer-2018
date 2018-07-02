using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGCD
{
    /// <summary>
    /// Find GCD 
    /// </summary>
    public static class FindGcd
    {
        /// <summary>
        /// Find GCD of two numbers by Euclidian method
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second numbers
        /// </param>
        /// <returns>
        /// GCD of numbers
        /// </returns>
        public static int FindGcdEuclidianMethod(int a, int b)
        {
            if (b == 0)
            {
                return Math.Abs(a);
            }

            return FindGcdEuclidianMethod(b, a % b);
        }

        /// <summary>
        /// Find GCD of three or more numbers by Euclidian method
        /// </summary>
        /// <param name="numbers">
        /// Numbers
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throw when length of array is 0
        /// </exception>
        /// <returns>
        /// GCD of numbers
        /// </returns>
        public static int FindGcdEuclidianMethod(params int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers[0];
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException($"Length of array is 0");
            }

            int tmp = FindGcdEuclidianMethod(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                tmp = FindGcdEuclidianMethod(tmp, numbers[i]);
            }

            return tmp;
        }

        /// <summary>
        /// Method to get time of working FindGcdEuclidianMethod
        /// </summary>
        /// <param name="numbers">
        /// The numbers
        /// </param>
        /// <returns>
        /// Time of working FindGcdEuclidianMethod
        /// </returns>
        public static TimeSpan GetTimeEuclidianMethod(params int[] numbers)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            FindGcdEuclidianMethod(numbers);

            timeWorking.Stop();

            return timeWorking.Elapsed;
        }
        
        /// <summary>
        /// Find GCD of two numbers by Stein method
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second number
        /// </param>
        /// <returns>
        /// Return GcD of two number
        /// </returns>
        public static int FindGcdSteinMethod(int a, int b)
        {
            if (a == 0 || a == b)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if (a == 1 || b == 1)
            {
                return 1;
            }

            a = Math.Abs(a);
            b = Math.Abs(b);

            if ((~a&1)!=0)
            {
                if ((b&1)!=0)
                {
                    return FindGcdSteinMethod(a >> 1, b);
                }
                else
                {
                    return FindGcdSteinMethod(a >> 1, b >> 1) << 1;
                }
            }

            if ((~b&1)!=0)
            {
                return FindGcdSteinMethod(a, b >> 1);
            }

            if (a>b)
            {
                return FindGcdSteinMethod((a - b) >> 1, b);
            }

            return FindGcdSteinMethod((b - a) >> 1, a);
        }

        /// <summary>
        /// Find GCD of three or more numbers by SteinMethod
        /// </summary>
        /// <param name="numbers">
        /// The numbers
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throw when length of array is 0
        /// </exception>
        /// <returns>
        /// GCD of numbers
        /// </returns>
        public static int FindGcdSteinMethod(params int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers[0];
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException($"Length of array is 0");
            }

            int tmp = FindGcdSteinMethod(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                tmp = FindGcdSteinMethod(tmp, numbers[i]);
            }

            return tmp;
        }

        /// <summary>
        /// Method to get time of working FindGcdSteinMethod
        /// </summary>
        /// <param name="numbers">
        /// The numbers
        /// </param>
        /// <returns>
        /// Time of working FindGcdSteinMethod
        /// </returns>
        public static TimeSpan GetTimeSteinMethod(params int[] numbers)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            FindGcdSteinMethod(numbers);

            timeWorking.Stop();

            return timeWorking.Elapsed;
        }
    }
}
