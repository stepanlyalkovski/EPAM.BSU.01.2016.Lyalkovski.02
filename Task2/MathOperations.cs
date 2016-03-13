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
        public static int Gcd(int number1, int number2)
        {
            while (number1 != 0 && number2 != 0)
            {
                if (number1 > number2)
                    number1 %= number2;
                else
                    number2 %= number1;
            }
            return number1 == 0 ? number2 : number1;
        }
        /// <summary>
        /// Return the greatest common divisor (GCD) of two numbers with the time complexity 
        /// of Euclidean algorithm
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="time">Total time</param>
        /// <returns></returns>
        public static int Gcd(int number1, int number2, out Stopwatch time)
        {
            time = Stopwatch.StartNew();
            int result = Gcd(number1, number2);
            time.Stop();
            return result;
        }
        
    }
}
