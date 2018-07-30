using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class DiagonaleMatrix<T> : Matrix<T>
    {
        private T[] _diagonale; 

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
            _diagonale = new T[order];
        }

        
        public DiagonaleMatrix(T[,] matrix) : base(matrix)
        {
            _diagonale = new T[Order];
            for (int i = 0; i < Order; i++)
            {
                _diagonale[i] = matrix[i, i];
            }
        }

        protected override T GetValue(int i, int j) => i == j ? _diagonale[i] : default(T);

        protected override void SetValue(T value, int i, int j)
        {
            if (i == j)
            {
                _diagonale[i] = value;
            }
        }
    }
}
