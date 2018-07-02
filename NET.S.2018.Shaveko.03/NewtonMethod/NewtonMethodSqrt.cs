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
        /// <param name="number">
        /// The number
        /// </param>
        /// <param name="degree">
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
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if (precision <= 0 || precision >= 1)
            {
                throw new ArgumentOutOfRangeException($"Incorret {nameof(precision)}");
            }

            if (degree < 0)
            {
                throw new ArgumentOutOfRangeException($"Incorrect degree of root");
            }

            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentOutOfRangeException($"Incorrect number and degree of root");
            }

            double suppositious = 1;
            double next = (1.0 / degree) * ((degree - 1) * suppositious + number / Math.Pow(suppositious, degree - 1));

            while (Math.Abs(next - suppositious) > precision)
            {
                suppositious = next;
                next = (1.0 / degree) * ((degree - 1) * suppositious + number / Math.Pow(suppositious, degree - 1));
            }

            return next;
        }
    }
}
