using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    using System;

    public class Auto : IInit, IComparable, ICloneable
    {
        private static int nextId = 1;

        public int Id { get; private set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public double _yoi; // year of issue (год выпуска)
        public double _cost; // стоимость
        public double _clearance; // дорожный просвет

        public string[] _brandArr = { "BMW", "Honda", "Volkswagen", "Ford", "Audi" }; // список из имеющихся брендов авто
        public string[] _colorArr = { "black", "white", "green", "purple", "pink" }; // список цветов

        public Random rnd = new Random();

        public double Yoi
        {
            get => _yoi;
            set
            {
                if (value >= 0 && value <= 2024)
                    _yoi = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(Yoi), "Год выпуска должен быть в диапазоне от 0 до 2024");
            }
        }

        public double Cost
        {
            get => _cost;
            set
            {
                if (value >= 0)
                    _cost = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(Cost), "Стоимость не может быть отрицательной");
            }
        }

        public double Clearance
        {
            get => _clearance;
            set
            {
                if (value >= 0)
                    _clearance = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(Clearance), "Дорожный просвет не может быть отрицательным");
            }
        }

        private readonly Random _rnd = new Random();

        public Auto() // конструктор без параметров
        {
            Id = GenerateId();
            Brand = "no brand";
            Color = "no color";
            Yoi = 0;
            Cost = 0;
            Clearance = 0;
        }

        public Auto(string brand, string color, double yoi, double cost, double clearance) // конструктор с параметрами
        {
            Id = GenerateId();
            Brand = brand;
            Color = color;
            Yoi = yoi;
            Cost = cost;
            Clearance = clearance;
        }

        private static int GenerateId()
        {
            return nextId++;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Auto))
                return false;

            var other = (Auto)obj;
            return Id == other.Id &&
                   Brand == other.Brand &&
                   Color == other.Color &&
                   Yoi == other.Yoi &&
                   Cost == other.Cost &&
                   Clearance == other.Clearance;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Бренд: {Brand}, цвет: {Color}, год выпуска: {Yoi}, стоимость: {Cost}, дорожный просвет: {Clearance}";
        }

        public virtual void Init()
        {
            Console.Write("Введите бренд: ");
            Brand = Console.ReadLine();

            Console.Write("Введите цвет: ");
            Color = Console.ReadLine();

            Console.Write("Введите год выпуска: ");
            Yoi = InputDoubleNumber();

            Console.Write("Введите стоимость: ");
            Cost = InputDoubleNumber();

            Console.Write("Введите размер просвета: ");
            Clearance = InputDoubleNumber();
        }

        public virtual void RandomInit()
        {
            Brand = _brandArr[_rnd.Next(_brandArr.Length)];
            Color = _colorArr[_rnd.Next(_colorArr.Length)];
            Yoi = _rnd.Next(1950, 2024);
            Cost = _rnd.Next(1, 1000000);
            Clearance = _rnd.Next(0, 100);
        }

        public virtual void Show() // виртуальный метод
        {
            Console.WriteLine($"Auto; Id: {Id}, Бренд: {Brand}, цвет: {Color}, год выпуска: {Yoi}, стоимость: {Cost}, дорожный просвет: {Clearance}");
        }

        public void Shownw() // невиртуальный метод
        {
            Console.WriteLine($"Id: {Id}, Бренд: {Brand}, цвет: {Color}, год выпуска: {Yoi}, стоимость: {Cost}, дорожный просвет: {Clearance}");
        }

        public static double InputDoubleNumber() // проверка на число типа double
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double number))
                    return number;

                Console.WriteLine("Пожалуйста, введите число: ");
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return -1;

            if (!(obj is Auto))
                throw new ArgumentException("Объект не является типом Auto", nameof(obj));

            Auto other = (Auto)obj;
            return Cost.CompareTo(other.Cost);
        }

        public object Clone()
        {
            return new Auto(Brand, Color, Yoi, Cost, Clearance);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + (Brand?.GetHashCode() ?? 0);
                hash = hash * 23 + (Color?.GetHashCode() ?? 0);
                hash = hash * 23 + Yoi.GetHashCode();
                hash = hash * 23 + Cost.GetHashCode();
                hash = hash * 23 + Clearance.GetHashCode();
                return hash;
            }
        }

        public int CompareTo<T>(T data) where T : IInit, ICloneable, new()
        {
            throw new NotImplementedException();
        }
    }

}
