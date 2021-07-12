using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary
{
    public delegate void QuestionDelegate(object sender, EventArgs e);
    
    /// <summary>
    /// Базовый класс для представления вопроса - часть опроса.
    /// </summary>
    abstract class Question
    {
        public Card Card { get; protected set; }

        /// <summary>
        /// Проверить ответ пользователя.
        /// </summary>
        /// <param name="userChoice">Ответ пользователя в какой-либо форме.</param>
        /// <returns></returns>
        public abstract UserAnswer CheckAnswer(object userChoice);

        /// <summary>
        /// Вызывается при правильном ответе на вопрос.
        /// </summary>
        public event QuestionDelegate OnCorrectAnswer;

        /// <summary>
        /// Вызывается при неправильном ответе на вопрос.
        /// </summary>
        public event QuestionDelegate OnMistake;
    }
}
