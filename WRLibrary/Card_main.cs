using System;
using WRLibrary.Services;

namespace WRLibrary
{
    /// <summary>
    /// Базовый класс для представления любой пары "Значение 1 (термин) - Значение 2 (перевод)".
    /// </summary>
    public partial class Card 
    {
        /// <summary>
        /// Первое значение карточки - термин.
        /// </summary>
        public string Term { get; private set; }

        /// <summary>
        /// Второе значение карточки - значение термина (перевод).
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Категория карточки.
        /// </summary>
        public CardCategory Category { get; private set; }

        public Card(string term, string value)
        {
            term = term.Trim();
            value = value.Trim();

            if (String.IsNullOrEmpty(term) || String.IsNullOrEmpty(value))
            {
                throw new NullOrEmptyStringException();
            }

            Term = term;
            Value = value;
            CreationDate = DateTime.Now;

            totalMistakesCount = 0;
            totalCorrectAnswerCount = 0;
        }

        public Card(CardIOModel model)
        {
            Term = model.Term;
            Value = model.Value;
            Category = model.Category;
            totalMistakesCount = model.TotalMistakesCount;
            totalCorrectAnswerCount = model.TotalCorrectAnswerCount;
            CreationDate = model.CreationDate;
            lastMistakeDate = model.LastMistakeDate;
            lastUsedDate = model.LastUsedDate;
            lastAnswer = model.LastAnswer;
        }

        public override string ToString() 
        {
            return $"{Category}: {Term} - {Value} ({CreationDate.ToString("dd.MM.yyyy")})";
        }

        /// <summary>
        /// Изменить значения карточки.
        /// </summary>
        /// <param name="term">Новое значение первого значения карточки.</param>
        /// <param name="value">Новое значение второго значения карточки.</param>
        public void Edit(string term, string value)
        {
            term = term.Trim();
            value = value.Trim();

            if (String.IsNullOrEmpty(term) || String.IsNullOrEmpty(value))
            {
                throw new NullOrEmptyStringException();
            }

            Term = term;
            Value = value;
        }

        /// <summary>
        /// Возвращает специальный объект для хранения карточки в памяти компьютера.
        /// </summary>
        public CardIOModel ToIOModel()
        {
            return new CardIOModel(Term, Value, Category, totalMistakesCount, totalCorrectAnswerCount, CreationDate, lastMistakeDate, lastUsedDate, lastAnswer);
        }
    }
}
