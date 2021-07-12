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
        private UserAnswer? lastAnswer;

        public int Rating 
        {
            get 
            {
                return CountRating();
            } 
        }

        public CardStatistic(DateTime cardCreationDate)
        {
            this.cardCreationDate = cardCreationDate;
            totalMistakesCount = 0;
            totalCorrectAnswerCount = 0;
        }

        // Подсчет рейтинга карточки.
        private int CountRating()
        {
            int rating = 0;

            // Дата создания карточки
            rating += ManageCreationDate();

            // Кол-во правильных и неправильных ответов
            rating += ManageCorrectAnswersMistakes();

            // Даты последнего использования и последней ошибки
            rating += ManageLastDates();

            // Последний ответ
            rating += ManageLastAnswer();

            return rating;
        }

        // Высчитать значение кривой Эббингауза для момента
        // времени через minutesPassed минут.
        private double Ebbinghaus(double minutesPassed)
        {
            // Данные для формулы кривой Эббингауза
            const double k = 1.84;
            const double c = 1.25;

            return 100 * k / (Math.Pow(Math.Log(minutesPassed), c) + k);
        }

        // Подсчитывает баллы за дату создания карточки.
        private int ManageCreationDate()
        {
            var delta = DateTime.Now - cardCreationDate;

            return Convert.ToInt32(Ebbinghaus(delta.TotalMinutes));
        }

        // Подсчитывает баллы за правильные и неправильные ответы.
        private int ManageCorrectAnswersMistakes()
        {
            double res = totalCorrectAnswerCount / ((totalCorrectAnswerCount + totalMistakesCount) * 1.0);

            return Convert.ToInt32(res);
        }

        // Подсчитывет баллы за даты последнего использования
        // и последней ошибки.
        private int ManageLastDates()
        {
            if (lastMistakeDate == null || cardLastUsedDate == null)
            {
                return 0;
            }

            // Знак >= на случай задержки в несколько долей секунд.
            if (lastMistakeDate >= cardLastUsedDate)
            {
                return 0;
            }

            return 1;
        }

        // Подсчитывает баллы за последний данный ответ.
        private int ManageLastAnswer()
        {
            if (lastAnswer == null)
            {
                return 0;
            }
            if (lastAnswer == UserAnswer.Mistake)
            {
                return 0;
            }
            return 10;
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
