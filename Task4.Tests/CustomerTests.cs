using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
    }
}
