using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6
{
    public class Node
    {
        public string Name { get; set; }
        public int Value { get; set; } = 1;
        public bool IsChecked = false;
        public List<Edge> Edges { get; set; }
    }
}
