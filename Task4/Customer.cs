using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Customer : IFormattable
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        public override string ToString()
        {
            return this.ToString("F", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.InvariantCulture);
        }


        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "F";
            if (formatProvider == null) formatProvider = CultureInfo.InvariantCulture;
            NumberFormatInfo decFormatInfo = new NumberFormatInfo();
            switch (format.ToUpperInvariant())
            {
                case "F":
                    return Name + ", " + Revenue.ToString("#,###,###.00", formatProvider) + ", " + ContactPhone;
                case "N":
                    return Name;
                case "T":
                    return ContactPhone;
                case "R":
                    return Revenue.ToString(formatProvider);
                case "NR":
                    return Name + ", " + Revenue.ToString("#,###,###.00", formatProvider);
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
    }
}
