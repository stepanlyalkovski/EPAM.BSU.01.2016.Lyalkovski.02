using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using  Task3;
namespace Task3.Tests
{
    [TestFixture]
    public class HexFormatProviderTests
    {
        [Test]
        [TestCase(255, Result = "0xFF")]
        [TestCase(10, Result = "0xA")]
        [TestCase(5, Result = "0x5")]
        [TestCase(24, Result = "0x18")]
        [TestCase(-14, Result = "-0xE")]
        [TestCase(64250, Result = "0xFAFA")]
        public string GetHexProvider_IntNumber_ReturnedHexadecimalFormat(int number)
        {
            IFormatProvider hProvider = new HexFormatProvider();
            return string.Format(hProvider, "{0:H}", number);
        }

        [Test]
        [TestCase(25.45, "{0:H}", ExpectedException = typeof(ArgumentException))]
        [TestCase(15, "{0:X}" , Result =  "F")]
        public string GetHexProvider_WrongTypeOrWrongFormat_ReturnedArgumentExceptionOrParentProvider(int number, string format)
        {
            IFormatProvider hProvider = new HexFormatProvider();
            return string.Format(hProvider, format, number);
        }



    }
}
