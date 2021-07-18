using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson1
{
    public class DateTemperatureHolder
    {
        public int Count => datesTemperatures.Count;
        private Dictionary<DateTime, double> datesTemperatures = new Dictionary<DateTime, double>();
        public Dictionary<DateTime, double> DatesTemperatures 
        {
            get => datesTemperatures;
            set => datesTemperatures = value;
        }
        public DateTemperatureHolder()
        {
            datesTemperatures = new Dictionary<DateTime, double> ();
            for (int i = 0; i < 10; ++i )
            {
                DateTime dt = DateTime.Now;
                dt = dt.AddDays(i);
                datesTemperatures.Add(dt.Date, 10 + i * 10);
            }
        }

        public void Save (DateTime date, double temperature)
        {
            if (DatesTemperatures.ContainsKey(date.Date))
            {
                DatesTemperatures[date.Date] = temperature;
            }
            else
            {
                datesTemperatures.Add(date.Date, temperature);
            }
        }

        public void Update (DateTime date, double temperature)
        {
            if (DatesTemperatures.ContainsKey(date.Date))
            {
                datesTemperatures[date.Date] = temperature;                
            }
        }

        public void Delete (DateTime fromDate, DateTime toDate)
        {
            Dictionary<DateTime, double> temp = new Dictionary<DateTime, double>();
            foreach (var item in DatesTemperatures)
            {
                if (item.Key < fromDate.Date || item.Key > toDate.Date)
                {
                    temp.Add(item.Key, item.Value);
                }
            }
            DatesTemperatures = temp;
        }

        public string Get(DateTime fromDate, DateTime toDate)
        {
            
            string result = "";
            foreach (var item in datesTemperatures)
            {
                if (item.Key.Date >= fromDate && item.Key.Date <= toDate)
                result += item.Key.ToShortDateString() + " - " + item.Value + '\n';
            }

            return result;
        }
        
    }
}
