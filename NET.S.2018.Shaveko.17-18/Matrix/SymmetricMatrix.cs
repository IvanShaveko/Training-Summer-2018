using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        private T[] _triangle;
 
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
            _triangle = new T[Order * Order];
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
        public SymmetricMatrix(T[,] matrix) : base(matrix)
        {
            _triangle = new T[Order * Order];
            
            for (int i = 0; i < Order; i++)
            {
                for (int j = i; j < Order; j++)
                {
                    _triangle[GetIndex(i, j)] = matrix[i, j];
                }
            }
        }

        protected override T GetValue(int i, int j) => _triangle[GetIndex(i, j)];

        protected override void SetValue(T value, int i, int j) => _triangle[GetIndex(i, j)] = value;

        private int GetIndex(int i, int j)
        {
            int result = 0;
            for (int k = 0; k < Order; k++)
            {
                for (int z = k; z < Order; z++)
                {
                    if ((i == k) && (j == z))
                    {
                        return result;
                    }

                    result++;
                }
            }

            return result;
        }
    }
}
