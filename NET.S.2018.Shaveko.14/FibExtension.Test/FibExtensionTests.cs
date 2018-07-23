using System;
using System.Collections;
using System.Linq;
using System.Numerics;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace FibExtension.Test
{
    [TestFixture]
    public class FibExtensionTests
    {
        
        public static IEnumerable LongGenerateFibbonachiSequence
        {
            get
            {
                yield return new TestCaseData(5).Returns(new BigInteger[] {0, 1, 1, 2, 3});
                yield return new TestCaseData(10).Returns(new BigInteger[] {0, 1, 1, 2, 3, 5, 8, 13, 21, 34});
                yield return new TestCaseData(1).Returns(new BigInteger[] {0});
            }
        }

        [Test, TestCaseSource(nameof(LongGenerateFibbonachiSequence))]
        public IEnumerable FibonacciSequenceEnumerable(int length) => FibExtension.Fibonacci(length);

        public static IEnumerable ExceptionTest
        {
            get
            {
                yield return new TestCaseData(-2);
                yield return new TestCaseData(-5);
            }
        }

        [Test, TestCaseSource(nameof(ExceptionTest))]
        public void Exceprion_Fibonacci_ArgumentException(int n)
        {
            Assert.Throws<ArgumentException>(() => FibExtension.Fibonacci(n).First());
        }
    }
}
