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
using WRApp_PC.SpecialUIElements;

namespace WRApp_PC.UserControls
{
    internal enum Mode { Add, Edit};

    /// <summary>
    /// Interaction logic for AddEditCardPage.xaml
    /// </summary>
    public partial class AddEditCardPage : UserControl
    {
        // Переменная, отвечающая за режим работы страницы: создание
        // карточки или ее редактирование.
        Mode workMode;

        // Карточка для редактирования (если есть).
        Card card;

        /// <summary>
        /// Конструктор для открытия формы для добавления карточки.
        /// </summary>
        public AddEditCardPage()
        {
            InitializeComponent();
            workMode = Mode.Add;
            PageNameLabel.Content = "Добавить карточку";
            AddEditButtonText.Text = "Добавить";
        }

        /// <summary>
        /// Конструктор для открытия формы редактирования карточки.
        /// </summary>
        /// <param name="card">Карточка для редактирования.</param>
        public AddEditCardPage(Card card)
        {
            InitializeComponent();

            if (card is null)
            {
                throw new NullReferenceException("Parameter 'card' was null.") { Source = "AddEditCardPage.AddEditCardPage(Card)" };
            }
            this.card = card;
            workMode = Mode.Edit;

            PageNameLabel.Content = "Редактировать карточку";
            AddEditButtonText.Text = "Изменить";

            TermTextBox.Text = card.Term;
            ValueTextBox.Text = card.Value;
        }

        // Создаем новую карточку
        private void AddEditCardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Если создается новая карточка.
                if (workMode == Mode.Add)
                {
                    Card card = new Card(TermTextBox.Text, ValueTextBox.Text);
                    WRLibraryManager.CardStorage.AddCard(card);
                }
                // Если редактируется старая карточка.
                else
                {
                    Card newCard = (Card)card.Clone();
                    newCard.Edit(TermTextBox.Text, ValueTextBox.Text);

                    WRLibraryManager.CardStorage.RemoveCard(card);
                    WRLibraryManager.CardStorage.AddCard(newCard);
                }

                if (workMode == Mode.Edit)
                {
                    PageManager.ChangePage(Pages.CardsShower);
                }
                else
                {
                    PageManager.ChangePage(Pages.Main);
                }
            }
            // Ошибка: передана пустая строчка или null.
            catch (NullOrEmptyStringException)
            {
                ErrorPlace.Children.Clear();
                ErrorPlace.Children.Add(new ErrorLayout("Неверный формат"));
            }
            // Ошибка: такая карточка уже была создана.
            catch (CardAlreadyExistsException)
            {
                ErrorPlace.Children.Clear();
                ErrorPlace.Children.Add(new ErrorLayout("Такая карточка уже есть"));
            }
        }

        // Отмена
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (workMode == Mode.Edit)
            {
                PageManager.ChangePage(Pages.CardsShower);
            }
            else
            {
                PageManager.ChangePage(Pages.Main);
            }
        }
    }
}
