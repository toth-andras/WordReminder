using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using WRApp_PC.WRLibrary;
using WRApp_PC.UserControls;

namespace WRApp_PC.Core
{
    public enum Pages { Main, CardsShower, AddCard, EditCard}

    /// <summary>
    /// Осуществляет контроль над страницами главной части приложения.
    /// </summary>
    static class PageManager
    {
        static MainPage mainPage;
        static CardsShowerPage cardsShowerPage;
        static AddEditCardPage addEditCardPage;

        static Grid grid;

        public static void Initialize(Grid gridToManage)
        {
            if (gridToManage == null)
            {
                throw new NullReferenceException("Parameter 'grid' was null") { Source = "PageManager.Initialize(Grid)" };
            }
            grid = gridToManage;

            mainPage = new MainPage();
            cardsShowerPage = new CardsShowerPage();
            addEditCardPage = new AddEditCardPage();
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
                    cardsShowerPage.RefreshContent();
                    grid.Children.Add(cardsShowerPage);
                    break;

                case Pages.AddCard:
                    addEditCardPage = new AddEditCardPage();
                    grid.Children.Add(addEditCardPage);
                    break;

                case Pages.EditCard:
                    if (valueToPass == null)
                    {
                        throw new NullReferenceException("Parameter 'valueToPass' was null.") { Source="PageManager.ChangePage(Pages, object)"};
                    }
                    if (!(valueToPass is Card))
                    {
                        throw new ArgumentException("Parameter 'valueToPass' was not Card.") { Source = "PageManager.ChangePage(Pages, object)" };
                    }
                    addEditCardPage = new AddEditCardPage((Card)valueToPass);
                    grid.Children.Add(addEditCardPage);
                    break;

                default:
                    break;
            }
        }
    }
}
