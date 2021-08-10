using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WRApp_PC.Core;
using WRApp_PC.WRLibrary;

namespace WRApp_PC.Core
{
    /// <summary>
    /// Класс для обеспечния доступа к опросу.
    /// </summary>
    static class QuizManager
    {
        static IQuiz quiz;
        static bool isLastQuestion;
        static bool lastQuestionOver;

        static void LastQuestion(object sender, EventArgs e)
        {
            isLastQuestion = true;
        }

        public static void Initialize()
        {
            isLastQuestion = false;
            lastQuestionOver = false;
            quiz = new RemindQuiz(WRLibraryManager.CardStorage.GetCardsForQuiz(), new AskForValueQuizCreator());
            quiz.OnLastQuestion += LastQuestion;
        }

        /// <summary>
        /// Выполнить отображение следующего вопроса. Если его нет, то закончить показ вопросов.
        /// Перед выполнением этого метода должен быть вызван метод Initialize().
        /// </summary>
        public static void Continue()
        {
            if (lastQuestionOver)
            {
                PageManager.ChangePage(Pages.EndQuizPage);
                return;
            }
            IQuestion question = quiz.GetNextQuestion();
            PageManager.ChangePage(Pages.QuestionShower, question);
            if (isLastQuestion)
            {
                lastQuestionOver = true;
            }
        }
    }
}
