using ExpressionApp;
using System;

namespace lebedin2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Menu.ShowMenu();
                Console.Write("Ваш вибір: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RunCalculator(new ExpressionCalculator());
                        break;
                    case 2:
                        RunCalculator(new RecursiveExpressionCalculator());
                        break;
                    case 0:
                        Console.WriteLine("Вихід з програми...");
                        break;
                    default:
                        Console.WriteLine("Неправильний вибір!");
                        break;
                }
                Console.WriteLine();
            }
            while (choice != 0);
        }

        static void RunCalculator(ExpressionCalculator calc)
        {
            Console.Write("Введіть n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введіть x: ");
            double x = double.Parse(Console.ReadLine());

            if (calc.Calculate(n, x, out double result))
                Console.WriteLine($"Результат: {result}");
            else
                Console.WriteLine("Помилка при обчисленні!");
        }
    }
}
