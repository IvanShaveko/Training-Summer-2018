using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using StringExtension;
using Assert = NUnit.Framework.Assert;

namespace StringExtension.Tests
{
    [TestFixture]
    public class StringExtensionTest
    {
        [TestCase("0110111101100001100001010111111", 2, ExpectedResult = 934331071)]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        [TestCase("11101101111011001100001010", 2, ExpectedResult = 62370570)]
        [TestCase("1ACB67", 16, ExpectedResult = 1756007)]
        [TestCase("764241", 8, ExpectedResult = 256161)]
        [TestCase("10", 5, ExpectedResult = 5)]

        [Test]
        public int StringExtension_Number_Basis_Success(string number, int basis)
        {
            return number.ConvertToDecimal(basis);
        }

        [TestCase("764241", 20)]
        [TestCase("SA123", 2)]
        [TestCase("1AeF101", 2)]
        public void StringExtension_Number_Basis_ArgumentException(string number, int basis)
        {
            Assert.Throws<ArgumentException>(() => number.ConvertToDecimal(basis));
        }

        [TestCase("11111111111111111111111111111111", 2)]
        public void StringExtension_Number_Basis_OverflowException(string number, int basis)
        {
            Assert.Throws<OverflowException>(() => number.ConvertToDecimal(basis));
        }

        [TestCase("", 16)]
        public void StringExtension_Number_Basis_ArgumentNullException(string number, int basis)
        {
            Assert.Throws<ArgumentNullException>(() => number.ConvertToDecimal(basis));
        }
    }
}
