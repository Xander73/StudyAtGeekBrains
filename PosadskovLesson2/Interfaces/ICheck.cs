using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosadskovLesson2.Interfaces
{
    interface ICheck
    {
        List<KeyValuePair<string, double>> Purchases { get; set; }
        void Print();
        void AddPurchase(string namePurchase, double pricePurchase);
        string Sum();
    }
}
