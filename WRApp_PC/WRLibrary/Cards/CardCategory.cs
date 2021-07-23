using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.WRLibrary
{
    /// <summary>
    /// Базовый класс для представления категории карточки.
    /// </summary>
    public class CardCategory: ICloneable
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

        public object Clone()
        {
            CardCategory category = new CardCategory((string)this.Name.Clone());
            category.CreationDate = this.CreationDate;

            return category;
        }

        public static bool operator ==(CardCategory card1, CardCategory card2)
        {
            if (card1 is null || card2 is null)
            {
                if (card1 is null && card2 is null)
                {
                    return true;
                }
                return false;
            }
            return card1.Name == card2.Name;
        }
        public static bool operator !=(CardCategory card1, CardCategory card2)
        {
            return !(card1.Name == card2.Name);
        }
    }
}
