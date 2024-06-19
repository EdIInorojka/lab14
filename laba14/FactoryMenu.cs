using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace laba14
{
    public static class FactoryMenu
    {
        // Обработчик меню для фабрики и цехов
        public static void HandleMenu(Factory factory)
        {
            while (true)
            {
                // Вывод меню выбора запроса для фабрики и цехов
                Console.WriteLine("Выберите запрос для Factory и Workshops:");
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
                        QueryWhere(factory); // Выполняем запрос Where
                        break;
                    case "2":
                        QueryUnionExceptIntersect(factory); // Выполняем запросы Union, Except, Intersect
                        break;
                    case "3":
                        QueryAggregation(factory); // Выполняем запросы на агрегирование данных
                        break;
                    case "4":
                        QueryGroupBy(factory); // Выполняем запрос на группировку данных
                        break;
                    case "5":
                        QueryLet(factory); // Выполняем запрос с использованием оператора let
                        break;
                    case "6":
                        QueryJoin(factory); // Выполняем запрос на соединение данных
                        break;
                    case "0":
                        return; // Возвращаемся в предыдущее меню
                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова."); // В случае некорректного выбора выводим сообщение об ошибке
                        break;
                }
            }
        }

        // Запрос Where для фабрики и цехов
        public static void QueryWhere(Factory factory)
        {
            // Получаем все автомобили из всех цехов фабрики
            var allCars = factory.Workshops.SelectMany(w => w.Cars).ToList();

            // Выполняем запросы Where с использованием LINQ и методов расширения
            var whereResultLinq = allCars.Where(car => car.Brand == "BMW").ToList();
            var whereResultExt = allCars.Where(car => car.Brand == "BMW").ToList();

            // Выводим результаты запросов
            PrintHelper.PrintCars("Where (LINQ)", whereResultLinq);
            PrintHelper.PrintCars("Where (методы расширения)", whereResultExt);
        }

        // Запросы Union, Except, Intersect для фабрики и цехов
        public static void QueryUnionExceptIntersect(Factory factory)
        {
            // Получаем все автомобили из всех цехов фабрики
            var allCars = factory.Workshops.SelectMany(w => w.Cars).ToList();
            var allCarsUpdated = factory.Workshops.SelectMany(w => w.Cars).ToList();

            // Выполняем запросы Union, Except, Intersect
            var queryUnion = allCars.Union(allCarsUpdated).ToList();
            var queryExcept = allCars.Except(allCarsUpdated).ToList();
            var queryIntersect = allCars.Intersect(allCarsUpdated).ToList();

            // Выводим результаты запросов
            PrintResults("Union", queryUnion);
            PrintResults("Except", queryExcept);
            PrintResults("Intersect", queryIntersect);
        }

        // Запросы на агрегирование данных (Sum, Max, Min, Average) для фабрики и цехов
        public static void QueryAggregation(Factory factory)
        {
            // Получаем все автомобили из всех цехов фабрики
            var allCars = factory.Workshops.SelectMany(w => w.Cars).ToList();

            // Выполняем запросы на агрегирование данных (Sum, Max, Min, Average)
            var sumCostLinq = allCars.Sum(car => car.Cost);
            var maxCostLinq = allCars.Max(car => car.Cost);
            var minCostLinq = allCars.Min(car => car.Cost);
            var avgCostLinq = allCars.Average(car => car.Cost);

            // Выводим результаты запросов на агрегирование данных
            PrintHelper.PrintAggregationResults(sumCostLinq, maxCostLinq, minCostLinq, avgCostLinq);
        }

        // Запрос на группировку данных (Group by) для фабрики и цехов
        public static void QueryGroupBy(Factory factory)
        {
            // Получаем все автомобили из всех цехов фабрики
            var allCars = factory.Workshops.SelectMany(w => w.Cars).ToList();

            // Выполняем запрос на группировку данных (Group by)
            var groupedCarsLinq = allCars.GroupBy(car => car.Brand);

            // Выводим результаты запроса на группировку данных
            PrintHelper.PrintGroupedCars("Группировка (LINQ)", groupedCarsLinq);
        }

        // Запрос с использованием оператора let для фабрики и цехов
        public static void QueryLet(Factory factory)
        {
            // Получаем все автомобили из всех цехов фабрики
            var allCars = factory.Workshops.SelectMany(w => w.Cars).ToList();

            // Выполняем запрос с использованием оператора let
            var carsByBrandCount = from car in allCars
                                   group car by car.Brand into g
                                   let count = g.Count()
                                   select new { Brand = g.Key, Count = count };

            // Выводим результаты запроса с использованием оператора let
            PrintHelper.PrintBrandCounts("оператор let", carsByBrandCount);
        }

        // Запрос на соединение данных для фабрики и цехов
        public static void QueryJoin(Factory factory)
        {
            // Получаем все цеха и их автомобили
            var workshops = factory.Workshops.SelectMany(w => w.Cars.Select(car => new { WorkshopId = car.Id, Car = car })).ToList();

            // Выполняем запрос на соединение данных
            var joinedCars = workshops.Where(w => w.WorkshopId == 1).ToList();

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
