using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

namespace Task4.Tests
{
    public class CustomFormatProvider : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider _parent;

        public CustomFormatProvider() : this(CultureInfo.InvariantCulture) { }

        public CustomFormatProvider(IFormatProvider parent)
        {
            _parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null)
            {
                return string.Format(_parent, "{0:" + format + "}", arg);
            }

            string ufmt = format.ToUpper(CultureInfo.InvariantCulture);
            if (ufmt != "F")
                return HandleOtherFormats(format, arg);

            Customer custom = arg as Customer;
            if (custom == null)
                throw new Exception("Oops");
            string result = String.Empty;
            switch (ufmt)
            {
                case "F":
                    result += "Customer: " + custom.Name + ", " + ". Contact phone: " + custom.ContactPhone + ", " + ". Revenue: "+ custom.Revenue.ToString("#,###,###.00", new NumberFormatInfo() { CurrencySymbol = "$"});
                    break;
            }
            return result;
        }
        private string HandleOtherFormats(string format, object arg)
        {
            IFormattable formattable = arg as IFormattable;
            if (formattable != null)
                return formattable.ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    }
}