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
    #region Gcd tests

        [Test]
        [TestCase(64, 48, Result = 16)]
        [TestCase(1024, 24, Result = 8)]
        [TestCase(673, 71, Result = 1)]
        [TestCase(648, 324, Result = 324)]
        [TestCase(0, 15, Result = 15)]
        public int Gcd_Numbers_ReturnedTheGreatestCommonDivisor(int number1, int number2)
        {
            return MathOperations.Gcd(number1, number2);
        }

        [Test]
        public void Gcd_LargeNumberWithTotalTime_ReturnedTheGreatestCommonDivisor()
        {
            int number1 = 50468;
            int number2 = 12456;
            Stopwatch time;

            int result =  MathOperations.Gcd(number1, number2, out time);
            Debug.WriteLine($"Total time: {time.Elapsed.TotalMilliseconds}ms");

            Assert.AreEqual(4, result);           
        }

        [Test]
        [TestCase(64, 48, 128, 256, Result = 16)]
        [TestCase(2, 673, 21 , Result = 1)]
        [TestCase( 40, 80, 60 , Result = 20)]
        [TestCase(new int[]{}, ExpectedException = (typeof(ArgumentException)))]
        public int Gcd_MultipleNumbers_ReturnedTheGreatestCommonDivisor(params int[] numbers)
        {
            return MathOperations.Gcd(numbers);
        }

        [Test]
        public void Gcd_MultipleNumbersWithTotalTime_ReturnedTheGreatestCommonDivisor()
        {
            Stopwatch time;

            int result = MathOperations.Gcd(out time, 116150, 232704, 202);
            Debug.WriteLine($"Total time: {time.Elapsed.TotalMilliseconds}ms");

            Assert.AreEqual(202, result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Gcd_Null_ReturnedArgumentException()
        {
            MathOperations.Gcd(null);
        }

        [Test]
        public void SingleNumber_ReturnedSameNumber()
        {
            int number = 5;
            int result = MathOperations.Gcd(number);

            Assert.AreEqual(number, result);
        }
    #endregion

    #region GcdBinary tests
        [Test]
        [TestCase(64, 48, Result = 16)]
        [TestCase(1024, 24, Result = 8)]
        [TestCase(673, 71, Result = 1)]
        [TestCase(648, 324, Result = 324)]
        [TestCase(0, 15, Result = 15)]
        public int GcdBinary_Numbers_ReturnedTheGreatestCommonDivisor(int number1, int number2)
        {
            return MathOperations.GcdBinary(number1, number2);
        }

        [Test]
        [TestCase(64, 48, 128, 256, Result = 16)]
        [TestCase(2, 673, 21, Result = 1)]
        [TestCase(560, 0, 0, Result = 560)]
        [TestCase(40, 80, 60, Result = 20)]
        [TestCase(new int[] { }, ExpectedException = (typeof(ArgumentException)))]
        public int GcdBinary_MultipleNumbers_ReturnedTheGreatestCommonDivisor(params int[] numbers)
        {
            return MathOperations.GcdBinary(numbers);
        }

        [Test]
        public void GcdBinary_MultipleNumbersWithTotalTime_ReturnedTheGreatestCommonDivisor()
        {
            Stopwatch time;

            int result = MathOperations.GcdBinary(out time, 116150, 232704, 202);
            Debug.WriteLine($"Total time: {time.Elapsed.TotalMilliseconds}ms");

            Assert.AreEqual(202, result);
        }
    #endregion
    }
}
