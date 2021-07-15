using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary
{
    // В этом файле описаны члены класса, необходимые для подсчета рейтинга карточек.
    public partial class Card
    {
        #region Fields and properties
        // Сколько раз при использовании карточки были допущены ошибки.
        private int totalMistakesCount;

        // Сколько раз при использовании карточки был дан верный ответ.
        private int totalCorrectAnswerCount;

        /// <summary>
        /// Дата создания карточки.
        /// </summary>
        public DateTime CreationDate { get; private set; }

        // Дата последнего раза, когда при использовании карточки была допущена ошибка.
        private DateTime? lastMistakeDate;

        // Дата последнего использования карточки.
        private DateTime? lastUsedDate;

        // Каким был последний ответ при использовании карточки.
        private UserAnswer? lastAnswer;

        /// <summary>
        /// Рейтинг карточки.
        /// </summary>
        public int Rating => CountRating();
        #endregion

        #region Methods and functions
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
        private static double Ebbinghaus(double minutesPassed)
        {
            // Данные для формулы кривой Эббингауза
            const double k = 1.84;
            const double c = 1.25;

            return 100 * k / (Math.Pow(Math.Log(minutesPassed), c) + k);
        }

        // Подсчитывает баллы за дату создания карточки.
        private int ManageCreationDate()
        {
            var delta = DateTime.Now - CreationDate;
            double ebbinghausValue = Ebbinghaus(delta.TotalMinutes);

            try
            {
                return Convert.ToInt32(ebbinghausValue);
            }
            catch (OverflowException)
            {
                return 100;
            }
        }

        // Подсчитывает баллы за правильные и неправильные ответы.
        private int ManageCorrectAnswersMistakes()
        {
            if (totalCorrectAnswerCount + totalMistakesCount == 0)
            {
                return 0;
            }
            double res = totalCorrectAnswerCount / ((totalCorrectAnswerCount + totalMistakesCount) * 1.0);

            return Convert.ToInt32(res * 100);
        }

        // Подсчитывет баллы за даты последнего использования
        // и последней ошибки.
        private int ManageLastDates()
        {
            if (lastMistakeDate == null || lastUsedDate == null)
            {
                return 0;
            }

            // Знак >= на случай задержки в несколько долей секунд.
            if (lastMistakeDate >= lastUsedDate)
            {
                return 0;
            }

            double res = (lastUsedDate - lastMistakeDate).Value.TotalDays * 1.0 / 365;
            return Convert.ToInt32(res);
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
            return 100;
        }

        /// <summary>
        /// Отрабатывает поведение карточки, когда при ее использовании был дан правильный ответ.
        /// </summary>
        public void OnCorrectAnswer()
        {
            totalCorrectAnswerCount++;
            lastAnswer = UserAnswer.CorrectAnswer;
            lastUsedDate = DateTime.Now;
        }

        /// <summary>
        /// Отрабатывает поведение карточки, когда при ее использовании был дан неправильный ответ.
        /// </summary>
        public void OnMistake()
        {
            totalMistakesCount++;
            lastAnswer = UserAnswer.Mistake;
            lastMistakeDate = DateTime.Now;
            lastUsedDate = DateTime.Now;
        }
        #endregion
    }
}
