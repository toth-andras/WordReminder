using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.WRLibrary
{
    public delegate void QuizDelegate(object sender, EventArgs e);

    /// <summary>
    /// Интерфейс базового функционала опросов.
    /// </summary>
    public interface IQuiz
    {
        IQuestion[] Questions { get; set; }

        /// <summary>
        /// Запросить следующий вопрос.
        /// </summary>
        /// <returns>Экземпляр IQuestion - вопрос.</returns>
        IQuestion GetNextQuestion();

        /// <summary>
        /// Вызывается, когда в опросе остается один вопрос.
        /// </summary>
        event QuizDelegate OnLastQuestion;
    }
}
