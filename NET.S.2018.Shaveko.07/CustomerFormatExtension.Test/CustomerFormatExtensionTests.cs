using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace CustomerFormatExtension.Test
{
    using Customer;

    [TestFixture]
    public class CustomerFormatExtensionTests
    {
        private readonly Customer _customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

        [TestCase("N", ExpectedResult = "Jeffrey Richter")]
        [TestCase("P", ExpectedResult = "+1 (425) 555-0100")]
        [TestCase("R", ExpectedResult = "1000000")]
        [TestCase("G", ExpectedResult = "Jeffrey Richter +1 (425) 555-0100 1000000")]
        [TestCase("C", ExpectedResult = "Jeffrey Richter +1 (425) 555-0100")]

        [Test]
        public string CustomerFormatExtension_IFormattable_Format(string format)
        {
            return new CustomerFormatExtension().Format(format, _customer, CultureInfo.CurrentCulture);
        }
    }
}
