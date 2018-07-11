using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Customer;
using NUnit.Framework;

namespace Customer.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        private readonly Customer _customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

        [TestCase("N", ExpectedResult = "Jeffrey Richter")]
        [TestCase("P", ExpectedResult = "+1 (425) 555-0100")]
        [TestCase("R", ExpectedResult = "1000000")]
        [TestCase("G", ExpectedResult = "Jeffrey Richter +1 (425) 555-0100 1000000")]
        [TestCase("C", ExpectedResult = "Jeffrey Richter +1 (425) 555-0100")]

        [Test]
        public string Customer_IFormattable_ToString(string format)
        {
            return _customer.ToString(format);
        }
        
    }
}
