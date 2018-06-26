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
            int[] array = { 1, 6, 3, 5, 9, 0 };
            int[] expected = { 0, 1, 3, 5, 6, 9 };
            int[] actual = array.MergeSort();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_WithNullArgument_ThrowArgumentNullException()
        {
            int[] array = null;

            int[] actual = array.MergeSort();
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
    }
}
