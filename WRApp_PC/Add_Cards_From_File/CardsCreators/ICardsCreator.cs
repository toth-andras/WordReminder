using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WRApp_PC.WRLibrary;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    /// Описывает классы, создающие карточки.
    /// </summary>
    public interface ICardsCreator
    {
        List<Card> CreateCards();
    }
}
