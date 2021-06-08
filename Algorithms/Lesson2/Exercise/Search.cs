using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    public class Search
    {
        //Асимтотическая сложность Log(n)
        public static int BinarySearch(int[] arr, int begin, int end, int element)
        {
            if (arr.Length == 0)
            {
                throw new ArgumentNullException();
            }

            if (arr == null)
            {
                throw new NullReferenceException();
            }            

            int mid = (end + begin) / 2;

            if (mid < begin)
                throw new KeyNotFoundException();

            if(mid < 0 )
            {
                if (arr[0] == element)
                {
                    return 0;
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }
            if (element == arr[mid])
            {
                return mid;
            }
            else if (element < arr[mid])
            {
                return BinarySearch(arr, begin, mid - 1, element);
            }
            else
            {
                return BinarySearch(arr, mid + 1, end, element);
            }  
        }
    }
}
