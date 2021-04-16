using PosadskovLesson6.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PosadskovLesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            //KillProcess();

            try
            {
                Console.WriteLine(SummArray());
            }

            catch (MyArrayDataException ex)
            {
                Console.WriteLine($"Ошибка ввода данных.\nВ ячейке [{ex.PointException}] не числовое значение.");
            }
            catch (MyArraySizeException)
            {
                Console.WriteLine($"Ошибка размера массива.");
            }
            catch
            {
                Console.WriteLine("Что-то пошло совсем плохо.");
            }

            Console.ReadKey();
        }

        #region Задание на убийство
        public static void KillProcess()
        {
            Process[] processes = Process.GetProcesses();

            foreach (var item in processes)
            {
                Console.Write("Name: " + item.ProcessName);
                Console.CursorLeft = 50;
                Console.WriteLine("id: " + item.Id);
            }

            Console.WriteLine("\nВведите имя процесса или его id.\n");

            FindProcess(processes);

            processes = Process.GetProcesses();
            foreach (var item in processes)
            {
                Console.Write("Name: " + item.ProcessName);
                Console.CursorLeft = 50;
                Console.WriteLine("id: " + item.Id);
            }

        }

        static void FindProcess(Process[] pr)
        {
            string result = Console.ReadLine();

            IEnumerable<Process> processToKill = default;
            if (int.TryParse(result, out int id))
            {
                if ((processToKill = from i in pr where i.Id == id select i) != null)
                {
                    Kill(pr, processToKill);
                    pr[Array.IndexOf(pr, processToKill.First())].Kill();
                    Console.WriteLine($"Процесс {processToKill} уничтожен.");
                }
                else
                {
                    Console.WriteLine("Данный id не существует.");
                }
            }
            else
            {
                if ((processToKill = from i in pr where i.ProcessName == result select i) != null)
                {
                    Kill(pr, processToKill);
                    Console.WriteLine($"Процесс {processToKill} уничтожен.");
                }
            }
        }

        static void Kill(Process[] arrPr, IEnumerable<Process> pr)
        {
            arrPr[Array.IndexOf(arrPr, pr.First())].Kill();
        }
        #endregion

        static int SummArray()
        {
            string[][] rightArray = new string[][]
            {
                new string[] {"1", "2", "3", "4" },
                new string[] {"5", "6", "7", "8" },
                new string[] {"9", "10", "11", "12"},
                new string[] {"13", "14", "15", "16"}
            };

            string[][] wrongArray = new string[][]
            {
                new string[] {"1", "2", "3", "4" },
                new string[] {"5", "6", "7", "8" },
                new string[] {"9", "10", "11", "12"}
            };

            string[][] wrongDataArray = new string[][]
            {
                new string[] {"1", "2", "3", "4" },
                new string[] {"5", "6", "7", "8" },
                new string[] {"9", "10", "11", "12"},
                new string[] {"13", "14", "y", "16"}
            };

            const int SIZEARRAY = 4;

            int result = 0;
            if (rightArray.Length != SIZEARRAY)
            {
                throw new MyArraySizeException();
            }

            for (int i = 0; i < rightArray.Length; ++i)
            {
                if (rightArray[i].Length != SIZEARRAY)
                {
                    throw new MyArraySizeException();
                }

                for (int j = 0; j < rightArray[i].Length; j++)
                {
                    if (int.TryParse(rightArray[i][j], out int o))
                    {
                        result += o;
                    }
                    else
                    {
                        throw new MyArrayDataException(i, j);
                    }
                }
            }
            return result;
        }
    }
}
