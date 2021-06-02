using System;

namespace Lesson1
{
    public class IsEmptyNumber
    {
        public static string Start()
        {
            Console.WriteLine("Введите число");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                return IsEmpty(number);
            }
            else
            {
                Console.WriteLine("Введены некорректные данные");
                return "Введены некорректные данные";
            }
        }

        public static string IsEmpty(int number)
        {
            if (number < 1)
            {
                return "Wrong parameter";
            }
            int i = 2;
            int d = 0;
            
            while (i < number)
            {
                d += number % i == 0 ? 1 : 0;
                ++i;
            }
            string result = "";
            Console.WriteLine(result = d == 0 ? "Empty" : "Not empty");
            return result;
        }
    }
}
