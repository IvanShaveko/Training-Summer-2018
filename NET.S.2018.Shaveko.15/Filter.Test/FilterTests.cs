using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;

namespace Filter.Test
{
    [TestFixture]
    public class FilterTests
    {
        [TestCase(new[] {7, 1, 12, 703, 70}, ExpectedResult = new[] {7, 703, 70})]

        public int[] Filter_Int_Predicate(int[] array)
        {
            return array.Filter(x => x.ToString().Contains("7"));
        }

        [Test]
        public void Filter_String_Predicate()
        {
            string[] str = {"numbers", "predicate", "numbs", "corn"};
            string[] expected = {"numbers", "numbs"};

            CollectionAssert.AreEqual(str.Filter(x => x.Contains("num")), expected);
        }

        [TestCase(new[] { 7, 1, 12, 703, 70 }, ExpectedResult = new[] { 12, 70 })]

        public int[] Filter_Int_Interface(int[] array)
        {
            return array.Filter(new IntegerPredicate());
        }

        [Test]
        public void Filter_String_Interface()
        {
            string[] str = { "numbers", "predicate", "numbs", "corns" };
            string[] expected = { "numbs" , "corns"};

            CollectionAssert.AreEqual(str.Filter(new StringPredicate()), expected);
        }
    }
}
