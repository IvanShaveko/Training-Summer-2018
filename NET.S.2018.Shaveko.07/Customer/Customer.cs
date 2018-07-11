using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class Customer: IFormattable
    {
        public string Name { get; }
        public string ContactPhone { get; }
        public decimal Revenue { get; }

        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }


        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "N";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpper())
            {
                case "N": return string.Format(formatProvider,"{0}", Name);
                case "P": return string.Format(formatProvider, "{0}", ContactPhone);
                case "R": return string.Format(formatProvider, "{0}", Revenue);
                case "G": return string.Format(formatProvider, "{0} {1} {2}", Name, ContactPhone, Revenue);
                case "C": return string.Format(formatProvider, "{0} {1}", Name, ContactPhone);
            }

            throw new FormatException($"{nameof(format)} doesn't exist");
        }
    }
}
