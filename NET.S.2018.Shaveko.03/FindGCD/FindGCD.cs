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
        /// The second number
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
        /// Find GCD of three numbers by Euclidian method
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second number
        /// </param>
        /// <param name="c">
        /// The third number
        /// </param>
        /// <returns>
        /// Return GCD of three numbers
        /// </returns>
        public static int FindGcdEuclidianMethod(int a, int b, int c)
        {
            return FindGcdEuclidianMethod(FindGcdEuclidianMethod(a, b), c);
        }

        /// <summary>
        /// Find GCD of patams numbers by Euclidian method
        /// </summary>
        /// <param name="numbers">
        /// Numbers
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throw when length of array is 0 or it is null
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

            if (numbers.Length == 0 || numbers == null)
            {
                throw new ArgumentException($"{nameof(numbers)} must be initialized");
            }

            int tmp = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                tmp = FindGcdEuclidianMethod(tmp, numbers[i]);
            }

            return tmp;
        }

        /// <summary>
        /// Method to get time of working FindGcdEuclidianMethod
        /// </summary>
        /// <param name="time">
        /// The time of working
        /// </param>
        /// <param name="first">
        /// The first number
        /// </param>
        /// <param name="second">
        /// The second number
        /// </param>
        /// <returns>
        /// GCD of numbers
        /// </returns>
        public static int GetTimeEuclidianMethod(out TimeSpan time, int first, int second)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            int result = FindGcdEuclidianMethod(first, second);

            timeWorking.Stop();

            time = timeWorking.Elapsed;

            return result;
        }

        /// <summary>
        /// Method to get time of working FindGcdEuclidianMethod
        /// </summary>
        /// <param name="time">
        /// The time of working
        /// </param>
        /// <param name="first">
        /// The first number
        /// </param>
        /// <param name="second">
        /// The second number
        /// </param>
        /// <param name="third">
        /// The third number
        /// </param>
        /// <returns>
        /// GCD of numbers
        /// </returns>
        public static int GetTimeEuclidianMethod(out TimeSpan time, int first, int second, int third)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            int result = FindGcdEuclidianMethod(first, second, third);

            timeWorking.Stop();

            time = timeWorking.Elapsed;

            return result;
        }

        /// <summary>
        /// Method to get time of working FindGcdEuclidianMethod
        /// </summary>
        /// <param name="time">
        /// The time of working
        /// </param>
        /// <param name="numbers">
        /// The numbers
        /// </param>
        /// <returns>
        /// GCD of numbers
        /// </returns>
        public static int GetTimeEuclidianMethod(out TimeSpan time, params int[] numbers)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            int result = FindGcdEuclidianMethod(numbers);

            timeWorking.Stop();

            time = timeWorking.Elapsed;

            return result;
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
        /// Find GCD of three numbers by Stein method
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second number
        /// </param>
        /// <param name="c">
        /// The third number
        /// </param>
        /// <returns>
        /// Return GCD of three numbers
        /// </returns>
        public static int FindGcdSteinMethod(int a, int b, int c)
        {
            return FindGcdSteinMethod(FindGcdEuclidianMethod(a, b), c);
        }

        /// <summary>
        /// Find GCD of params numbers by SteinMethod
        /// </summary>
        /// <param name="numbers">
        /// The numbers
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throw when length of array is 0 or it is null
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

            if (numbers.Length == 0 || numbers == null)
            {
                throw new ArgumentException($"{nameof(numbers)} must be initialized");
            }

            int tmp = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                tmp = FindGcdSteinMethod(tmp, numbers[i]);
            }

            return tmp;
        }

        /// <summary>
        /// Method to get time of working FindGcdEuclidianMethod
        /// </summary>
        /// <param name="time">
        /// The time of working
        /// </param>
        /// <param name="first">
        /// The first number
        /// </param>
        /// <param name="second">
        /// The second number
        /// </param>
        /// <returns>
        /// GCD of numbers
        /// </returns>
        public static int GetTimeSteinMethod(out TimeSpan time, int first, int second)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            int result = FindGcdSteinMethod(first, second);

            timeWorking.Stop();

            time = timeWorking.Elapsed;

            return result;
        }

        /// <summary>
        /// Method to get time of working FindGcdEuclidianMethod
        /// </summary>
        /// <param name="time">
        /// The time of working
        /// </param>
        /// <param name="first">
        /// The first number
        /// </param>
        /// <param name="second">
        /// The second number
        /// </param>
        /// <param name="third">
        /// The third number
        /// </param>
        /// <returns>
        /// GCD of numbers
        /// </returns>
        public static int GetTimeSteinMethod(out TimeSpan time, int first, int second, int third)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            int result = FindGcdSteinMethod(first, second, third);

            timeWorking.Stop();

            time = timeWorking.Elapsed;

            return result;
        }

        /// <summary>
        /// Method to get time of working FindGcdSteinMethod
        /// </summary>
        /// <param name="time">
        /// Time of workung
        /// </param>
        /// <param name="numbers">
        /// The numbers
        /// </param>
        /// <returns>
        /// Time of working FindGcdSteinMethod
        /// </returns>
        public static int GetTimeSteinMethod(out TimeSpan time, params int[] numbers)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            int result = FindGcdSteinMethod(numbers);

            timeWorking.Stop();

            time = timeWorking.Elapsed;

            return result;
        }
    }
}
