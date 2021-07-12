using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class BucketSortClass
    {
        public static List<int> BucketSort(List<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }

            if (list.Count < 2)
                return list;
            const int RANGE_NUMBERS_IN_BUCKET = 10;
            var max = list.Max();
            List<List<int>> tempArray = new List<List<int>>();
            for (int i = 0; i < max / RANGE_NUMBERS_IN_BUCKET + 1; ++i)
            {
                tempArray.Add(new List<int>());
            }
            foreach (var item in list)
            {
                tempArray[(item / RANGE_NUMBERS_IN_BUCKET)].Add(item);
            }

            for (int i = 0; i < tempArray.Count; ++i)
            {
                tempArray[i].Sort();
            }
            list.Clear();
            foreach (var item in tempArray)
            {
                list.AddRange(item);
            }
            return list;
        }
    }
}

