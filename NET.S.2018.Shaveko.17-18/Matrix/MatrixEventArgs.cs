using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// Matrix event args
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MatrixEventArgs<T> : EventArgs
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="row">
        /// Row
        /// </param>
        /// <param name="colums">
        /// Colum
        /// </param>
        /// <param name="oldValue">
        /// Old value
        /// </param>
        /// <param name="newValue">
        /// New value
        /// </param>
        public MatrixEventArgs(int row, int colums, T oldValue, T newValue)
        {
            Row = row;
            Colums = colums;
            OldValue = oldValue;
            NewValue = newValue;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Row
        /// </summary>
        public int Row { get; }
        
        /// <summary>
        /// Colum
        /// </summary>
        public int Colums { get; }

        /// <summary>
        /// Old value
        /// </summary>
        public T OldValue { get; }

        /// <summary>
        /// New value
        /// </summary>
        public T NewValue { get; }

        #endregion
    }
}
