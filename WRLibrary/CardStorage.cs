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
            if (card is null)
            {
                throw new NullReferenceException("Parameter 'card' in method AddCard of class CardStorage was null.");
            }

            cards.Add(card);
            // Отсортировать карточки снова.
            cards.Sort(new CardComparer());
        }

        /// <summary>
        /// Добавить коллекцию карточек в хранилище.
        /// </summary>
        /// <param name="cardsToAdd">Коллекция карточек.</param>
        public void AddCards(IEnumerable<Card> cardsToAdd)
        {
            if (cardsToAdd is null)
            {
                throw new NullReferenceException("Parameter 'cardsToAdd' in method AddCards of class CardStorage was null.");
            }

            cards.AddRange(cardsToAdd);
        }

        public void Save()
        {
            cardIOService.Write(cards);
        }

        /// <summary>
        /// Возвращает набор карт для опроса.
        /// </summary>
        /// <returns></returns>
        public Card[] GetCardsForQuest()
        {
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
