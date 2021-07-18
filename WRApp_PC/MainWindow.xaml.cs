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

namespace WRApp_PC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PageManager.Initialize(MainGrid);
            PageManager.ChangePage(Pages.Main);
        }

        private void MainPageMenuButton_Click(object sender, RoutedEventArgs e)
        {
            PageManager.ChangePage(Pages.Main);
        }

        private void MyCardsMenuButton_Click(object sender, RoutedEventArgs e)
        {
            PageManager.ChangePage(Pages.CardsShower);
        }


    }
}
