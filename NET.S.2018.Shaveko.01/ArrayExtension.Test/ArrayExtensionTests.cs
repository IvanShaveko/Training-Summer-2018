namespace ArrayExtension.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArrayExtensionTests
    {
        [TestMethod]
        public void MergeSort_Success()
        {
            int[] array = { 1, 6, 3, 4, 9, 0 };
            int[] expected = { 0, 1, 3, 4, 6, 9 };
            array.MergeSort();

            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_WithNullArgument_ThrowArgumentNullException()
        {
            int[] array = null;

            array.MergeSort();
        }

        [TestMethod]
        public void QuickSort_Success()
        {
            int[] array = { 2, 6, 3, 5, 9, 0 };
            int[] expected = { 0, 2, 3, 5, 6, 9 };

            array.QuickSort();

            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_WithNullArgument_ThrowArgumentNullException()
        {
            int[] array = null;

            array.QuickSort();
        }

        bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        [TestMethod]
        public void MergeSort_WithBigLength_Sucess()
        {
            Random randomNumber = new Random();
            int[] array = new int[100000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomNumber.Next();
            }

            array.MergeSort();

            if (!IsSorted(array))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void QuickSort_WithBigLength_Sucess()
        {
            Random randomNumber = new Random();
            int[] array = new int[1000000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomNumber.Next();
            }

            array.QuickSort();

            if (!IsSorted(array))
            {
                Assert.Fail();
            }
        }
    }
}
