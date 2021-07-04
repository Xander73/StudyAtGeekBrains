using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace Lesson4
{    
    public class BenchmarkClass
    {
        HashSet<string> hs = new HashSet<string>();
        List<string> list = new List<string>();


        public BenchmarkClass ()
        {
            for (int i = 0; i < 100_000; ++i)
            {
                hs.Add(i.ToString());
                list.Add(i.ToString());
            }
        }

        [Benchmark]
        public void SearchHashSet()
        {
            hs.Contains("99998");
        }

        [Benchmark]
        public void SearchList()
        {
            list.BinarySearch ("99998");
        }
    }
}
