using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class FibonacciRecursion
    {
        public static int ProcessingFibonacci(int number)
        {            
            if (number < 0)
            {
                Console.WriteLine("Введено число ниже нуля");
                return -1;
            }
            else
            {
                return Calculate(number);
            }

        }

        public static int Calculate(int number)
        {
            if (number == 0)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                return Calculate(number - 1) + Calculate(number - 2);
            }
        }
    }
}
