using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary
{
    /// <summary>
    /// Опрос, цель которого - повторить слова.
    /// </summary>
    class RemindQuiz : IQuiz
    {
        // Индекс следующего вопроса опроса.
        private int nextQuestionIndex;
        public IQuestion[] Questions { get; set; }


        public event QuizDelegate OnLastQuestion;

        public RemindQuiz(Card[] cards, IQuizCreator quizCreator)
        {
            if (cards == null)
            {
                throw new NullReferenceException("Parameter 'cards' was null.") { Source = "RemindQuiz.RemindQuiz(Card[], IQuizCreator)" };
            }
            if (quizCreator == null)
            {
                throw new NullReferenceException("Parameter 'quizCreator' was null.") { Source = "RemindQuiz.RemindQuiz(Card[], IQuizCreator)" };

            }
            nextQuestionIndex = 0;

            Questions = quizCreator.CreateQuestions(cards);
            MixQuestions();
        }

        // Перемешать вопросы опроса.
        private void MixQuestions()
        {
            Random rnd = new Random();

            for (int i = 0; i < Questions.Length; i++)
            {
                SwapQuestions(ref Questions[i], ref Questions[rnd.Next(Questions.Length)]);
            }
        }
        //Поменять местами два вопроса.
        private static void SwapQuestions(ref IQuestion question1, ref IQuestion question2)
        {
            IQuestion tmp = question2;
            question2 = question1;
            question1 = tmp;
        }

        public IQuestion GetNextQuestion()
        {
            if (nextQuestionIndex == Questions.Length - 1)
            {
                OnLastQuestion?.Invoke(this, new EventArgs());
            }
            IQuestion question = Questions[nextQuestionIndex];
            nextQuestionIndex++;
            return question;
        }
    }
}
