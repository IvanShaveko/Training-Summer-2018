using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    public class IntegerPredicate : IPredicate<int>
    {
        public bool IsMatch(int item) => item % 2 == 0;
    }

    public class StringPredicate : IPredicate<string>
    {
        public bool IsMatch(string item) => item.Length <= 5;
    }
}
