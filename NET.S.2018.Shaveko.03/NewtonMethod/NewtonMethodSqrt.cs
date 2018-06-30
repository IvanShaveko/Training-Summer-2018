using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonMethod
{
    public static class NewtonMethodSqrt
    {
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
