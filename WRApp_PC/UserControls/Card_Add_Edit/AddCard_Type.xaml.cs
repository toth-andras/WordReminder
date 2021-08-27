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
    /// <summary>
    /// Interaction logic for AddCard_Type.xaml
    /// </summary>
    public partial class AddCard_Type : UserControl
    {
        /// <summary>
        /// Вызывается по завершении всех действий на странице.
        /// </summary>
        public event Action WorkDone;

        /// <summary>
        /// Вызывается при нажатии кнопки отменить.
        /// </summary>
        public event Action CancelButtonPressed;

        /// <summary>
        /// Вызывается при нажатии кнопки добавить из файла.
        /// </summary>
        public event Action AddFromFileButtonPressed;

        public AddCard_Type()
        {
            InitializeComponent();
        }

        // Сообщить пользователю об ошибке.
        private void ViewError(string errorMessage)
        {
            ErrorGrid.Children.Clear();
            ErrorGrid.Children.Add(new ErrorLayout(errorMessage));
        }

        private void AddCardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Card card = new Card(TermTextBox.Text, ValueTextBox.Text);

                WRLibraryManager.CardStorage.AddCard(card);
                WorkDone?.Invoke();
            }
            catch (NullOrEmptyStringException)
            {
                ViewError("Неверный формат");
            }
            catch (CardAlreadyExistsException)
            {
                ViewError("Такая карточка уже существует");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CancelButtonPressed?.Invoke();
        }

        private void AddFromFileButton_Click(object sender, RoutedEventArgs e)
        {
            AddFromFileButtonPressed?.Invoke();
        }
    }
}
