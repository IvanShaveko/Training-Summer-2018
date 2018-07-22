using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BinarySearchExtension.Test
{
    [TestFixture]
    public class BinarySearchExtensionTests
    {
        [TestCase(new[] { 1, 5, 17, 19, 26 }, 17, ExpectedResult = 2)]
        [TestCase(new[] { 1, 5, 17, 19, 26 }, 26, ExpectedResult = 4)]

        [Test]
        public int BinarySearch_SignificantType_Integer_Sucess(int[] array, int item)
        {
            return array.BinarySearch(item, (IComparer<int>) null);
        }

        [TestCase(new[] { 1.5, 5.7, 17.18, 19.32, 26.89 }, 26.89, ExpectedResult = 4)]

        [Test]
        public int BinarySearch_SignificantType_Double_Sucess(double[] array, double item)
        {
            return array.BinarySearch(item, (a, b) => a.CompareTo(b));
        }

        [TestCase(new[] { 1, 5, 17, 19, 26 }, 27, ExpectedResult = -1)]
        [TestCase(new[] { 1, 5, 19, 3, 58 }, 3, ExpectedResult = -1)]
        [TestCase(new int[]{ }, 2, ExpectedResult = -1)]

        [Test]
        public int BinarySearch_SignificantType_Integer_UnSucess(int[] array, int item)
        {
            return array.BinarySearch(item);
        }

        [TestCase(new[] { "Ivan", "German", "Egor", "Sasha" }, "German", ExpectedResult = 1)]

        [Test]
        public int BinarySearch_ReferenceType_String_Sucess(string[] array, string item)
        {
            return array.BinarySearch(item);
        }

        [TestCase(null, 2)]

        [Test]
        public void BinarySearch_SignificantType_ArgumentNullExceprion_ArrayNull(int[] array, int item)
        {
            Assert.Throws<ArgumentNullException>(() => array.BinarySearch(item));
        }

        [TestCase(new[] { "Ivan", "German", "Egor", "Sasha" }, null)]

        [Test]
        public void BinarySearch_SignificantType_ArgumentNullExceprion_ItemNull(string[] array, string item)
        {
            Assert.Throws<ArgumentNullException>(() => array.BinarySearch(item));
        }
    }
}
