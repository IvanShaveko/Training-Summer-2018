using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DoubleExtension
{
    /// <summary>
    /// Convert to IEEE
    /// </summary>
    public static class DoubleExtension
    {
        private const int BITS = 64;

        /// <summary>
        /// Convert double to IEEE
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <returns>
        /// IEEE string
        /// </returns>
        public static string DoubleToBinary(this double number)
        {
            DoubleToLongStruct convert = new DoubleToLongStruct{Double64Bits = number};
            long long64Bits = convert.Long64Bits();
            string stringBits = "";

            for (int i = 0; i < BITS; i++)
            {
                char bit;
                if ((long64Bits & 1) == 1)
                {
                    bit = '1';
                }
                else
                {
                    bit = '0';
                }

                stringBits = bit + stringBits;

                long64Bits >>= 1;
            }

            return stringBits;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            private readonly long long64bits;

            [FieldOffset(0)]
            private  double double64bits;

            public double Double64Bits
            {
                set => double64bits = value;
            }

            public long Long64Bits() => long64bits;
        }
    }
}
