using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Polynomial;
using Assert = NUnit.Framework.Assert;

namespace Polynomial.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(new double[] {1.2, 2.3, 4.5}, new double[] {1.2, 2.3, 4.5}, ExpectedResult = true)]

        public bool Polynom_EqualSign_True(double[] first, double[] second)
        {
            Polynomial firstPolynomial = new Polynomial(first);
            Polynomial secondPolynomial = new Polynomial(second);

            return firstPolynomial == secondPolynomial;
        }

        [TestCase(new double[] { 1.2, 2.3, 4.5 }, new double[] { 1.2, 2.8, 4.5 })]

        public void Polynom_EqualSign_False(double[] first, double[] second)
        {
            Polynomial firstPolynomial = new Polynomial(first);
            Polynomial secondPolynomial = new Polynomial(second);

            Assert.IsTrue(firstPolynomial != secondPolynomial);
        }

        [TestCase(new double[] { 1.8, 2.4, 4.6 }, new double[] { 1.5, 2.1, 4.9 }, new double[] { 3.3, 4.5, 9.5 })]
        [TestCase(new double[] { 2.6, 5.32, 2.28 }, new double[] { 1.4, 5, 4.72, 15, 27.2}, new double[] { 4, 10.32, 7, 15, 27.2 })]

        public void Polynom_OperatorPlus(double[] first, double[] second, double[] expected)
        {
            Polynomial firstPolynomial = new Polynomial(first);
            Polynomial secondPolynomial = new Polynomial(second);
            Polynomial expectedPolynomial = new Polynomial(expected);
            Polynomial actualPolynomial = firstPolynomial + secondPolynomial;

            Assert.AreEqual(actualPolynomial, expectedPolynomial);
        }

        [TestCase(new double[] { 1.8, 2.4, 4 }, new double[] { 1.5, 2.1, 4 }, new double[] { 0.3, 0.3, 0 })]
        [TestCase(new double[] { 1.7, 2.8, 1.5, 1.8 }, new double[] { 1.5, 1.3, 0.2 }, new double[] { 0.2, 1.5, 1.3, 1.8 })]

        public void Polynom_OperatorMinus(double[] first, double[] second, double[] expected)
        {
            Polynomial firstPolynomial = new Polynomial(first);
            Polynomial secondPolynomial = new Polynomial(second);
            Polynomial expectedPolynomial = new Polynomial(expected);
            Polynomial actualPolynomial = firstPolynomial - secondPolynomial;

            Assert.AreEqual(expectedPolynomial, actualPolynomial);
        }

        [TestCase(new double[] { 1.8, 2.4, 4 }, new double[] { 1.5, 2.1, 4 }, new double[] { 2.7, 7.38, 18.24, 18, 16 })]

        public void Polynom_OperatorMultiply(double[] first, double[] second, double[] expected)
        {
            Polynomial firstPolynomial = new Polynomial(first);
            Polynomial secondPolynomial = new Polynomial(second);
            Polynomial expectedPolynomial = new Polynomial(expected);
            Polynomial actualPolynomial = firstPolynomial * secondPolynomial;

            Assert.AreEqual(expectedPolynomial, actualPolynomial);
        }
    }
}
