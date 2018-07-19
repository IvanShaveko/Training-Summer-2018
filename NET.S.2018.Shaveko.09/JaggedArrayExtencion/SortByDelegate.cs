using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayExtencion
{
    public class SortByDelegate : IComparer<int[]>
    {
        private readonly Comparison<int[]> _comparison;

        public SortByDelegate(Comparison<int[]> comparison)
        {
            _comparison = comparison;
        }


        public int Compare(int[] lhs, int[] rhs)
        {
            return _comparison(lhs, rhs);
        }
    }
}
