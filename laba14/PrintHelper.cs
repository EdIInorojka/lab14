using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace laba14
{
    public static class PrintHelper
    {
        // Вывод списка автомобилей для указанного типа запроса
        public static void PrintCars(string queryType, IEnumerable<Auto> cars)
        {
            Console.WriteLine($"Результаты запроса ({queryType}):");
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        // Вывод результатов агрегирования данных (Sum, Max, Min, Average)
        public static void PrintAggregationResults(double sumCost, double maxCost, double minCost, double avgCost)
        {
            Console.WriteLine($"Sum: {sumCost}");
            Console.WriteLine($"Max: {maxCost}");
            Console.WriteLine($"Min: {minCost}");
            Console.WriteLine($"Average: {avgCost}");
        }

        // Вывод результатов группировки данных
        public static void PrintGroupedCars(string queryType, IEnumerable<IGrouping<string, Auto>> groupedCars)
        {
            Console.WriteLine($"Результаты группировки ({queryType}):");
            foreach (var group in groupedCars)
            {
                Console.WriteLine($"Марка автомобиля: {group.Key}, Количество: {group.Count()}");
            }
        }

        // Вывод результатов оператора let
        public static void PrintBrandCounts(string queryType, IEnumerable<dynamic> carsByBrandCount)
        {
            Console.WriteLine($"Результаты запроса с использованием {queryType}:");
            foreach (var result in carsByBrandCount)
            {
                Console.WriteLine($"Марка автомобиля: {result.Brand}, Количество: {result.Count}");
            }
        }

        // Вывод результатов соединения данных
        public static void PrintJoinedCars(string queryType, IEnumerable<dynamic> joinedCars)
        {
            Console.WriteLine($"Результаты запроса на соединение ({queryType}):");
            foreach (var joinedCar in joinedCars)
            {
                Console.WriteLine($"Соединение: {joinedCar.ToString()} с {joinedCar.ToString()}");
            }
        }
    }
}
