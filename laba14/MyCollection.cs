using System.Collections;

namespace laba14
{
    // Обобщенный класс для коллекции автомобилей
    public class MyCollection<T> : IEnumerable<T>
    {
        private List<T> items; // Внутренний список элементов коллекции

        // Конструктор по умолчанию
        public MyCollection()
        {
            items = new List<T>();
        }

        // Добавление элемента в коллекцию
        public void Add(T item)
        {
            items.Add(item);
        }

        // Реализация интерфейса IEnumerable для перебора элементов коллекции
        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        // Реализация необобщенного интерфейса IEnumerable для перебора элементов коллекции
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Методы Union, Except, Intersect для коллекции
        public IEnumerable<T> Union(IEnumerable<T> collection)
        {
            return items.Union(collection);
        }

        public IEnumerable<T> Except(IEnumerable<T> collection)
        {
            return items.Except(collection);
        }

        public IEnumerable<T> Intersect(IEnumerable<T> collection)
        {
            return items.Intersect(collection);
        }

        // Методы на агрегирование данных (Sum, Max, Min, Average) для коллекции
        public double Sum(System.Func<T, double> selector)
        {
            double sum = 0;
            foreach (var item in items)
            {
                sum += selector(item);
            }
            return sum;
        }

        public double Max(System.Func<T, double> selector)
        {
            double max = double.MinValue;
            foreach (var item in items)
            {
                var value = selector(item);
                if (value > max)
                {
                    max = value;
                }
            }
            return max;
        }

        public double Min(System.Func<T, double> selector)
        {
            double min = double.MaxValue;
            foreach (var item in items)
            {
                var value = selector(item);
                if (value < min)
                {
                    min = value;
                }
            }
            return min;
        }

        public double Average(System.Func<T, double> selector)
        {
            if (items.Count == 0)
                return 0;

            double sum = 0;
            foreach (var item in items)
            {
                sum += selector(item);
            }
            return sum / items.Count;
        }
    }
}
