using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class HexFormatProvider : IFormatProvider, ICustomFormatter
    {
        
        private IFormatProvider _parent;
        static readonly string[] Symbols = "0 1 2 3 4 5 6 7 8 9 A B C D E F".Split();
        public HexFormatProvider() : this(CultureInfo.CurrentCulture) {}

        public HexFormatProvider(IFormatProvider parent)
        {
            _parent = parent;
        }
        public object GetFormat(Type formatType)
        {
            return formatType == typeof (ICustomFormatter) ? this : null;
        }
        // does it belong to this class?
        public string DecToHex(int number)
        {
            StringBuilder hex = new StringBuilder();
            string result = String.Empty;
            if (number < 0)
            {
                number *= -1;
                result += "-";
            }
            do
            {
                int digit = number % 16;
                hex.Append(Symbols[digit]);
                number /= 16;
            } while (number > 0);
            result += "0x" + string.Concat(hex.ToString().Reverse());
            return result;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || format != "H")
            { 
                return string.Format(_parent, "{0:" + format + "}", arg);
            }
            
            if (arg is int)
                return DecToHex((int)arg);

            throw new ArgumentException($"{nameof(arg)} argument type: {arg.GetType()} is not supported");
        }
    }
}
