using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;
namespace Task2.Tests
{
    [TestFixture]
    public class MathOperationsTests
    {
        [Test]
        [TestCase(64, 48, Result = 16)]
        [TestCase(1024, 24, Result = 8)]
        [TestCase(673, 71, Result = 1)]
        [TestCase(648, 324, Result = 324)]
        public int Gcd_numbers_returnedValue(int number1, int number2)
        {
            return MathOperations.Gcd(number1, number2);
        }

        [Test]
        public void Gcd_LargeNumberWithTotalTime()
        {
            int number1 = 50468;
            int number2 = 12456;
            Stopwatch time;

            int result =  MathOperations.Gcd(number1, number2, out time);
            Debug.WriteLine($"Total time: {time.Elapsed.TotalMilliseconds}ms");

            Assert.AreEqual(4, result);
           

        }

    }
}
