using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Matrix;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;

namespace Matrix.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void Matrix_Add_SquareMatrix()
        {
            var array = new[,] {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
            var arrayExpected = new[,] {{2, 4, 6}, {8, 10, 12}, {14, 16, 18}};
            Matrix<int> lhs = new SquareMatrix<int>(array);
            var result = lhs.Add(lhs);
            Matrix<int> expected = new SquareMatrix<int>(arrayExpected);
            CollectionAssert.AreEqual(expected, result);

            array = new[,] { { 1, 0, 0 }, { 0, 5, 0 }, { 0, 0, 9 } };
            arrayExpected = new[,] { { 2, 0, 0 }, { 0, 10, 0 }, { 0, 0, 18 } };
            lhs = new SquareMatrix<int>(array);
            Matrix<int> rhs = new DiagonaleMatrix<int>(array);
            result = lhs.Add(rhs);
            expected = new SquareMatrix<int>(arrayExpected);
            CollectionAssert.AreEqual(expected, result);

            rhs = new SymmetricMatrix<int>(array);
            result = lhs.Add(rhs);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_Add_DiagonaleMatrix()
        {
            var array = new[,] { { 1, 0, 0 }, { 0, 5, 0 }, { 0, 0, 9 } };
            var arrayExpected = new[,] { { 2, 0, 0 }, { 0, 10, 0 }, { 0, 0, 18 } };
            Matrix<int> lhs = new SquareMatrix<int>(array);
            Matrix<int> rhs = new DiagonaleMatrix<int>(array);
            var result = rhs.Add(lhs);
            Matrix<int> expected = new SquareMatrix<int>(arrayExpected);
            CollectionAssert.AreEqual(expected, result);

            result = rhs.Add(rhs);
            expected = new DiagonaleMatrix<int>(arrayExpected);
            CollectionAssert.AreEqual(expected, result);

            lhs = new SymmetricMatrix<int>(array);
            result = rhs.Add(lhs);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_Add_SymmetricMatrix()
        {
            var array = new[,] { { 1, 0, 0 }, { 0, 5, 0 }, { 0, 0, 9 } };
            var arrayExpected = new[,] { { 2, 0, 0 }, { 0, 10, 0 }, { 0, 0, 18 } };
            Matrix<int> lhs = new SquareMatrix<int>(array);
            Matrix<int> rhs = new SymmetricMatrix<int>(array);
            var result = rhs.Add(lhs);
            Matrix<int> expected = new SquareMatrix<int>(arrayExpected);
            CollectionAssert.AreEqual(expected, result);

            result = rhs.Add(rhs);
            expected = new SymmetricMatrix<int>(arrayExpected);
            CollectionAssert.AreEqual(expected, result);

            lhs = new DiagonaleMatrix<int>(array);
            result = rhs.Add(lhs);
            expected = new DiagonaleMatrix<int>(arrayExpected);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_Indexator()
        {
            var array = new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix<int> matrix = new SquareMatrix<int>(array);
            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Assert.AreEqual(array[i,j], matrix[i, j]);
                }
            }
        }
    }
}
