using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WRApp_PC.WRLibrary;

namespace WRApp_PC.UserControls
{
    /// <summary>
    /// Класс-контейнер для передачи информации о карточке.
    /// </summary>
    public class CardEventArgs : EventArgs
    {
        public Card Card { get; private set; }

        public CardEventArgs(Card card)
        {
            Card = card;
        }
    }
}
