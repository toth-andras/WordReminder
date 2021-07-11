using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary
{
    public static class ListExtension
    {
        /// <summary>
        /// Предоставляет механизм среза для списков.
        /// </summary>
        /// <param name="cards">Список</param>
        /// <param name="from">Нижняя (включая) граница среза.</param>
        /// <param name="to">Верхняя (не включая) граница среза.</param>
        /// <returns> Срез объектов изначального списка.</returns>
        public static List<Card> Slice(this List<Card> cards, int from = 0, int to = -1)
        {
            if (to == -1)
            {
                to = cards.Count;
            }

            if (from < 0 || from >= cards.Count)
            {
                throw new Exception("Incorrect left border.");
            }
            if (to < 0 || to >= cards.Count)
            {
                throw new Exception("Incorrect right border.");
            }
            if (from >= to)
            {
                throw new Exception("Left border must be less than right border.");
            }

            List<Card> result = new List<Card>();
            for (int i = from; i < to; i++)
            {
                result.Add(cards[i]);
            }

            return result;
        }
    }
}
