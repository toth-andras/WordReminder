﻿using System;
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

using WRApp_PC.SpecialUIElements;

namespace WRApp_PC.UserControls
{
    /// <summary>
    /// Interaction logic for CardsShowerPage.xaml
    /// </summary>
    public partial class CardsShowerPage : UserControl
    {
        public CardsShowerPage()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                CardsStack.Children.Add(new CardUILayout());
            }
        }
    }
}
