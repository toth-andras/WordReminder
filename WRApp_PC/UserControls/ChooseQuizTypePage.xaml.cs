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
    /// Interaction logic for ChooseQuizTypePage.xaml
    /// </summary>
    public partial class ChooseQuizTypePage : UserControl
    {
        public ChooseQuizTypePage()
        {
            InitializeComponent();
        }

        private void RemidQuizButton_Click(object sender, RoutedEventArgs e)
        {
            QuizManager.Initialize();
            QuizManager.ShowNext();
        }
    }
}
