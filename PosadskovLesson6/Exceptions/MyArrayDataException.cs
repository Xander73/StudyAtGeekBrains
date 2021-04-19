using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosadskovLesson6.Exceptions
{
    public class MyArrayDataException : Exception
    {
        private KeyValuePair<int, int> pointExeption;
        public KeyValuePair<int, int> PointException { get => pointExeption;  }

        public MyArrayDataException(int i, int j) => pointExeption = new KeyValuePair<int, int>(i, j);
    }
}
