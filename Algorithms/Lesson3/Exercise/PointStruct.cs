using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson3
{
    public struct PointStruct
    {
        public float xFloat;
        public float yFloat;
        public double xDouble;
        public double yDouble;

        public PointStruct (double x, double y)
        {
            xFloat = (float)x;
            yFloat = (float)y;
            xDouble = x;
            yDouble = y;
        }
    }
}
