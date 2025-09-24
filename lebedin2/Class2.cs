using System;

namespace VehiclesApp
{
    class Vehicle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Price { get; set; }
        public double Speed { get; set; }
        public int Year { get; set; }

        public Vehicle(double x, double y, double price, double speed, int year)
        {
            X = x;
            Y = y;
            Price = price;
            Speed = speed;
            Year = year;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Координати: ({X}, {Y})");
            Console.WriteLine($"Ціна: {Price} $");
            Console.WriteLine($"Швидкість: {Speed} км/год");
            Console.WriteLine($"Рік випуску: {Year}");
        }
    }
    class Plane : Vehicle
    {
        public double Height { get; set; }
        public int Passengers { get; set; }

        public Plane(double x, double y, double price, double speed, int year, double height, int passengers)
            : base(x, y, price, speed, year)
        {
            Height = height;
            Passengers = passengers;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("=== Літак ===");
            base.ShowInfo();
            Console.WriteLine($"Висота польоту: {Height} м");
            Console.WriteLine($"Кількість пасажирів: {Passengers}");
        }
    }
    class Car : Vehicle
    {
        public Car(double x, double y, double price, double speed, int year)
            : base(x, y, price, speed, year)
        {
        }

        public override void ShowInfo()
        {
            Console.WriteLine("=== Автомобіль ===");
            base.ShowInfo();
        }
    }
    class Ship : Vehicle
    {
        public int Passengers { get; set; }
        public string Port { get; set; }

        public Ship(double x, double y, double price, double speed, int year, int passengers, string port)
            : base(x, y, price, speed, year)
        {
            Passengers = passengers;
            Port = port;
        }
        public override void ShowInfo()
        {
            Console.WriteLine("=== Корабель ===");
            base.ShowInfo();
            Console.WriteLine($"Кількість пасажирів: {Passengers}");
            Console.WriteLine($"Порт приписки: {Port}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Plane plane = new Plane(10, 20, 5_000_000, 900, 2020, 10000, 150);
            Car car = new Car(50, 60, 25_000, 180, 2022);
            Ship ship = new Ship(70, 80, 2_000_000, 60, 2018, 500, "Одеса");

            Console.WriteLine("Оберіть транспортний засіб (1 - літак, 2 - автомобіль, 3 - корабель):");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    plane.ShowInfo();
                    break;
                case 2:
                    car.ShowInfo();
                    break;
                case 3:
                    ship.ShowInfo();
                    break;
                default:
                    Console.WriteLine("Неправильний вибір!");
                    break;
            }

            Console.ReadLine();
        }
    }
}
