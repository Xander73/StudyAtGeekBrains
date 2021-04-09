using System;
using static System.Console;

namespace PosadskovLesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstExercise();

            WriteLine(ConvertAndSummNumbers());

            ThirdExercie();

            FibonacciCalculation();

            ParserSentences();




        }

        #region Методы первого упражнения
        static void FirstExercise()
        {
            string[][] fullNames = new string[][]
            {
                new string[] {"Петров", "Петр", "Петрович" },
                new string[] {"Иванов", "Иван", "Иванович" },
                new string[] {"Сидоров", "Сидор", "Сидорович" }
            };

            for (int i = 0; i < fullNames.Length; i++)
            {
                printFullNames(GetFulLName(fullNames[i][1], fullNames[i][0], fullNames[i][2]));
                Console.WriteLine();
            }
        }

        static string GetFulLName(string name, string lastName, string patronymic) => lastName + " " + name + " " + patronymic;

        static void printFullNames(string fullName) => WriteLine(fullName);
        #endregion

        #region Методы второго упражнения
        static double ConvertAndSummNumbers()
        {
            WriteLine("Введите числа через пробел");

            string numbers = ReadLine();
            string tempNumber = default;
            double result = default;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == ' ')
                {
                    if (double.TryParse(tempNumber, out double d))
                    {
                        result += ConvertToDouble(ref tempNumber);
                    }
                    else
                    {
                        WriteLine("Введенные данные не корректны.");
                        return 0.0;
                    }
                }
                else if (i == numbers.Length - 1)
                {
                    tempNumber += numbers[i];
                    if (double.TryParse(tempNumber, out double d))
                    {
                        result += ConvertToDouble(ref tempNumber);
                    }
                    else
                    {
                        WriteLine("Введенные данные не корректны.");
                        return 0.0;
                    }
                }
                else
                {
                    if (numbers[i] == '.')
                    {
                        tempNumber += ',';
                    }
                    else
                    {
                        tempNumber += numbers[i];
                    }
                }
            }
            return result;
        }
        static double ConvertToDouble(ref string tempNumber)
        {
            if (double.TryParse(tempNumber, out double d))
            {
                tempNumber = default;
                return d;
            }

            WriteLine("Введенные данные не корректны.");
            return 0.0;

        }
        #endregion

        #region Методы третьего упражнения
        enum Seasons { Winter = 1, Spring, Summer, Outumn }

        static void ThirdExercie ()
        {
            WriteLine("Введите число от 1 до 12");
            while (true)
            {
                try
                {
                    WriteLine(PrintSeason(DefineSeason(Convert.ToInt32(ReadLine()))));

                    ReadKey();
                    return;
                }
                catch
                {
                    WriteLine("Ошибка: введите число от 1 до 12");
                }
            }
        }

        static int DefineSeason(int numberMonth)
        {
            switch (numberMonth)
                {
                    case 12:
                    case 1:
                    case 2:
                        return (int) Seasons.Winter;

                    case 3:
                    case 4:
                    case 5:
                        return (int) Seasons.Spring;

                    case 6:
                    case 7:
                    case 8:
                        return (int) Seasons.Summer;

                    case 9:
                    case 10:
                    case 11:
                        return (int) Seasons.Outumn;
                default:                    
                    return 0;
                }
            
            
        }

        static Seasons PrintSeason (int numberMonth)
        {
            while (true)
            {
                switch (numberMonth)
                {
                    case 1:
                        return Seasons.Winter;

                    case 2:
                        return Seasons.Spring;

                    case 3:
                        return Seasons.Summer;

                    case 4:
                        return Seasons.Outumn;                        
                }

                WriteLine("Ошибка: введите число от 1 до 12.");
                numberMonth = Convert.ToInt32(ReadLine());
            }
        }
        #endregion

        #region Методы четвертого упражнения Фибоначчи
        static void FibonacciCalculation ()
        {
            ulong lastNumber = 0, result = 1;

            WriteLine("Введите положительное число для расчета числа Фибоначчи");
            WriteLine(Calculation(lastNumber, result, Convert.ToInt32(ReadLine()) - 2));

        }

        static ulong Calculation (ulong lastNumber, ulong result, int number)
        {
            if (number < 0)
            {
                WriteLine("Введено отрицаьельно число. Нужно только положительное");
                    return 0;
            }

            if (number == 0)
            {
                return result;
            }
            else
            {
                return Calculation(result, result + lastNumber, --number);
            }
        }
        #endregion

        #region Методы пятого упражнения
        static void ParserSentences ()
        {
            string sentences = " Предложение один Теперь предложение два Предложение три";
            string result = default;
            int indexResentChanges = 0;

            for (int i = 0; i < sentences.Length; i++)
            {
                if (char.IsUpper(sentences[i]))
                {
                    if ((i - 2) > 0)
                    {
                        result += AddDotAndFindSubstring(indexResentChanges, i - 1, sentences);                            

                        indexResentChanges = i - 1;
                    }
                }               
            }

            result += AddDotAndFindSubstring(indexResentChanges, sentences.Length, sentences);                

            WriteLine(result);
        }

        static string AddDotAndFindSubstring(int indexResentChanges, int curIndex, string sentences) =>
            sentences.Substring(indexResentChanges, curIndex - indexResentChanges) + '.';
        #endregion


    }
}
