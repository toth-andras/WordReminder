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

using WRApp_PC.WRLibrary;
using WRApp_PC.SpecialUIElements;

namespace WRApp_PC.UserControls
{
    /// <summary>
    /// Interaction logic for EditCard_Type.xaml
    /// </summary>
    public partial class EditCard_Type : UserControl
    {
        // Карточка для редактирования.
        private Card card;

        /// <summary>
        /// Вызывается по завершении всех действий на странице.
        /// </summary>
        public event Action WorkDone;

        /// <summary>
        /// Вызывается при нажатии кнопки отменить.
        /// </summary>
        public event Action CancelButtonPressed;

        public EditCard_Type(Card card)
        {
            InitializeComponent();

            this.card = card;

            TermTextBox.Text = card.Term;
            ValueTextBox.Text = card.Value;
        }

        // Сообщить пользователю об ошибке.
        private void ViewError(string errorMessage)
        {
            ErrorGrid.Children.Clear();
            ErrorGrid.Children.Add(new ErrorLayout(errorMessage));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                card.Edit(TermTextBox.Text, ValueTextBox.Text);
                WorkDone?.Invoke();
            }
            catch (NullOrEmptyStringException)
            {
                ViewError("Неверный формат");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CancelButtonPressed?.Invoke();
        }
    }
}
