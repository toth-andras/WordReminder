using System;
using System.Linq;
using System.Collections.Generic;

using WRLibrary.Services;

namespace WRLibrary
{
    /// <summary>
    /// Хранилище всех карточек пользователя.
    /// </summary>
    public class CardStorage
    {
        // Сколько карточек должно быть в каждом опросе.
        private readonly int cardsPerQest;

        // Все карточки хранилища.
        private List<Card> cards;

        // Сервис для чтения и записи карточек.
        private CardIOService cardIOService;

        public CardStorage()
        {
            this.cardsPerQest = 10;
            cardIOService = new CardIOService($"{Environment.CurrentDirectory}\\cards.json");
            try
            {
                cards = cardIOService.Read();
            }
            catch (CardIOServiceException)
            {
                cards = new List<Card>();
            }
        }

        /// <summary>
        /// Добавить карточку в хранилище.
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card)
        {
            if (card == null)
            {
                throw new NullReferenceException("Parameter 'card' was null.");
            }

            cards.Add(card);
        }

        public void Save()
        {
            cardIOService.Write(cards);
        }

        // TO DO: убрать из этого  | метода Sort()
        //                         V  
        /// <summary>
        /// Возвращает набор карт для опроса.
        /// </summary>
        /// <returns></returns>
        public Card[] GetCardsForQuest()
        {
            // Должны быть возвращены с самым маленьким рейтингом.
            cards.Sort(new CardComparer());

            if (cards.Count < cardsPerQest)
            {
                return cards.ToArray();
            }
            return cards.Slice(to: cardsPerQest).ToArray();  
        }

        /// <summary>
        /// Возвращает все карточки указанной категории.
        /// </summary>
        /// <param name="category">Категория</param>
        public Card[] GetCardsByCathegory(CardCategory category)
        {
            if (category == null)
            {
                throw new NullReferenceException("'category' was null.");
            }

            return (from card in cards where card.Category == category select card).ToArray() ;
        }

        /// <summary>
        /// Возвращает все карточки, созданные до указанной даты.
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns></returns>
        public Card[] GetCardsBeforeDate(DateTime date)
        {
            if (date > DateTime.Now)
            {
                throw new FutureDateException();
            }

            return (from card in cards where card.CreationDate < date select card).ToArray();
        }
    }
}
