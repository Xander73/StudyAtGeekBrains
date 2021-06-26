using BenchmarkDotNet.Attributes;
using System;

namespace Lesson3
{
    public class BenchmarkClass
    {
        public float PointDistanceClass (PointClassFloat one, PointClassFloat two)
        {
            float x = one.x + two.x;
            float y = one.y + two.y;

            return MathF.Sqrt((x * x) + (y * y));
        }

        public float PointDistanceStructFloat(PointStruct one, PointStruct two)
        {
            float x = one.xFloat + two.xFloat;
            float y = one.yFloat + two.yFloat;

            return MathF.Sqrt((x * x) + (y * y));
        }

        public double PointDistanceStructDouble(PointStruct one, PointStruct two)
        {
            double x = one.xDouble + two.xDouble;
            double y = one.yDouble + two.yDouble;

            return Math.Sqrt((x * x) + (y * y));
        }

        public float PointDistanceStructFloatWithoutSqrt(PointStruct one, PointStruct two)
        {
            float x = one.xFloat + two.xFloat;
            float y = one.yFloat + two.yFloat;

            return (x * x) + (y * y);
        }

        [Benchmark]
        public void PointDistanceClassTest ()
        {
            PointDistanceClass(new PointClassFloat(), new PointClassFloat());
        }

        [Benchmark]
        public void PointDistanceStructFloatTest()
        {
            PointDistanceStructFloat(new PointStruct (9, 3), new PointStruct(9, 3));
        }

        [Benchmark]
        public void PointDistanceStructDoubleTest()
        {
            PointDistanceStructDouble(new PointStruct(9, 3), new PointStruct(9, 3));
        }
        [Benchmark]
        public void PointDistanceStructFloatWithoutSqrtTest()
        {
            PointDistanceStructFloatWithoutSqrt(new PointStruct(9, 3), new PointStruct(9, 3));
        }
    }
}
