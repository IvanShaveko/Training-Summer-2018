using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitInsert
{
    /// <summary>
    /// Bit insert numbers
    /// </summary>
    /// 
    public class BitInsert
    {
        /// <summary>
        /// Insert Number
        /// </summary>
        /// <param name="numberSource">
        /// Number in which insert
        /// </param>
        /// <param name="numberIn">
        /// Number which insert
        /// </param>
        /// <param name="i">
        /// Start
        /// </param>
        /// <param name="j">
        /// End
        /// </param>
        /// <returns>
        /// Return int number
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throw when i less than 0 and j bigger than 31 
        /// </exception>
        ///<exception cref="ArgumentException">
        /// Throw when i bigger than j
        /// </exception> 

        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i < 0 || j > 31)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (j < i)
            {
                throw new ArgumentException();
            }
            
            int mask = (1 << (j - i + 1)) - 1;
            numberIn = (numberIn & mask) << i;
            mask = ~((1 << i) - 1);
            numberSource = numberSource & mask;
            return numberIn | numberSource;
        }
    }
}
