using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace laba14
{
    public static class MyCollectionMenu
    {
        // Обработчик меню для коллекции MyCollection
        public static void HandleMenu(MyCollection<Auto> myCollection)
        {
            while (true)
            {
                // Вывод меню выбора запроса для коллекции MyCollection
                Console.WriteLine("Выберите запрос для коллекции MyCollection:");
                Console.WriteLine("1. Where");
                Console.WriteLine("2. Union/Except/Intersect");
                Console.WriteLine("3. Агрегирование данных (Sum, Max, Min, Average)");
                Console.WriteLine("4. Группировка данных (Group by)");
                Console.WriteLine("5. Получение нового типа (с использованием оператора let)");
                Console.WriteLine("6. Соединение данных");
                Console.WriteLine("0. Назад");

                string choice = Console.ReadLine(); // Читаем выбор пользователя

                switch (choice)
                {
                    case "1":
                        QueryWhere(myCollection); // Выполняем запрос Where
                        break;
                    case "2":
                        QueryUnionExceptIntersect(myCollection); // Выполняем запросы Union, Except, Intersect
                        break;
                    case "3":
                        QueryAggregation(myCollection); // Выполняем запросы на агрегирование данных
                        break;
                    case "4":
                        QueryGroupBy(myCollection); // Выполняем запрос на группировку данных
                        break;
                    case "5":
                        QueryLet(myCollection); // Выполняем запрос с использованием оператора let
                        break;
                    case "6":
                        QueryJoin(myCollection); // Выполняем запрос на соединение данных
                        break;
                    case "0":
                        return; // Возвращаемся в предыдущее меню
                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова."); // В случае некорректного выбора выводим сообщение об ошибке
                        break;
                }
            }
        }

        // Запрос Where для коллекции MyCollection
        public static void QueryWhere(MyCollection<Auto> myCollection)
        {
            // Выполняем запросы Where с использованием LINQ и методов расширения
            var whereResultLinq = myCollection.Where(car => car.Brand == "BMW").ToList();
            var whereResultExt = myCollection.Where(car => car.Brand == "BMW").ToList();

            // Выводим результаты запросов
            PrintHelper.PrintCars("Where (LINQ)", whereResultLinq);
            PrintHelper.PrintCars("Where (методы расширения)", whereResultExt);
        }

        // Запросы Union, Except, Intersect для коллекции MyCollection
        public static void QueryUnionExceptIntersect(MyCollection<Auto> myCollection)
        {
            // Выполняем запросы Union, Except, Intersect
            var queryUnion = myCollection.Union(myCollection).ToList();
            var queryExcept = myCollection.Except(myCollection).ToList();
            var queryIntersect = myCollection.Intersect(myCollection).ToList();

            // Выводим результаты запросов
            PrintResults("Union", queryUnion);
            PrintResults("Except", queryExcept);
            PrintResults("Intersect", queryIntersect);
        }

        // Запросы на агрегирование данных (Sum, Max, Min, Average) для коллекции MyCollection
        public static void QueryAggregation(MyCollection<Auto> myCollection)
        {
            // Выполняем запросы на агрегирование данных (Sum, Max, Min, Average)
            var sumCostLinq = myCollection.Sum(car => car.Cost);
            var maxCostLinq = myCollection.Max(car => car.Cost);
            var minCostLinq = myCollection.Min(car => car.Cost);
            var avgCostLinq = myCollection.Average(car => car.Cost);

            // Выводим результаты запросов на агрегирование данных
            PrintHelper.PrintAggregationResults(sumCostLinq, maxCostLinq, minCostLinq, avgCostLinq);
        }

        // Запрос на группировку данных (Group by) для коллекции MyCollection
        public static void QueryGroupBy(MyCollection<Auto> myCollection)
        {
            // Выполняем запрос на группировку данных (Group by)
            var groupedCarsLinq = myCollection.GroupBy(car => car.Brand);

            // Выводим результаты запроса на группировку данных
            PrintHelper.PrintGroupedCars("Группировка (LINQ)", groupedCarsLinq);
        }

        // Запрос с использованием оператора let для коллекции MyCollection
        public static void QueryLet(MyCollection<Auto> myCollection)
        {
            // Выполняем запрос с использованием оператора let
            var carsByBrandCount = from car in myCollection
                                   group car by car.Brand into g
                                   let count = g.Count()
                                   select new { Brand = g.Key, Count = count };

            // Выводим результаты запроса с использованием оператора let
            PrintHelper.PrintBrandCounts("оператор let", carsByBrandCount);
        }

        // Запрос на соединение данных для коллекции MyCollection
        public static void QueryJoin(MyCollection<Auto> myCollection)
        {
            // Выполняем запрос на соединение данных
            var joinedCars = myCollection.Join(myCollection, car => car.Id, car => car.Id, (car1, car2) => new { Car1 = car1, Car2 = car2 }).ToList();

            // Выводим результаты запроса на соединение данных
            PrintHelper.PrintJoinedCars("Соединение", joinedCars);
        }

        // Вспомогательный метод для вывода результатов Union, Except, Intersect
        public static void PrintResults(string queryType, IEnumerable<Auto> cars)
        {
            Console.WriteLine($"Результаты запроса ({queryType}):");
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
