using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T> : Matrix<T>
    {
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
            Array.Copy(matrix, _matrix, Order * Order);
        }
    }
}
