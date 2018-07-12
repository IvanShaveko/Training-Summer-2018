using System;
using System.Globalization;


namespace CustomerFormatExtension
{
    using Customer;

    /// <summary>
    /// Customer format 
    /// </summary>
    public class CustomerFormatExtension: IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider _parent;

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="parent"></param>
        public CustomerFormatExtension(IFormatProvider parent)
        {
            _parent = parent;
        }

        /// <summary>
        /// Constructor with culutre
        /// </summary>
        public CustomerFormatExtension() : this(CultureInfo.CurrentCulture){ }

        /// <summary>
        /// Method to get format
        /// </summary>
        /// <param name="formatType">
        /// Format type
        /// </param>
        /// <returns>
        /// Null or object with this format
        /// </returns>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        /// <summary>
        /// Method to return string in some format 
        /// </summary>
        /// <param name="format">
        /// Format parameter
        /// </param>
        /// <param name="arg">
        /// Object
        /// </param>
        /// <param name="formatProvider">
        /// Instance 
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throw when object is not a Customer
        /// </exception>
        /// <exception cref="FormatException">
        /// Throw when fprmat is not exist
        /// </exception>
        /// <returns>
        /// Formatted string
        /// </returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }

            if (arg == null)
            {
                return string.Format(this._parent, "{0:" + format + "}", arg);
            }

            if (!(arg is Customer))
            {
                throw new ArgumentException($"{nameof(arg)} must be Customer");
            }

            Customer tmp = (Customer)arg;

            switch (format)
            {
                case "N": return string.Format(formatProvider, "{0}", tmp.Name);
                case "P": return string.Format(formatProvider, "{0}", tmp.ContactPhone);
                case "R": return string.Format(formatProvider, "{0}", tmp.Revenue);
                case "G": return string.Format(formatProvider, "{0} {1} {2}", tmp.Name, tmp.ContactPhone, tmp.Revenue);
                case "C": return string.Format(formatProvider, "{0} {1}", tmp.Name, tmp.ContactPhone);
            }

            throw new FormatException($"Doesn't exist this {nameof(format)}");
        }
    }
}
