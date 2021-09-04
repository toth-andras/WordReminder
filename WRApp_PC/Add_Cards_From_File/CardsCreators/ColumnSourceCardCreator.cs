using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WRApp_PC.WRLibrary;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    ///  Создает карточки из спредоставленных столбцов.
    /// </summary>
    public class ColumnSourceCardCreator : ICardsCreator
    {
        private Column columnOfTerms;
        private Column columnOfValues;

        public ColumnSourceCardCreator(Column columnOfTerms, Column columnOfValues)
        {
            this.columnOfTerms = columnOfTerms;
            this.columnOfValues = columnOfValues;
        }

        public List<Card> CreateCards()
        {
            // Защита на случай, если столбцы окажутся разной длины.
            int border = columnOfTerms.Values.Length;
            if (columnOfTerms.Values.Length != columnOfValues.Values.Length)
            {
                border = new List<int>() { columnOfTerms.Values.Length, columnOfValues.Values.Length }.Min();
            }

            List<Card> cards = new List<Card>();

            for (int i = 0; i < border; i++)
            {
                try
                {
                    cards.Add(new Card(columnOfTerms.Values[i], columnOfValues.Values[i]));
                }

                // Если карточку создать не получается, то ее просто не добавляют.
                catch (CardAlreadyExistsException) { }
                catch (NullOrEmptyStringException) { }
            }

            return cards;
        }
    }
}
