using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Task4.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer cust = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

        [Test]
        [TestCase(null, Result = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]   
        [TestCase("T", Result = "Customer record: +1 (425) 555-0100")]
        [TestCase("NR", Result = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("R", Result = "Customer record: 1000000")]
        [TestCase("F", Result = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        public string GetCustomer_Format(string format)
        {
            return cust.ToString(format);
        }
        [TestCase("F", Result = "Customer: Jeffrey Richter.Contact phone: +1(425) 555 - 0100.Revenue: $1, 000, 000.00")]
        public string GetCustomer_UseCustomFormatProvider(string format)
        {
            CustomFormatProvider cfp = new CustomFormatProvider();
            string result = cfp.Format(format, cust, null);
            //string.Format(new CustomFormatProvider(), format, cust );//cust.ToString(format, new CustomFormatProvider());
            Debug.WriteLine(result);
            return result;
        }


    }
}
