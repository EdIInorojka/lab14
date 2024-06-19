using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba14
{
    // Класс представляющий фабрику с цехами
    public class Factory
    {
        public List<Workshop> Workshops { get; } // Список цехов фабрики

        // Конструктор по умолчанию
        public Factory()
        {
            Workshops = new List<Workshop>();
        }

        // Метод для добавления цеха в фабрику
        public void AddWorkshop(Workshop workshop)
        {
            Workshops.Add(workshop);
        }
    }
}
