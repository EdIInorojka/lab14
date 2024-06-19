using ClassLibrary1;
using System;

namespace laba14
{
    public class Program
    {
        public static void Main()
        {
            // Инициализация фабрики и коллекции автомобилей
            Factory factory = InitializeFactory(); // Инициализируем фабрику
            MyCollection<Auto> myCollection = InitializeMyCollection(); // Инициализируем коллекцию

            while (true)
            {
                // Вывод меню выбора коллекции для запросов
                Console.WriteLine("Выберите коллекцию для запросов:");
                Console.WriteLine("1. Коллекция Factory и Workshops");
                Console.WriteLine("2. Коллекция MyCollection");
                Console.WriteLine("0. Выход");

                string collectionChoice = Console.ReadLine();

                switch (collectionChoice)
                {
                    case "1":
                        FactoryMenu.HandleMenu(factory); // Обрабатываем выбор для фабрики
                        break;
                    case "2":
                        MyCollectionMenu.HandleMenu(myCollection); // Обрабатываем выбор для коллекции
                        break;
                    case "0":
                        return; // Выход из программы
                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова."); // В случае некорректного выбора выводим сообщение об ошибке
                        break;
                }
            }
        }

        // Метод инициализации фабрики
        public static Factory InitializeFactory()
        {
            Factory factory = new Factory(); // Создаем новую фабрику
            Workshop workshop1 = new Workshop(); // Создаем первый цех
            Workshop workshop2 = new Workshop(); // Создаем второй цех

            // Генерируем 15 автомобилей для каждого цеха и добавляем их в фабрику
            for (int i = 0; i < 15; i++)
            {
                workshop1.AddCar(new Auto()); // Добавляем автомобиль в первый цех
                workshop2.AddCar(new Auto()); // Добавляем автомобиль во второй цех
            }

            // Добавляем цехи в фабрику
            factory.AddWorkshop(workshop1);
            factory.AddWorkshop(workshop2);

            return factory; // Возвращаем инициализированную фабрику
        }

        // Метод инициализации коллекции автомобилей
        public static MyCollection<Auto> InitializeMyCollection()
        {
            MyCollection<Auto> myCollection = new MyCollection<Auto>(); // Создаем новую коллекцию

            // Генерируем 10 автомобилей, инициализируем случайными данными и добавляем их в коллекцию
            for (int i = 0; i < 10; i++)
            {
                Auto auto = new Auto(); // Создаем новый автомобиль
                auto.RandomInit(); // Инициализируем случайными данными
                myCollection.Add(auto); // Добавляем автомобиль в коллекцию
            }

            return myCollection; // Возвращаем инициализированную коллекцию
        }
    }
}
