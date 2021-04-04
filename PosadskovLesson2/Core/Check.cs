using PosadskovLesson2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosadskovLesson2
{
    public class Check : ICheck
    {
        private string companyName = "ООО \"Самая лучшая компания\"";
        private readonly string companyAddres = "Москва";

        private List<KeyValuePair<string, double>> purchases = new List<KeyValuePair<string, double>> {
                new KeyValuePair<string, double> ("Milk", 100),
                new KeyValuePair<string, double> ("Eggs", 120),
                new KeyValuePair<string, double> ("Bread", 50)
            };
        public List<KeyValuePair<string, double>> Purchases
        {
            get => purchases;
            set => purchases.AddRange(value);
        }

        public void AddPurchase(string namePurchase, double pricePurchase)
        {
            purchases.Add(new KeyValuePair <string, double> (namePurchase, pricePurchase));
        }              

        public string Sum()
        {
            double result = default;
            foreach (var v in purchases)
            {
                result += v.Value;
            }
            return result.ToString();
        }

        public void Print()
        {
            const int columnMin = 4;
            const int columnMax = 43;
            int row = 2;
            int column = 4;
            Console.SetCursorPosition(column, row);

            for (; column <= columnMax; ++column)
            {
                Console.Write('-');
            }
            for (++row; row < 4; ++row)
            {
                SetFrame(row);
            }

            #region name and addres of company
            SetFrame(row);
            Console.SetCursorPosition(column = 22 - companyName.Length / 2, row);
            Console.Write(companyName);

            ++row;
            SetFrame(row);
            Console.SetCursorPosition(column = 22 - $"Адрес: {companyAddres}".Length / 2, row);
            Console.Write("Адрес: " + companyAddres);
            ++row;
            SetFrame(row);
            #endregion

            #region add purchases
            foreach (var v in Purchases)
            {
                ++row;
                SetFrame(row);
                Console.SetCursorPosition(columnMin + 2, row);  //здесь const меня спасла, хотел присвоить значение переменной columnMin
                Console.Write(v.Key);
                int lenghtDots = columnMax - v.Key.Length - v.Value.ToString().Length - 1;
                column = columnMin + 2;
                for (; column < lenghtDots; ++column)
                {
                    Console.Write('.');
                }
                Console.Write(v.Value);
            }

            #endregion

            #region conclusion
            ++row;
            SetFrame(row);
            column = columnMin;
            Console.SetCursorPosition(columnMin + 1, row);
            for (; column < columnMax - 1; ++column)
            {
                Console.Write('=');
            }
            SetFrame(row);
            #endregion

            #region finish
            ++row;
            SetFrame(row);
            Console.SetCursorPosition(columnMin + 2, row);
            Console.Write("Итого");
            int lenghtDotsFinish = columnMax - "Итого".Length - (Sum().ToString() + " руб").Length - 1;
            column = columnMin + 2;
            for (; column < lenghtDotsFinish; ++column)
            {
                Console.Write('.');
            }
            Console.Write(Sum().ToString() + " руб");

            ++row;
            SetFrame(row);
            Console.SetCursorPosition(columnMin, row);
            column = columnMin;
            for (; column <= columnMax; ++column)
            {
                Console.Write('-');
            }
            #endregion


            Console.CursorVisible = false;
        }

        private static void SetFrame (int row)
        {
            const int columnMin = 4;
            const int columnMax = 43;
            Console.SetCursorPosition(columnMin, row);
            Console.Write('|');
            Console.SetCursorPosition(columnMax, row);
            Console.Write('|');
        }
    }
}
