using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilterByDigit;

namespace FilterByDigit.Tests
{
    [TestClass]
    public class FilterByDigitTests
    {
        [TestMethod]
        public void FilterDigit_WithDigit7_Success()
        {
            int[] array = { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int digit = 7;
            int[] actual = array.FilterDigit(digit);
            int[] expected = {7, 7, 70, 17};

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterDigit_WithNegativeNumbers_Success()
        {
            int[] array = { -17, 25, 13, 86, -7, -7, 123, 5, 6, -73, 13};
            int digit = 7;
            int[] actual = array.FilterDigit(digit);
            int[] expected = { -17, -7, -7, -73 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterDigit_WithDigit0_Success()
        {
            int[] array = { 7, 1, 2, 3, 4, 50, 6, 7, 68, 69, 70, 10, 17 };
            int digit = 0;
            int[] actual = array.FilterDigit(digit);
            int[] expected = {50, 70, 10};

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigit_WithArgumentNull_ThrowArgumentNullException()
        {
            int[] array = null;
            int digit = 3;

            int[] actual = array.FilterDigit(digit);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigit_WithDigit11_ThrowArgumentOutOfRangeException()
        {
            int[] array = {1, 2, 3, 4};
            int digit = 11;

            int[] actual = array.FilterDigit(digit);
        }
    }
}
