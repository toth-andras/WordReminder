using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WRApp_PC.Core;
using WRApp_PC.WRLibrary;

namespace WRApp_PC.UserControls
{
    /// <summary>
    /// Interaction logic for QuizPage.xaml
    /// </summary>
    public partial class QuizPage : UserControl
    {
        private bool quizIsOver;

        // Отображаемый опрос.
        private IQuiz quiz;

        /// <summary>
        /// Вызываетя, когда завершается один из сценариев работы страницы.
        /// </summary>
        public event Action OnFinished;

        public QuizPage()
        {
            InitializeComponent();

            quizIsOver = false;

            // TODO: make this adaptable for user's choice.
            quiz = new RemindQuiz(WRLibraryManager.CardStorage.GetCardsForQuiz(), new AskForValueQuizCreator());
            quiz.OnLastQuestion += (sender, e) => quizIsOver = true;

            ShowNextQuestion();
        }

        // Установить страницу.
        private void SetPage(UserControl page)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(page);
        }

        // Отобразить вопрос из опроса.
        private void ViewQuestion(IQuestion question)
        {
            if (question is AskForValueQuestion)
            {
                TextInputQuestionShower shower = new TextInputQuestionShower(question);
                shower.OnCorrectAnswer += () =>
                {
                    CorrectAnswerPage page = new CorrectAnswerPage();
                    page.ContinueButtonPressed += () => ShowNextQuestion();

                    SetPage(page);
                };
                shower.OnMistake += () =>
                {
                    MistakeAnswerPage page = new MistakeAnswerPage();
                    page.ContinueButtonPressed += () => ShowNextQuestion();

                    SetPage(page);
                };

                SetPage(shower);
            }
        }

        // Переключить на страницу окончания опроса.
        private void ShowEndQuizPage()
        {
            QuizOverPage page = new QuizOverPage();
            page.OnToMainPageButtonPressed += () => OnFinished?.Invoke();

            SetPage(page);
        }

        private void ShowNextQuestion()
        {
            if (quizIsOver)
            {
                ShowEndQuizPage();
            }
            else
            {
                ViewQuestion(quiz.GetNextQuestion());
            }
        }
    }
}
