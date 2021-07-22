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
    /// Interaction logic for AddCardPage.xaml
    /// </summary>
    public partial class AddCardPage : UserControl
    {
        public AddCardPage()
        {
            InitializeComponent();
        }

        // Создаем новую карточку
        private void CreateCardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Card card = new Card(TermTextBox.Text, ValueTextBox.Text);
                WRLibraryManager.CardStorage.AddCard(card);

                ClearFields();
                PageManager.ChangePage(Pages.Main);
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
            ClearFields();
            PageManager.ChangePage(Pages.Main);
        }

        // Очистить страницу для следующего открытия.
        private void ClearFields()
        {
            TermTextBox.Text = "";
            ValueTextBox.Text = "";
            ErrorPlace.Children.Clear();
        }
    }
}
