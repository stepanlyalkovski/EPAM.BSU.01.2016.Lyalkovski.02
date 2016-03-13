using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Task2
{
    public static class MathOperations
    {
        /// <summary>
        /// Return the greatest common divisor (GCD) of two numbers
        /// </summary>
        private static int Gcd(int number1, int number2)
        {
            if (number1 == 0 || number2 == 0)
                throw new ArgumentException("One of the arguments is 0");
            while (true)
            {                
                Debug.WriteLine($"{number1} {number2}");
                if (number2 == 0) return number1;
                int temp = number1;
                number1 = number2;
                number2 = temp % number2;
            }
        }

        /// <summary>
        /// Return the greatest common divisor (GCD) of two numbers with the time complexity 
        /// of Euclidean algorithm
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="time">Total time</param>
        /// <returns>the greatest common divisor(GCD)</returns>
        public static int Gcd(int number1, int number2, out Stopwatch time)
        {
            time = Stopwatch.StartNew();
            int result = Gcd(number1, number2);
            time.Stop();
            return result;
        }

        public static int Gcd(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("Number of arguments is empty or equals null");

            return numbers.Aggregate(Gcd);
        } 

        public static int Gcd(out Stopwatch time, params int[] numbers)
        {
            time = Stopwatch.StartNew();
            int result = Gcd(numbers);
            time.Stop();
            return result;
        }
    }
}
