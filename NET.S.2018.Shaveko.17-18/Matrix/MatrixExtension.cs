using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// Matrix add extension
    /// </summary>
    public static class MatrixExtension 
    {
        #region Extension methods

        #region Public API

        /// <summary>
        /// Add two matrix
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lhs">
        /// First matrix
        /// </param>
        /// <param name="rhs">
        /// Added matrix
        /// </param>
        /// <returns>
        /// Sum of matrix
        /// </returns>
        public static Matrix<T> Add<T>(this Matrix<T> lhs, Matrix<T> rhs)
        {
            if (lhs.Order != rhs.Order)
            {
                throw new ArgumentException("Orders of matrix are not equal");
            }

            return Add<T>((dynamic)lhs, (dynamic) rhs);
        }

        #endregion

        #region

        private static SquareMatrix<T> Add<T>(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            var result = new T[lhs.Order, lhs.Order];

            for (int i = 0; i < lhs.Order; i++)
            {
                for (int j = 0; j < lhs.Order; j++)
                {
                    result[i, j] = (dynamic)lhs[i, j] + (dynamic)rhs[i, j];
                }
            }

            return new SquareMatrix<T>(result);
        }

        private static SquareMatrix<T> Add<T>(SquareMatrix<T> lhs, DiagonaleMatrix<T> rhs)
        {
            var result = new T[lhs.Order, lhs.Order];

            for (int i = 0; i < lhs.Order; i++)
            {
                for (int j = 0; j < lhs.Order; j++)
                {
                    result[i, j] = (dynamic)lhs[i, j] + (dynamic)rhs[i, j];
                }
            }

            return new SquareMatrix<T>(result);
        }

        private static SquareMatrix<T> Add<T>(SquareMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            var result = new T[lhs.Order, lhs.Order];

            for (int i = 0; i < lhs.Order; i++)
            {
                for (int j = 0; j < lhs.Order; j++)
                {
                    result[i, j] = (dynamic)lhs[i, j] + (dynamic)rhs[i, j];
                }
            }

            return new SquareMatrix<T>(result);
        }

        private static SquareMatrix<T> Add<T>(DiagonaleMatrix<T> lhs, SquareMatrix<T> rhs) => Add(rhs, lhs);

        private static DiagonaleMatrix<T> Add<T>(DiagonaleMatrix<T> lhs, DiagonaleMatrix<T> rhs)
        {
            var result = new T[lhs.Order, lhs.Order];

            for (int i = 0; i < lhs.Order; i++)
            {
                for (int j = 0; j < lhs.Order; j++)
                {
                    result[i, j] = (dynamic)lhs[i, j] + (dynamic)rhs[i, j];
                }
            }

            return new DiagonaleMatrix<T>(result);
        }

        private static DiagonaleMatrix<T> Add<T>(DiagonaleMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            var result = new T[lhs.Order, lhs.Order];

            for (int i = 0; i < lhs.Order; i++)
            {
                for (int j = 0; j < lhs.Order; j++)
                {
                    result[i, j] = (dynamic)lhs[i, j] + (dynamic)rhs[i, j];
                }
            }

            return new DiagonaleMatrix<T>(result);
        }

        private static SymmetricMatrix<T> Add<T>(SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            var result = new T[lhs.Order, lhs.Order];

            for (int i = 0; i < lhs.Order; i++)
            {
                for (int j = 0; j < lhs.Order; j++)
                {
                    result[i, j] = (dynamic)lhs[i, j] + (dynamic)rhs[i, j];
                }
            }

            return new SymmetricMatrix<T>(result);
        }

        private static SquareMatrix<T> Add<T>(SymmetricMatrix<T> lhs, SquareMatrix<T> rhs) => Add(rhs, lhs);

        private static DiagonaleMatrix<T> Add<T>(SymmetricMatrix<T> lhs, DiagonaleMatrix<T> rhs) => Add(rhs, lhs);

        #endregion

        #endregion
    }
}
