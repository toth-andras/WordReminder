using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary
{
    /// <summary>
    /// Компонент, составляющий рейтинг карточки.
    /// </summary>
    class CardStatistic
    {
        // Когда создали карточку.
        private DateTime cardCreationDate;

        // Сколько раз при использовании карточки были допущены ошибки.
        private int totalMistakesCount;

        // Сколько раз при использовании карточки был дан верный ответ.
        private int totalCorrectAnswerCount;

        // Дата последнего раза, когда при использовании карточки была допущена ошибка.
        private DateTime? lastMistakeDate;

        // Дата последнего использования карточки.
        private DateTime? cardLastUsedDate;

        // Каким был последний ответ при использовании карточки.
        private UserAnswer lastAnswer;

        public int Rating { get; private set; }

        public CardStatistic(DateTime cardCreationDate)
        {
            Rating = 0;

            this.cardCreationDate = cardCreationDate;
            totalMistakesCount = 0;
            totalCorrectAnswerCount = 0;
        }

        private void CountRating()
        {

        }

        /// <summary>
        /// Изменяет рейтинг карточки, предполагая, что 
        /// пользователем при использовании был дан правильный ответ.
        /// </summary>
        public void CorrectAnswer()
        {
            totalCorrectAnswerCount++;
            lastAnswer = UserAnswer.CorrectAnswer;
            cardLastUsedDate = DateTime.Now;
        }
        /// <summary>
        /// Изменяет рейтинг карточки, предполагая, что 
        /// пользователем при использовании был дан неправильный ответ.
        /// </summary>
        public void Mistake()
        {
            totalMistakesCount++;
            lastAnswer = UserAnswer.Mistake;
            lastMistakeDate = DateTime.Now;
            cardLastUsedDate = DateTime.Now;
        }
    }
}
