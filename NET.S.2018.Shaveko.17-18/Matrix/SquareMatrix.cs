using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T> : Matrix<T>
    {
        private T[] _matrix;

        /// <summary>
        /// Constructor of matrix with order
        /// </summary>
        /// <param name="order">
        /// Order
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throw when order less or equal 0
        /// </exception>
        public SquareMatrix(int order) : base(order)
        {
        }

        /// <summary>
        /// Constructor of matrix with array
        /// </summary>
        /// <param name="matrix">
        /// Array
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when array is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws when array is not square
        /// </exception>
        public SquareMatrix(T[,] matrix) : base(matrix)
        {
            _matrix = new T[Order * Order];
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    _matrix[GetIndex(i, j)] = matrix[i, j];
                }
            }
        }

        private int GetIndex(int i, int j) => i * Order + j;

        protected override T GetValue(int i, int j) => _matrix[GetIndex(i, j)];

        protected override void SetValue(T value, int i, int j) => _matrix[GetIndex(i, j)] = value;
    }
}
