using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

        [TestCase(145, Result = "0x91")]
        [TestCase(-145, Result = "-0x91")]
        [TestCase(0, Result = "0x0")]
        [TestCase(41837, Result = "0xA36D")]
        [TestCase(47, Result = "0x2F")]
        [TestCase(47.2, ExpectedException = typeof(ArgumentException))]
        public string Format_Test(object number)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            IFormatProvider fp = new HexFormatProvider();
            return string.Format(fp, "{0:H}", number);
        }

        [TestCase(47, "{0:X}", Result = "2F")]
        [TestCase(.473, "{0:P}", Result = "47.30 %")]
        [TestCase(.473, "{0:P0}", Result = "47 %")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.7321, "{0:F2}", Result = "4.73")]
        public string ParentFormat_Test(object number, string format)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            IFormatProvider fp = new HexFormatProvider();
            return string.Format(fp, format, number);
        }



    }
}
