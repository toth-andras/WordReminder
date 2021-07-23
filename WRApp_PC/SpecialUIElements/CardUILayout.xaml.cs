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

namespace WRApp_PC.SpecialUIElements
{
    /// <summary>
    /// Класс для отображения пользователю экземпляра класса WRLibrary.Card.
    /// </summary>
    public partial class CardUILayout : UserControl
    {
        // Отображаемая карточка.
        private Card card;

        /// <summary>
        /// Событие, которое вызывается после удаления.
        /// </summary>
        public event Action AfterDelete;

        public CardUILayout(Card card)
        {
            InitializeComponent();

            if (card is null)
            {
                throw new NullReferenceException("Parameter 'card' was null.") { Source = "CardUILayout.CardUILayout(Card)" };
            }
            this.card = card;

            TermTextBlock.Text = card.Term;
            ValueTextBlock.Text = card.Value;
        }

        // Удаление карточки
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить эту карточку?", "Подтвердите действие", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                WRLibraryManager.CardStorage.RemoveCard(card);
                AfterDelete?.Invoke();
            }
        }

        // Редактирование карточки
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            PageManager.ChangePage(Pages.EditCard, card);
        }
    }
}
