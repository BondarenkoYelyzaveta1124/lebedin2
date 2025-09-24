using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace _1oop
{
    struct PointXY1
    {
        public double X { get; set; }
        public double? Y { get; set; }
    }
    class Function1
    {
        public double Start { get; set; }
        public double End { get; set; }
        public double Step { get; set; }
        public PointXY1[] Values { get; private set; }
        public void Fill1()
        {
            int count = (int)((End - Start) / Step) + 1;
            Values = new PointXY1[count];

            int i = 0;
            for (double x = Start; x <= End; x += Step)
            {
                double? y = null;

                if (x <= -10)
                {
                    y = Math.Tan(Math.Sqrt(Math.Sin(x))) - 0.2;
                }
                else if (x > -5)
                {
                    double inside = 9 - x * x;
                    if (inside > 0)
                    {
                        double ln = Math.Log(inside);
                        if (ln >= 0 && ln <= 1)
                            y = Math.Acos(Math.Sqrt(ln));
                    }
                }
                Values[i++] = new PointXY1 { X = x, Y = y };
            }
        }
        public void Print1()
        {
            foreach (var point in Values)
            {
                if (point.Y.HasValue)
                    Console.WriteLine($"x = {point.X:F2}, y = {point.Y:F5}");
                else
                    Console.WriteLine($"x = {point.X:F2}, y does not exist");
            }
        }
    }
    public class PrintLast1
    {
        public static void LastExe1()
        {
            var f = new Function1 { Start = -15, End = 5, Step = 1 };
            f.Fill1();
            f.Print1();
        }
    }
}
