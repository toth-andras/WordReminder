using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary
{
    /// <summary>
    /// Общий интерфейс для классов, которые будут
    /// составлять списки вопросов в опросах. Это необходимо для того,
    /// чтобы можно было формировать группы вопросов из разных типов вопросов.
    /// </summary>
    interface IQuizCreator
    {
        /// <summary>
        /// Создать из карточек серию вопросов.
        /// </summary>
        /// <param name="cards">Карточки.</param>
        IQuestion[] CreateQuestions(Card[] cards);
    }
}
