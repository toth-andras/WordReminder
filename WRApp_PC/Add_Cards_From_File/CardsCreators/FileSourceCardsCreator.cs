using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using WRApp_PC.WRLibrary;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    /// Создает карточки из файла с двумя столбцами .csv формата.
    /// </summary>
    public class FileSourceCardsCreator : ICardsCreator
    {
        private readonly string filePath;

        public FileSourceCardsCreator(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Card> CreateCards()
        {
            List<Card> cards = new List<Card>();

            string[] linesFromFile = File.ReadAllLines(filePath);

            // Индексы с единицы, т.к. первая строчка - названия столбцов.
            for (int i = 1; i < linesFromFile.Length; i++)
            {
                string[] words = linesFromFile[i].Split(',');

                try
                {
                    Card card = new Card(words[0], words[1]);
                    cards.Add(card);
                }
                // Если карточку не получается создать из-за логических
                // ограничений, то данные просто игнорируются.
                catch (CardAlreadyExistsException) { }
                catch (NullOrEmptyStringException) { }
            }

            return cards;
        }
    }
}
