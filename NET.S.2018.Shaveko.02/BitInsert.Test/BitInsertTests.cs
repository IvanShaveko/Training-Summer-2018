using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitInsert;

namespace BitInsert.Test
{
    [TestClass]
    public class BitInsertTests
    {
        [TestMethod]
        public void InsertNumber_Between0And0_1_Success()
        {
            int numberSource = 8;
            int numberIn = 15;
            int extend = 9;
            int i = 0;
            int j = 0;

            int actual = BitInsert.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(extend, actual);
        }

        [TestMethod]
        public void InsertNumber_Between0And0_2_Success()
        {
            int numberSource = 15;
            int numberIn = 15;
            int extend = 15;
            int i = 0;
            int j = 0;

            int actual = BitInsert.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(extend, actual);
        }

        [TestMethod]
        public void InsertNumber_Between3And8_Success()
        {
            int numberSource = 8;
            int numberIn = 15;
            int extend = 120;
            int i = 3;
            int j = 8;

            int actual = BitInsert.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(extend, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_ThrowArgumentOutOfRangeException()
        {
            int numberSource = 15;
            int numberIn = 15;
            int extend = 15;
            int i = 2;
            int j = 38;

            int actual = BitInsert.InsertNumber(numberSource, numberIn, i, j);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_ThrowArgumentException()
        {
            int numberSource = 15;
            int numberIn = 15;
            int extend = 15;
            int i = 5;
            int j = 1;

            int actual = BitInsert.InsertNumber(numberSource, numberIn, i, j);
        }
    }
}
