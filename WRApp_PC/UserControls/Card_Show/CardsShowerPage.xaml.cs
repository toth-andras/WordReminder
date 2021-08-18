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
    /// Interaction logic for CardsShowerPage.xaml
    /// </summary>
    public partial class CardsShowerPage : UserControl
    {
        public CardsShowerPage()
        {
            InitializeComponent();

            RefreshContent();
        }
        /// <summary>
        /// Обновить список карточек для отображения.
        /// </summary>
        public void RefreshContent()
        {
            CardsStack.Children.Clear();
            Card[] cardsToShow = WRLibraryManager.CardStorage.GetAllCards();
            if (cardsToShow.Length == 0)
            {
                PageNameLabel.Text = "Вы пока не добавили ни одной карточки.";
            }
            else
            {
                PageNameLabel.Text = $"Ваши карточки ({cardsToShow.Length}):";

                foreach (Card card in cardsToShow)
                {
                    CardUILayout layout = new CardUILayout(card);
                    // Подписка на событие для корректного обновления
                    // отображаемого списка.
                    layout.AfterDelete += RefreshContent;

                    layout.EditButtonPressed += (sender, e) => PageManager.ChangePage(Pages.AddEditCard, e.Card);
                    layout.RemoveButtonPressed += (sender, e) =>
                    {
                        if (MessageBox.Show("Удалить карточку?", "Подтвердите действие", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            WRLibraryManager.CardStorage.RemoveCard(e.Card);
                        }
                    };

                    CardsStack.Children.Add(layout);
                }
            }
        }
    }
}
