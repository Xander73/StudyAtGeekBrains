using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace PosadskovLesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            //SaveToFile();

            //AddTime();

            //BinaryFile();

            //PersonFunction();

            //DirectoryTreeMain();

            DirectoryTreeLoop(@"E:\0_work\Study\StudyAtGeekBrains\PosadskovLesson5\bin");


            Console.ReadKey();
        }

        static void SaveToFile()
        {
            string fileName = "text.txt";
            Console.WriteLine("Введите текс для сохранения в файл.");

            File.AppendAllText(fileName, Console.ReadLine() + '\n');

        }

        static void AddTime ()
        {
            string fileName = "startup.txt";
            File.AppendAllText(fileName, DateTime.Now.ToShortTimeString() + '\n');
        }

        static void BinaryFile()
        {
            Console.WriteLine("Ввведите через пробел несколько чисел от 0 до 255");
            string[] str = Regex.Replace(Console.ReadLine(), " +", " ").Split(" ");
            int[] binaryArr = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (int.TryParse(str[i], out int digit) && !string.IsNullOrEmpty(str[i]) && digit >= 0 && digit <= 255)
                {
                    binaryArr[i] = digit;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода данных.\nПрограмма завершает работу.");
                    return;
                }

            }
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(new FileStream("binaryArr.bin", FileMode.OpenOrCreate), binaryArr);
            }
        }

        static void PersonFunction ()
        {
            Person[] persArray = new Person[5];
            persArray[0] = new Person("Иванов И. И.", "Engineer", "email_1@mail.ru", "0-000-000-00-00", 100_000, 48);
            persArray[1] = new Person("Петрова П. П.", "Teacher", "email_2@mail.ru", "1-111-111-11-11", 200_000, 25);
            persArray[2] = new Person("Сидоров С. С.", "Driver", "email_3@mail.ru", "2-222-222-22-22", 300_000, 18);
            persArray[3] = new Person("Крайн К. К.", "Gangster", "email_4@mail.ru", "3-333-333-33-33", 400_000, 54);
            persArray[4] = new Person("Васильев В. В.", "Housholder", "email_5@mail.ru", "4-444-444-44-44", 500_000, 36);

            //вывод через LINQ
            Console.WriteLine("Вывод через LINQ\n");
            var persons = from p in persArray where p.Age > 40 select p;
            foreach (var p in persons)
                p.Info();

            //вывод по заданию через цикл
            Console.WriteLine("\nВывод через цикл\n");
            foreach (var v in persArray)
            {
                if (v.Age > 40)
                    v.Info();
            }
        }

        #region Задание из аталога про дерево каталогов
        static void DirectoryTreeMain()
        {
            Console.WriteLine("Введите даректорию");
            DirectoryTreeRecursion(Console.ReadLine());
        }
        static void DirectoryTreeRecursion (string p)
        {
            DirectoryInfo path = new DirectoryInfo (@p);
            if (!path.Exists)
            {
                Console.WriteLine("Задано неверное имя каталога.");
                return;
            }
            FileSystemInfo[] subPath = default;
            if ((subPath =  path.GetDirectories()).Length == 0)
            {
                PrintCatalog(path);
            }
            else
            {
                foreach (var item in subPath)
                {
                    DirectoryTreeRecursion(item.ToString());

                    subPath = path.GetFiles();

                    if (subPath.Length == 0)
                    {
                        return;
                    }

                    PrintCatalog(path);
                }
            } 
        }
        static void DirectoryTreeLoop(string p)
        {
            DirectoryInfo path = new DirectoryInfo(@p);
            if (!path.Exists)
            {
                Console.WriteLine("Задано неверное имя каталога.");
                return;
            }
            FileSystemInfo[] subPath = default;
            if ((subPath = path.GetDirectories()).Length == 0)
            {
                PrintCatalog(path);
            }
            else
            {
                Stack<FileSystemInfo> catalogTree = new Stack<FileSystemInfo>(subPath);
                DirectoryInfo prevCatalog = default;
                while (catalogTree.Count != 0)
                {
                    if (catalogTree.Peek() is DirectoryInfo d)
                    {
                        DirectoryInfo[] tempDi = d.GetDirectories();
                        if (tempDi.Length != 0)
                        {
                            prevCatalog = d;
                            foreach (var v in tempDi)
                            {
                                catalogTree.Push(v);
                            }
                        }
                        else
                        {
                            catalogTree.Pop();
                            PrintCatalog(d);
                        }
                    }
                    //subPath = path.GetFiles();

                    //if (subPath.Length == 0)
                    //{
                    //    return;
                    //}

                    //PrintCatalog(path);
                }
            }
        }

        static void PrintCatalog(DirectoryInfo path)
        {
            var subPath = path.GetFiles();
            Console.WriteLine('\\' + path.Name);
            for (int i = 0; i < subPath.Length; i++)
            {
                Console.WriteLine('\t' + subPath[i].Name);
            }
            Console.WriteLine();
        }
        #endregion
    }
}
