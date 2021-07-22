using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WRApp_PC.UserControls;

namespace WRApp_PC.Core
{
    public enum Pages { Main, CardsShower, AddCard}

    /// <summary>
    /// Осуществляет контроль над страницами главной части приложения.
    /// </summary>
    static class PageManager
    {
        static MainPage mainPage;
        static CardsShowerPage cardsShowerPage;
        static AddCardPage addCardPage;

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
            addCardPage = new AddCardPage();
        }

        public static void ChangePage(Pages page)
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
                    grid.Children.Add(addCardPage);
                    break;

                default:
                    break;
            }
        }
    }
}
