using PosadskovLesson2.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PosadskovLesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(AvgTemperature(out double avgTemperature));

            //Console.WriteLine(CurrentMonth(avgTemperature));

            //Console.WriteLine(EvenNumber());

            //Check();

            BitMask();

            Console.ReadKey();
        }

        public static string AvgTemperature(out double avgTemperature)
        {
            string result = default;
            try
            {
                double tMax = 0, tMin = 0;

                Console.WriteLine("Введите максимальную температуру.");
                if (double.TryParse(Console.ReadLine(), out double tMaxTemp))
                {
                    tMax = tMaxTemp;
                }
                else
                {
                    throw new FormatException("Ошибка! Введено не числовое значение.\nПовторите ввод данных.\n");
                }

                Console.WriteLine("Введите минимальную температуру.");
                if (double.TryParse(Console.ReadLine(), out double tMinTemp))
                {
                    tMin = tMinTemp;
                }
                else
                {
                    throw new FormatException("Ошибка! Введено не числовое значение.\nПовторите ввод данных.\n");
                }

                if (tMax < tMin)
                {
                    throw new FormatException("Ошибка!\nЗначение максимальной температуры ниже минимальной.\nПовторите ввод данных.\n");
                }

                result = $"Среднесуточная темпеартура равна - {avgTemperature = (tMax + tMin) / 2}\n";
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                result = AvgTemperature(out double avgTemperatureRecursion);
                avgTemperature = avgTemperatureRecursion;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Что-то пошло совсем плохо.\n");
                result = AvgTemperature(out double avgTemperatureRecursion);
                avgTemperature = avgTemperatureRecursion;
            }
            return result;
        }

        public static string CurrentMonth(double avgTemperature)
        {
            Console.WriteLine("Введите номер текущего месяца.");
            if (int.TryParse(Console.ReadLine(), out int numberCurrentMonthTemp) && (numberCurrentMonthTemp < 13 && numberCurrentMonthTemp > 0))
            {
                DateTime d = new DateTime(1, numberCurrentMonthTemp, 1);
                if ((d.Month == 12 || d.Month == 1 || d.Month == 2) && avgTemperature > 0)
                    return $"Сейчас {d.ToString("MMMM")} месяц.\nДождливая зима.";
                return $"Сейчас {d.ToString("MMMM")} месяц.";
            }
            else
            {
                Console.WriteLine("Такого месяца нет.\n");
                return CurrentMonth(avgTemperature);
            }
        }

        public static string EvenNumber()
        {
            Console.WriteLine("Введите число.");

            if (double.TryParse(Console.ReadLine(), out double number))
            {
                return number % 2 == 0 ? "\nЧисло четное." : "\nЧисло нечетное.";
            }
            else
            {
                Console.WriteLine("Введено не число.\n");
                return EvenNumber();
            }

        }

        public static void Check ()
        {
            ICheck check = new Check();
            check.AddPurchase("Buter", 600);
            check.Print();
        }

        static void BitMask ()
        {
            DaysWeek Office1 = DaysWeek.Tuesday | DaysWeek.Wednesday | DaysWeek.Thersday | DaysWeek.Friday;
            DaysWeek Office2 = DaysWeek.Monday | DaysWeek.Tuesday | DaysWeek.Wednesday | DaysWeek.Thersday |
                               DaysWeek.Friday | DaysWeek.Saturday | DaysWeek.Saturday;
            Console.WriteLine($"Офис №1 работает в {Office1}.\n");
            Console.WriteLine($"Офис №2 работает в {Office2}.\n");

        }
    }
    [Flags]
    enum DaysWeek
    {
        Monday = 0b_0000_0001,
        Tuesday = 0b_0000_0010,
        Wednesday = 0b_0000_0100,
        Thersday = 0b_0000_1000,
        Friday = 0b_0001_0000,
        Saturday = 0b_0010_0000,
        Sunday = 0b_0100_0000
    }
}
