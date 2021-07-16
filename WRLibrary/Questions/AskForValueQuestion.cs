using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary
{
    /// <summary>
    /// Вопрос, ответом на который является определение к термину.
    /// </summary>
    public class AskForValueQuestion : IQuestion
    {
        public Card Card { get; set; }

        public string TextDescription => ToString();

        public event QuestionDelegate OnCorrectAnswer;
        public event QuestionDelegate OnMistake;

        public AskForValueQuestion(Card card)
        {
            if (card == null)
            {
                throw new NullReferenceException("Parameter 'card' was null") { Source = "AskForValueQuestion.AskForValueQuestion(Card)" };
            }
            Card = card;
        }

        /// <summary>
        /// Проверить ответ пользователя.
        /// </summary>
        /// <param name="userChoice">Ответ пользователя (string).</param>
        /// <returns>Один из вариантов результата проверки.</returns>
        public UserAnswer CheckAnswer(object userChoice)
        {
            if (userChoice == null)
            {
                throw new NullReferenceException("Parameter 'userChoice' was null.");
            }

            string answer = userChoice as string;
            if (answer == null)
            {
                throw new UserAnswerOnQuestionException("Can't convert userChoice to string.");
            }

            answer = answer.Trim().ToLower();

            if (answer == Card.Value.ToLower())
            {
                Card.OnCorrectAnswer();
                OnCorrectAnswer?.Invoke(this, new EventArgs());

                return UserAnswer.CorrectAnswer;
            }

            Card.OnMistake();
            OnMistake?.Invoke(this, new EventArgs());

            return UserAnswer.Mistake;
        }

        public override string ToString()
        {
            return $"Укажите определение для термина {Card?.Term ?? throw new NullReferenceException("Card term was null.")}: ";
        }
    }
}
