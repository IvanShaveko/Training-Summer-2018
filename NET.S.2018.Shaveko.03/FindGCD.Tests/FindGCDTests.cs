using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindGCD;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = NUnit.Framework.Assert;

namespace FindGCD.Tests
{
    [TestFixture]
    public class FindGcdTests
    {
        [TestCase(9, 3, ExpectedResult = 3)]
        [TestCase(6, 9, 12, ExpectedResult = 3)]
        [TestCase(628, 338, 146, 998, 362, ExpectedResult = 2)]
        [TestCase(1071, 462, ExpectedResult = 21)]

        [Test]
        public int FindGcdEuclidianMethod_Number_Succes(params int[] a)
        {
            return FindGcd.FindGcdEuclidianMethod(a);
        }

        [TestCase(9, -3, ExpectedResult = 3)]

        [Test]
        public int FindGcdEuclidianMethod_For2Numbers_Success(int a, int b)
        {
            return FindGcd.FindGcdEuclidianMethod(a, b);
        }

        [TestCase(9, 3, ExpectedResult = 3)]
        [TestCase(-6, 12, ExpectedResult = 6)]

        [Test]
        public int FindGcdSteinMethod_For2Numbers_Success(int a, int b)
        {
            return FindGcd.FindGcdSteinMethod(a, b);
        }

        [TestCase(3, 9, ExpectedResult = 3)]
        [TestCase(6, 9, 12, ExpectedResult = 3)]
        [TestCase(628, 338, 146, 998, 362, ExpectedResult = 2)]
        [TestCase(1071, 462, ExpectedResult = 21)]

        [Test]
        public int FindGcdSteinMethod_Number_Succes(params int[] a)
        {
            return FindGcd.FindGcdSteinMethod(a);
        }
    }
}
