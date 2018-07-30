using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// Abstract class matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Matrix<T> : IEnumerable<T>
    {
        #region Properties
        
        /// <summary>
        /// Order of matrix
        /// </summary>
        public int Order { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor of matrix with order
        /// </summary>
        /// <param name="order">
        /// Order
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throw when order less or equal 0
        /// </exception>
        protected Matrix(int order)
        {
            if (order <= 0)
            {
                throw new ArgumentException($"{nameof(order)} must be greater than 0");
            }

            Order = order;
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
        protected Matrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null))
            {
                throw new ArgumentNullException($"{nameof(matrix)} can not be null");
            }

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException($"{nameof(matrix)} must be square");
            }

            Order = matrix.GetLength(0);
        }

        #endregion

        /// <summary>
        /// Indeksator
        /// </summary>
        /// <param name="i">
        /// Row
        /// </param>
        /// <param name="j">
        /// Colum
        /// </param>
        /// <returns>
        /// Value of i and j
        /// </returns>
        public T this[int i, int j] {
            get
            {
                ValidateMatrix(i, j);
                return GetValue(i, j);
            }
            set
            {
                ValidateMatrix(i, j);

                var oldValue = GetValue(i, j);
                SetValue(value, i, j);
                OnChangeElement(this, new MatrixEventArgs<T>(i, j, oldValue, value));
            }
        }

        /// <summary>
        /// Iterator
        /// </summary>
        /// <returns>
        /// Return value of element int matrix
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    yield return GetValue(i, j);
                }
            }
        }

        /// <summary>
        /// Interface memeber
        /// </summary>
        /// <returns>
        /// GetEnumerator
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region Methods

        /// <summary>
        /// Event of change element
        /// </summary>
        public event EventHandler<MatrixEventArgs<T>> ChangeElement = delegate { };

        #endregion

        /// <summary>
        /// On change element
        /// </summary>
        /// <param name="sender">
        /// Sender
        /// </param>
        /// <param name="eventArgs">
        /// EventArgs
        /// </param>
        protected virtual void OnChangeElement(object sender, MatrixEventArgs<T> eventArgs)
        {
            EventHandler<MatrixEventArgs<T>> tmp = ChangeElement;
            tmp?.Invoke(sender, eventArgs);
        }

        /// <summary>
        /// Validate matrix
        /// </summary>
        /// <param name="i">
        /// Row
        /// </param>
        /// <param name="j">
        /// Colum
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateMatrix(int i, int j)
        {
            if (i < 0 || j < 0 || i > Order || j > Order)
            {
                throw new ArgumentOutOfRangeException($"{nameof(i)} or {nameof(j)} is out of range");
            }
        }

        /// <summary>
        /// GetValue
        /// </summary>
        /// <param name="i">
        /// Row
        /// </param>
        /// <param name="j">
        /// Column
        /// </param>
        protected abstract T GetValue(int i, int j);

        /// <summary>
        /// SetValue
        /// </summary>
        /// <param name="value">
        /// Value
        /// </param>
        /// <param name="i">
        /// Row
        /// </param>
        /// <param name="j">
        /// Column
        /// </param>
        protected abstract void SetValue(T value, int i, int j);
    }
}
