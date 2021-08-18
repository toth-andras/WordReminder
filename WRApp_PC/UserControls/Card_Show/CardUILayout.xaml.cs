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

        /// <summary>
        /// Вызывается при нажатии кнопки редактировать, находящейся на отображении карточки.
        /// </summary>
        public event EventHandler<CardEventArgs> EditButtonPressed;

        /// <summary>
        /// Вызывается при нажатии кнопки удалить, находящейся на отображении карточки.
        /// </summary>
        public event EventHandler<CardEventArgs> RemoveButtonPressed;

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
            RemoveButtonPressed?.Invoke(this, new CardEventArgs(card));
            AfterDelete?.Invoke();
        }

        // Редактирование карточки
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditButtonPressed?.Invoke(this, new CardEventArgs(card));
        }
    }
}
