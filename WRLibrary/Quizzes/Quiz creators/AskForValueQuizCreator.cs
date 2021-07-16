using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary.Quizzes.Quiz_creators
{
    /// <summary>
    /// Составляет опрос исключительно из вопросов,
    /// ответом на которые является определение к термину.
    /// </summary>
    class AskForValueQuizCreator : IQuizCreator
    {
        public IQuestion[] CreateQuestions(Card[] cards)
        {
            List<IQuestion> questions = new List<IQuestion>();
            foreach (Card card in cards)
            {
                questions.Add(new AskForValueQuestion(card));
            }

            return questions.ToArray();
        }
    }
}
