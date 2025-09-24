using System;

namespace ExpressionApp
{
    class ExpressionCalculator
    {
        public virtual bool Calculate(int n, double x, out double result)
        {
            result = 0;
            try
            {
                for (int k = 1; k <= n; k++)
                {
                    double numerator, denominator, term;

                    if (k % 2 == 1)
                    {
                        numerator = (n - k) * (x - (k - 1));
                        denominator = Math.Sin(k * x);
                    }
                    else 
                    {
                        numerator = (n - k) * (x - (k + 1));
                        denominator = Math.Cos(k * x);
                    }

                    if (Math.Abs(denominator) < 1e-12) 
                        return false;

                    term = numerator / denominator;

                    if (k % 2 == 0)
                        term *= -1; 

                    result += term;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    class RecursiveExpressionCalculator : ExpressionCalculator
    {
        public override bool Calculate(int n, double x, out double result)
        {
            try
            {
                result = RecursiveSum(n, x, 1);
                return true;
            }
            catch
            {
                result = 0;
                return false;
            }
        }
        private double RecursiveSum(int n, double x, int k)
        {
            if (k > n) return 0;

            double numerator, denominator, term;

            if (k % 2 == 1)
            {
                numerator = (n - k) * (x - (k - 1));
                denominator = Math.Sin(k * x);
            }
            else
            {
                numerator = (n - k) * (x - (k + 1));
                denominator = Math.Cos(k * x);
            }

            if (Math.Abs(denominator) < 1e-12)
                throw new DivideByZeroException();

            term = numerator / denominator;

            if (k % 2 == 0)
                term *= -1;

            return term + RecursiveSum(n, x, k + 1);
        }
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введіть x: ");
            double x = double.Parse(Console.ReadLine());

            ExpressionCalculator calc1 = new ExpressionCalculator();
            if (calc1.Calculate(n, x, out double res1))
                Console.WriteLine($"Результат (цикл): {res1}");
            else
                Console.WriteLine("Помилка при обчисленні (цикл)");

            ExpressionCalculator calc2 = new RecursiveExpressionCalculator();
            if (calc2.Calculate(n, x, out double res2))
                Console.WriteLine($"Результат (рекурсія): {res2}");
            else
                Console.WriteLine("Помилка при обчисленні (рекурсія)");
        }
    }
}
