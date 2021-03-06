﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public sealed class Polynomial : ICloneable, IEquatable<Polynomial>
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
        }

        /// <summary>
        /// Auto-property to get Degree
        /// </summary>
        public int Degree => _coefficients.Length - 1;

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
            if (firstPolynomial is null || secondPolynomial is null)
            {
                throw new ArgumentException($"{nameof(firstPolynomial)} or {nameof(secondPolynomial)} is null");
            }

            bool comparison = firstPolynomial.Degree > secondPolynomial.Degree;

            Polynomial larger = comparison ? firstPolynomial : secondPolynomial;
            Polynomial shorter = comparison ? secondPolynomial : firstPolynomial;

            for (int i = 0; i <= shorter.Degree; i++)
            {
                larger._coefficients[i] += shorter._coefficients[i];
            }

            return larger;
        }

        /// <summary>
        /// Overload operator -
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
            if (firstPolynomial is null || secondPolynomial is null)
            {
                throw new ArgumentException($"{nameof(firstPolynomial)} or {nameof(secondPolynomial)} is null");
            }

            bool comparison = firstPolynomial.Degree > secondPolynomial.Degree;

            Polynomial larger = comparison ? firstPolynomial  : secondPolynomial;
            Polynomial shorter = comparison ? secondPolynomial : firstPolynomial;

            for (int i = 0; i <= shorter.Degree; i++)
            {
                larger._coefficients[i] = Math.Round(firstPolynomial._coefficients[i] - secondPolynomial._coefficients[i], 3);
            }

            return larger;
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
            if (firstPolynomial is null || secondPolynomial is null)
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
                return false;
            }

            return ReferenceEquals(this, obj) || this.Equals((Polynomial) obj);
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
        /// Clone polynom
        /// </summary>
        /// <returns>
        /// Return cloned polynom
        /// </returns>
        public Polynomial Clone() => new Polynomial(_coefficients);

        /// <summary>
        /// Clone polyom
        /// </summary>
        /// <returns>
        /// Return cloned polynom
        /// </returns>
        object ICloneable.Clone() => this.Clone();

        /// <summary>
        /// Method of interface IEquatable
        /// </summary>
        /// <param name="other">
        /// Other polynomial
        /// </param>
        /// <returns>
        /// True if the are equals or false if not
        /// </returns>
        public bool Equals(Polynomial other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (Degree != other.Degree)
            {
                return false;
            }

            for (int i = 0; i <= Degree; i++)
            {
                if (!_coefficients[i].Equals(other._coefficients[i]))
                {
                    return false;
                }
            }

            return true;
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
