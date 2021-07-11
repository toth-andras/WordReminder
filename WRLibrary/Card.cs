using System;

namespace WRLibrary
{
    /// <summary>
    /// Базовый класс для представления любой пары "Значение 1 (термин) - Значение 2 (перевод)".
    /// </summary>
    public class Card 
    {
        // Формирует рейтинг карточки.
        private CardStatistic statistic;

        /// <summary>
        /// Первое значение карточки - термин.
        /// </summary>
        public string Term { get; private set; }

        /// <summary>
        /// Второе значение карточки - значение термина (перевод).
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Рейтинг карточки.
        /// </summary>
        public int Rating 
        {
            get { return statistic.Rating; }
        }

        /// <summary>
        /// Категория карточки.
        /// </summary>
        public CardCategory Category { get; private set; }

        /// <summary>
        /// Дата создания карточки.
        /// </summary>
        public DateTime CreationDate { get; private set; }

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

            statistic = new CardStatistic(CreationDate);
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
        /// Отрабатывает поведение карточки, когда при ее использовании был дан правильный ответ.
        /// </summary>
        public void OnCorrectAnswer()
        {
            statistic.CorrectAnswer();
        }

        /// <summary>
        /// Отрабатывает поведение карточки, когда при ее использовании был дан неправильный ответ.
        /// </summary>
        public void OnMistake()
        {
            statistic.Mistake();
        }
    }
}
