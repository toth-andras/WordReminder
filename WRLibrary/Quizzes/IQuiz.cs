using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary
{
    public delegate void QuizDelegate(object sender, EventArgs e);

    /// <summary>
    /// Интерфейс базового функционала опросов.
    /// </summary>
    interface IQuiz
    {
        IQuestion[] Questions { get; set; }

        /// <summary>
        /// Запросить следующий вопрос.
        /// </summary>
        /// <returns>Экземпляр IQuestion - вопрос.</returns>
        IQuestion GetNextQuestion();

        /// <summary>
        /// Вызывается по окончании опроса.
        /// </summary>
        event QuizDelegate OnQuizOver;
    }
}
