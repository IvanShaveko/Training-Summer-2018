using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayExtencion
{
    /// <summary>
    /// Interface of compare
    /// </summary>
    public interface ICompare
    {
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="lhs">
        /// First array
        /// </param>
        /// <param name="rhs">
        /// Second array
        /// </param>
        /// <returns>
        /// Difference betwen numbers
        /// </returns>
        int Compare(int[] lhs, int[] rhs);
    }
}
