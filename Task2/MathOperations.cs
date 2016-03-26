using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace Task2
{
    public static class MathOperations
    {

        private static int EuclideanGcd(int number1, int number2)
        {
            //Debug.WriteLine($"{number1} {number2}");
            return number2 == 0 ? number1 : EuclideanGcd(number2, number1 % number2);
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
            if (value1IsEven && !value2IsEven)
                return GcdBinary(number1 >> 1, number2);
            if (value2IsEven)
                return GcdBinary(number1, number2 >> 1);
            if (number1 > number2)
                return GcdBinary((number1 - number2) >> 1, number2);
            return GcdBinary(number1, (number2 - number1) >> 1);
        }

        

        public static int Gcd(Func<int, int, int> GcdAlgorithm, int number1, int number2)
        {
            return number1 > number2 ? GcdAlgorithm(number1, number2) : GcdAlgorithm(number2, number1);
        }

        public static int Gcd(Func<int, int, int> GcdAlgorithm, int number1, int number2, out double elapsedTime)
        {
            Stopwatch totalTime = Stopwatch.StartNew();
            int result = GcdAlgorithm(number1, number2);
            elapsedTime = totalTime.Elapsed.TotalMilliseconds;
            return result;
        }

        public static int Gcd(Func<int, int, int> GcdAlgorithm, params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("Number of arguments is empty or equals null");

            return numbers.Aggregate(GcdAlgorithm);
        }

        public static int Gcd(Func<int, int, int> GcdAlgorithm, out double elapsedTime, params int[] numbers)
        {
            Stopwatch totalime = Stopwatch.StartNew();
            int result = numbers.Aggregate(GcdAlgorithm);
            elapsedTime = totalime.Elapsed.TotalMilliseconds;
            return result;
        }

        /// <summary>
        /// EuclideanGcd algorithm 
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns>the greatest common divisor (GCD) of two numbers</returns>
        public static int Gcd(int number1, int number2) => Gcd(EuclideanGcd, number2, number1%number2);

        /// <summary>
        /// Return the greatest common divisor (GCD) of two numbers with the time complexity 
        /// of EuclideanGcd algorithm
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="elapsedTime">Algorithm time</param>
        /// <returns>the greatest common divisor(GCD)</returns>
        public static int Gcd(int number1, int number2, out double elapsedTime)
            => Gcd(EuclideanGcd, number1, number2, out elapsedTime);

        public static int Gcd(int number1, int number2, int number3) => Gcd(Gcd(number1, number2), number3);

        public static int Gcd(int number1, int number2, int number3, out double elapsedTime)
        {
            Stopwatch totalTime = Stopwatch.StartNew();
            int result = Gcd(Gcd(number1, number2), number3);
            elapsedTime = totalTime.Elapsed.TotalMilliseconds;
            return result;
        }

        public static int Gcd(params int[] numbers) => Gcd(EuclideanGcd, numbers);

        public static int Gcd(out double elapsedTime, params int[] numbers)
            => Gcd(EuclideanGcd, out elapsedTime, numbers);


        public static int GcdBinary(int number1, int number2) => Gcd(SteinGcd, number1, number2);

        public static int GcdBinary(int number1, int number2, int number3) => GcdBinary(GcdBinary(number1, number2), number3);

        public static int GcdBinary(int number1, int number2, int number3, out double elapsedTime)
        {
            Stopwatch totalTime = Stopwatch.StartNew();
            int result = GcdBinary(GcdBinary(number1, number2), number3);
            elapsedTime = totalTime.Elapsed.TotalMilliseconds;
            return result;
        }

        public static int GcdBinary(params int[] numbers) => Gcd(SteinGcd, numbers);

        public static int GcdBinary(out double elapsedTime, params int[] numbers)
            => Gcd(SteinGcd, out elapsedTime, numbers);
               
    }
}
