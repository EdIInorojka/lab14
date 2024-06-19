using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba14
{
    public class Workshop
    {
        public List<Auto> Cars { get; } // Список автомобилей в цехе

        // Конструктор по умолчанию
        public Workshop()
        {
            Cars = new List<Auto>();
        }

        // Метод для добавления автомобиля в цех
        public void AddCar(Auto car)
        {
            Cars.Add(car);
        }
    }
}
