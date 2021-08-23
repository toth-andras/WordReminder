using System;
using System.Windows.Controls;

using WRApp_PC.WRLibrary;
using WRApp_PC.UserControls;

namespace WRApp_PC.Core
{
    public enum Pages
    {
        Main, CardsShower,
        AddEditCard, ChooseQuizType,
        QuizPage
    }

    /// <summary>
    /// Осуществляет контроль над страницами главной части приложения.
    /// </summary>
    static class PageManager
    {
        static MainPage mainPage;
        static ChooseQuizTypePage chooseQuizTypePage;

        static Grid grid;

        public static void Initialize(Grid gridToManage)
        {
            if (gridToManage == null)
            {
                throw new NullReferenceException("Parameter 'grid' was null") { Source = "PageManager.Initialize(Grid)" };
            }
            grid = gridToManage;

            mainPage = new MainPage();
            chooseQuizTypePage = new ChooseQuizTypePage();
        }

        private static void OpenMainPage()
        {
            ChangePage(Pages.Main);
        }

        public static void ChangePage(Pages page, object valueToPass = null)
        {
            grid.Children.Clear();

            switch (page)
            {
                case Pages.Main:
                    grid.Children.Add(mainPage);
                    break;

                case Pages.CardsShower:
                    grid.Children.Add(new CardsShowerPage());
                    break;

                case Pages.AddEditCard:
                    AddEditCard_Page newPage;

                    // Если передано значение, значит, это значение -
                    // карточка для редактирования.
                    if (valueToPass != null)
                    {
                        Card card = valueToPass as Card;
                        if (card == null)
                        {
                            throw new ArgumentException("Parameter 'valueToPass' was not Card.") { Source = "PageManager.ChangePage(Pages, object)" };
                        }
                        newPage = new AddEditCard_Page(card);
                    }
                    else
                    {
                        newPage = new AddEditCard_Page();
                    }

                    newPage.OnFinished += OpenMainPage;
                    newPage.OnCancelButtonPressed += OpenMainPage;

                    grid.Children.Add(newPage);
                    break;

                case Pages.ChooseQuizType:
                    grid.Children.Clear();
                    grid.Children.Add(chooseQuizTypePage);
                    break;

                case Pages.QuizPage:
                    QuizPage quizPage = new QuizPage();
                    quizPage.OnFinished += OpenMainPage;

                    grid.Children.Add(quizPage);
                    break;

                default:
                    break;
            }
        }
    }
}
