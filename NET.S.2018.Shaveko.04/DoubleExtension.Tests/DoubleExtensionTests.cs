using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using DoubleExtension;

namespace DoubleExtension.Tests
{
    [TestFixture]
    public class DoubleExtensionTests
    {
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]

        [Test]
        public string ConvertToBit_Double_Success(double number)
        {
            return number.ConvertToBit();
        }

    }
}
