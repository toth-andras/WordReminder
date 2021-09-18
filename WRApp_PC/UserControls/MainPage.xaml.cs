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

namespace WRApp_PC.UserControls
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddCardButton_Click(object sender, RoutedEventArgs e)
        {
            PageManager.ChangePage(Pages.AddEditCard);
        }

        private void DoQuizButton_Click(object sender, RoutedEventArgs e)
        {
            PageManager.ChangePage(Pages.ChooseQuizType);
        }

        private void ButtonMouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.Height *= 1.2;
                button.Width *= 1.2;
            }
        }

        private void ButtonMouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.Height /= 1.2;
                button.Width /= 1.2;
            }
        }
    }
}
