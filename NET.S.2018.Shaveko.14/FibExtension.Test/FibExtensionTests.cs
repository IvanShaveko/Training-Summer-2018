using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace FibExtension.Test
{
    [TestFixture]
    public class FibExtensionTests
    {
        [TestCase(10, ExpectedResult = new[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 })]
        [TestCase(0, ExpectedResult = new[] { 0 })]
        [TestCase(1, ExpectedResult = new[] { 1 })]
        [TestCase(3, ExpectedResult =new[] { 1, 1, 2 })]

        [Test]
        public int[] Extension_Count_Success(int n)
        {
            return FibExtension.Fibonacci(n);
        }

        [TestCase(-2)]
        
        [Test]
        public void FibExtension_ArgumentNullExceprion_ArrayNull(int n)
        {
            Assert.Throws<ArgumentException>(() => FibExtension.Fibonacci(n));
        }
    }
}
