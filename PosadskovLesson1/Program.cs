using System;

namespace PosadskovLesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите Ваше имя.");
            string name = Console.ReadLine();
            Console.WriteLine($"Привет,  {name}. Сегодня {DateTime.Now.ToShortDateString()}");

            Console.ReadKey();
        }
    }
}
