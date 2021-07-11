using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary
{
    /// <summary>
    /// Сравнивает карточки по их рейтингу.
    /// </summary>
    class CardComparer : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            return x.Rating.CompareTo(y.Rating);
        }
    }
}
