using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson8
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 100; ++i)
            {
                list.Add(new Random().Next(100));
            }

            list = BucketSortClass.BucketSort(list);

            foreach (var item in list)
                Console.WriteLine(item);
        }

    }

}
