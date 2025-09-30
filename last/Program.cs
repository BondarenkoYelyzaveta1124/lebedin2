using System;

namespace ExpressionSum
{
    class ExpressionBase
    {
        public virtual bool Calculate(int n, double x, out double result)
        {
            result = 0;
            if (n <= 0) return false;
            try
            {
                double sum = 0;
                for (int i = 1; i <= n; i++)
                {
                    double term;
                    if (i % 2 == 1)
                    {
                        double denominator = Math.Sin(i * x);
                        if (Math.Abs(denominator) < 1e-10) return false;
                        term = ((n - i) * (x - i)) / denominator;
                    }
                    else
                    {
                        double denominator = Math.Cos(i * x);
                        if (Math.Abs(denominator) < 1e-10) return false;
                        term = ((n - i) * (x - i)) / denominator;
                        term *= -1;
                    }
                    sum += term;
                }
                result = sum;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    class ExpressionRecursive : ExpressionBase
    {
        public override bool Calculate(int n, double x, out double result)
        {
            result = 0;
            if (n <= 0) return false;
            try
            {
                result = RecursiveTerm(n, x, 1);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private double RecursiveTerm(int n, double x, int i)
        {
            if (i > n) return 0;
            double denominator;
            double term;
            if (i % 2 == 1)
            {
                denominator = Math.Sin(i * x);
                if (Math.Abs(denominator) < 1e-10) throw new DivideByZeroException();
                term = ((n - i) * (x - i)) / denominator;
            }
            else
            {
                denominator = Math.Cos(i * x);
                if (Math.Abs(denominator) < 1e-10) throw new DivideByZeroException();
                term = -((n - i) * (x - i)) / denominator;
            }
            return term + RecursiveTerm(n, x, i + 1);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введіть x: ");
            double x = double.Parse(Console.ReadLine());

            ExpressionBase iter = new ExpressionBase();
            ExpressionBase rec = new ExpressionRecursive();

            if (iter.Calculate(n, x, out double res1))
                Console.WriteLine($"Ітераційний результат: {res1}");
            else
                Console.WriteLine("Помилка при обчисленні (ітераційний).");

            if (rec.Calculate(n, x, out double res2))
                Console.WriteLine($"Рекурсивний результат: {res2}");
            else
                Console.WriteLine("Помилка при обчисленні (рекурсивний).");
        }
    }
}
