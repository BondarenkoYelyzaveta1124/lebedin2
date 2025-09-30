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
            Console.WriteLine($"Координати: ({X}, {Y}), Ціна: {Price}, Швидкість: {Speed}, Рік випуску: {Year}");
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
            base.ShowInfo();
            Console.WriteLine($"Висота: {Height}, Пасажири: {Passengers}");
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
            base.ShowInfo();
            Console.WriteLine("Тип: Автомобіль");
        }
    }
    class Ship : Vehicle
    {
        public int Passengers { get; set; }
        public string Port { get; set; }
        public Ship(double x, double y, double price, double speed, int year,
                    int passengers, string port)
            : base(x, y, price, speed, year)
        {
            Passengers = passengers;
            Port = port;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Пасажири: {Passengers}, Порт приписки: {Port}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Vehicle[] vehicles =
            {
                new Plane(10, 20, 5000000, 850, 2018, 12000, 180),
                new Car(5, 15, 20000, 180, 2020),
                new Ship(2, 3, 1000000, 60, 2015, 300, "Одеса")
            };
            Console.WriteLine("Оберіть транспортний засіб:");
            Console.WriteLine("1 – Літак");
            Console.WriteLine("2 – Автомобіль");
            Console.WriteLine("3 – Корабель");
            Console.Write("Ваш вибір: ");
            bool isTrue = true;

            while (isTrue)
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        vehicles[0].ShowInfo();
                        break;
                    case 2:
                        vehicles[1].ShowInfo();
                        break;
                    case 3:
                        vehicles[2].ShowInfo();
                        break;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        break;
                }
            }
        }
    }
}
