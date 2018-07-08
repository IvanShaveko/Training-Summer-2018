using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public sealed class Polynomial
    {
        private readonly double[] _coefficients;

        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="coefficients">
        /// Array of coefficients
        /// </param>
        public Polynomial(params double[] coefficients)
        {
            _coefficients = coefficients;
            Degree = coefficients.Length - 1;
        }

        /// <summary>
        /// Auto-property to get Degree
        /// </summary>
        public int Degree { get; }

        /// <summary>
        /// Overload operator ==
        /// </summary>
        /// <param name="firstPolynomial">
        /// The first polynom
        /// </param>
        /// <param name="secondPolynomial">
        /// The second polynom
        /// </param>
        /// <returns>
        /// True if the are equals or false if not
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If one of polynom is null
        /// </exception>
        public static bool operator ==(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial is null || secondPolynomial is null)
            {
                throw new ArgumentNullException();
            }
            return firstPolynomial.Equals(secondPolynomial);
        }

        /// <summary>
        /// Overload operator !=
        /// </summary>
        /// <param name="firstPolynomial">
        /// The first polynom
        /// </param>
        /// <param name="secondPolynomial">
        /// The second polynom
        /// </param>
        /// <returns>
        /// False if the are equals or true if not
        /// </returns>
        public static bool operator !=(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return !(firstPolynomial == secondPolynomial);
        }

        /// <summary>
        /// Overload operator +
        /// </summary>
        /// <param name="firstPolynomial">
        /// The first polynom
        /// </param>
        /// <param name="secondPolynomial">
        /// The second polynom
        /// </param>
        /// <returns>
        /// Return sum
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If one of polynom is null
        /// </exception>
        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial == null || secondPolynomial == null)
            {
                throw new ArgumentException($"{nameof(firstPolynomial)} or {nameof(secondPolynomial)} is null");
            }

            if (firstPolynomial.Degree < secondPolynomial.Degree)
            {
                double[] result = secondPolynomial._coefficients;
                for (int i = 0; i <= firstPolynomial.Degree; i++)
                {
                    result[i] += firstPolynomial._coefficients[i];
                }
                return new Polynomial(result);
            }
            else
            {
                double[] result = firstPolynomial._coefficients;
                for (int i = 0; i <= secondPolynomial.Degree; i++)
                {
                    result[i] += secondPolynomial._coefficients[i];
                }
                return new Polynomial(result);
            }
        }

        /// <summary>
        /// Overload operator --
        /// </summary>
        /// <param name="firstPolynomial">
        /// The first polynom
        /// </param>
        /// <param name="secondPolynomial">
        /// The second polynom
        /// </param>
        /// <returns>
        /// Return difference
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If one of polynom is null
        /// </exception>
        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial == null || secondPolynomial == null)
            {
                throw new ArgumentException($"{nameof(firstPolynomial)} or {nameof(secondPolynomial)} is null");
            }

            if (firstPolynomial.Degree < secondPolynomial.Degree)
            {
                double[] result = secondPolynomial._coefficients;
                for (int i = 0; i <= firstPolynomial.Degree; i++)
                {
                    result[i] = Math.Round(firstPolynomial._coefficients[i] - result[i], 3);
                }
                return new Polynomial(result);
            }
            else
            {
                double[] result = firstPolynomial._coefficients;
                for (int i = 0; i <= secondPolynomial.Degree; i++)
                {
                    result[i] = Math.Round(result[i] - secondPolynomial._coefficients[i], 3);
                }
                return new Polynomial(result);
            }
        }

        /// <summary>
        /// Overload operator *
        /// </summary>
        /// <param name="firstPolynomial">
        /// The first polynom
        /// </param>
        /// <param name="secondPolynomial">
        /// The second polynom
        /// </param>
        /// <returns>
        /// Return product of multiplying
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If one of polynom is null
        /// </exception>
        public static Polynomial operator *(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial == null || secondPolynomial == null)
            {
                throw new ArgumentException($"{nameof(firstPolynomial)} or {nameof(secondPolynomial)} is null");
            }

            double[] result = new double[firstPolynomial.Degree + 1 + secondPolynomial.Degree];

            for (int i = 0; i <= firstPolynomial.Degree; i++)
            {
                for (int j = 0; j <= secondPolynomial.Degree; j++)
                {
                    result[i + j]  = Math.Round(result[i + j] + firstPolynomial._coefficients[i] * secondPolynomial._coefficients[j], 3);
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(result[i], 3);
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Overload operator ==
        /// </summary>
        /// <param name="obj">
        /// The polynom
        /// </param>
        /// <returns>
        /// True if the are equals or false if not
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                //throw new ArgumentException($"{nameof(obj)} should be not null");
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            Polynomial otherPolynomial = (Polynomial) obj;

            if (Degree != otherPolynomial.Degree)
            {
                return false;
            }

            for (int i = 0; i <= Degree; i++)
            {
                if (!_coefficients[i].Equals(otherPolynomial._coefficients[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Method of getting hash code
        /// </summary>
        /// <returns>
        /// Return hashcode
        /// </returns>
        public override int GetHashCode()
        {
            int hascode = 0;
            for (int i = 0; i <= Degree; i++)
            {
                hascode += (int)Math.Pow(_coefficients[i], Degree) + i;
            }

            return hascode;
        }

        /// <summary>
        /// String translation method
        /// </summary>
        /// <returns>
        /// String of polynom
        /// </returns>
        public override string ToString()
        {
            string s = $"{_coefficients[0]} ";

            for (int i = 1; i < _coefficients.Length; i++)
            {
                s += $"+ { _coefficients[i]} * x ^ {i} ";
            }

            return s;
        }
    }
}
