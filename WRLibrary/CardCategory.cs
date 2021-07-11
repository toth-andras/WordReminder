using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary
{
    /// <summary>
    /// Базовый класс для представления категории карточки.
    /// </summary>
    public class CardCategory
    {
        public string Name { get; private set; }

        public DateTime CreationDate { get; private set; }
        
        public CardCategory(string name)
        {
            name = name.Trim();
            if (String.IsNullOrEmpty(name))
            {
                throw new NullOrEmptyStringException();
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public static bool operator ==(CardCategory card1, CardCategory card2)
        {
            return card1.Name == card2.Name;
        }
        public static bool operator !=(CardCategory card1, CardCategory card2)
        {
            return !(card1.Name == card2.Name);
        }
    }
}
