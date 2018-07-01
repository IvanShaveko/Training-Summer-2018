using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonMethod
{
    /// <summary>
    /// Newtonian method for finding the root of n degree
    /// </summary>
    public static class NewtonMethodSqrt
    {
        /// <summary>
        /// Newtonian method
        /// </summary>
        /// <param name="a">
        /// The number
        /// </param>
        /// <param name="n">
        /// The degree
        /// </param>
        /// <param name="precision">
        /// The accurancy
        /// </param>
        /// <returns>
        /// Root of number 
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throw when incorrect accurancy, degree of root or number and degree of root
        /// </exception>
        public static double FindNthRoot(double a, int n, double precision)
        {
            if (precision < 0)
            {
                throw new ArgumentOutOfRangeException($"Incorret accurancy");
            }

            if (n < 0)
            {
                throw new ArgumentOutOfRangeException($"Incorrect degree of root");
            }

            if ((a < 0) && (n%2 == 0))
            {
                throw new ArgumentOutOfRangeException($"Incorrect number and degree of root");
            }

            double x0 = 1;
            double x1 = (1.0 / n) * ((n - 1) * x0 + a / Math.Pow(x0, n - 1));

            while (Math.Abs(x1 - x0) > precision)
            {
                x0 = x1;
                x1 = (1.0 / n) * ((n - 1) * x0 + a / Math.Pow(x0, n - 1));
            }

            return x1;
        }
    }
}
