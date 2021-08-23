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

namespace WRApp_PC.UserControls
{
    /// <summary>
    /// Interaction logic for CorrectAnswerPage.xaml
    /// </summary>
    public partial class CorrectAnswerPage : UserControl
    {
        /// <summary>
        /// Вызывается при нажатии пользователем кнопки продолжить.
        /// </summary>
        public event Action ContinueButtonPressed;

        public CorrectAnswerPage()
        {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ContinueButtonPressed?.Invoke();
        }
    }
}
