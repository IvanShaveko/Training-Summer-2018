using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class DiagonaleMatrix<T> : SquareMatrix<T>
    {
        /// <inheritdoc />
        /// <summary>
        /// Constructor of matrix with order
        /// </summary>
        /// <param name="order">
        /// Order
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// Throw when order less or equal 0
        /// </exception>
        public DiagonaleMatrix(int order) : base(order)
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
        /// Throws when array is not square of diagonale
        /// </exception>
        public DiagonaleMatrix(T[,] matrix) : base(matrix)
        {
            if (!CheckMatrix(matrix))
            {
                throw new ArgumentException($"{nameof(matrix)} does not diagonale");
            }

            Array.Copy(matrix, _matrix, Order * Order);
        }

        /// <summary>
        /// Check array on diagonale matrix
        /// </summary>
        /// <param name="matrix">
        /// Matrix
        /// </param>
        /// <returns>
        /// True or false
        /// </returns>
        private bool CheckMatrix(T[,] matrix)
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    if (i != j)
                    {
                        if (!Equals(matrix[i, j], default(T)))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
