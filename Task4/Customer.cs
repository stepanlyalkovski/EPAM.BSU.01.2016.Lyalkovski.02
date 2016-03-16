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
            return this.ToString("F", CultureInfo.InvariantCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.InvariantCulture);
        }


        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "F";
            if (formatProvider == null) formatProvider = CultureInfo.InvariantCulture;
            string result = "Customer record: ";
            switch (format.ToUpperInvariant())
            {
                case "F":
                    result += Name + ", " + Revenue.ToString("#,###,###.00", formatProvider) + ", " + ContactPhone;
                    break;
                case "N":
                    result += Name;
                    break;
                case "T":
                    result += ContactPhone;
                    break;
                case "R":
                    result += Revenue.ToString(formatProvider);
                    break;
                case "NR":
                    result += Name + ", " + Revenue.ToString("#,###,###.00", formatProvider);
                    break;
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
            return result;
        }
    }
}
