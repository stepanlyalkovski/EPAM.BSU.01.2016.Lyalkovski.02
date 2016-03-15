using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace Task2
{
    public static class MathOperations
    {
        /// <summary>
        /// Return the greatest common divisor (GCD) of two numbers
        /// </summary>
        private static int Gcd(int number1, int number2)
        {
            //Debug.WriteLine($"{number1} {number2}");
            return number2 == 0 ? number1 : Gcd(number2, number1 % number2);
        }

        private static int SteinGcd(int number1, int number2)
        {
            if (number1 < 0) number1 *= -1;
            if (number2 < 0) number2 *= -1;

            if (number1 == 0) return number2;
            if (number2 == 0) return number1;
            if (number1 == number2) return number1;

            bool value1IsEven = (number1 & 1) == 0;
            bool value2IsEven = (number2 & 1) == 0;

            if (value1IsEven && value2IsEven)
                return GcdBinary(number1 >> 1, number2 >> 1) << 1;
            else if (value1IsEven && !value2IsEven)
                return GcdBinary(number1 >> 1, number2);
            else if (value2IsEven)
                return GcdBinary(number1, number2 >> 1);
            else if (number1 > number2)
                return GcdBinary((number1 - number2) >> 1, number2);
            else
                return GcdBinary(number1, (number2 - number1) >> 1);
        }

        /// <summary>
        /// Return the greatest common divisor (GCD) of two numbers with the time complexity 
        /// of Euclidean algorithm
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="elapsedTime"></param>
        /// <returns>the greatest common divisor(GCD)</returns>
        public static int Gcd(int number1, int number2, out double elapsedTime)
        {
            Stopwatch totalTime = Stopwatch.StartNew();
            int result = Gcd(number1, number2);
            elapsedTime = totalTime.Elapsed.TotalMilliseconds;
            return result;
        }

        public static int Gcd(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("Number of arguments is empty or equals null");

            return numbers.Aggregate(Gcd);
        } 

        public static int Gcd(out double elapsedTime, params int[] numbers)
        {
            Stopwatch totalime = Stopwatch.StartNew();
            int result = numbers.Aggregate(Gcd);
            elapsedTime = totalime.Elapsed.TotalMilliseconds;
            return result;
        }
        // temporary solution
        public static int GcdBinary(int number1, int number2) => SteinGcd(number1, number2);

        public static int GcdBinary(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("Number of arguments is empty or equals null");

            return numbers.Aggregate(SteinGcd);
        }

        public static int GcdBinary(out double elapsedTime, params int[] numbers)
        {
            Stopwatch totalTime = Stopwatch.StartNew();
            int result = numbers.Aggregate(SteinGcd);
            elapsedTime = totalTime.Elapsed.TotalMilliseconds;
            return result;
        }
        
    }
}
