using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
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
        public SymmetricMatrix(int order) : base(order)
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
        /// Throws when array is not square or symmetric
        /// </exception>
        public SymmetricMatrix(T[,] matrix) : base(matrix)
        {
            if (!CheckMatrix(matrix))
            {
                throw new ArgumentException($"{nameof(matrix)} does not symmetric");
            }

            Array.Copy(matrix, _matrix, Order * Order);
        }

        /// <summary>
        /// Check array on symmetric matrix
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
                    if (!Equals(matrix[i, j], matrix[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
