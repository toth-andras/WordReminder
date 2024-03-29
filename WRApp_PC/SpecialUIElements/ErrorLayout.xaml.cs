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

namespace WRApp_PC.SpecialUIElements
{
    /// <summary>
    /// Interaction logic for ErrorLayout.xaml
    /// </summary>
    public partial class ErrorLayout : UserControl
    {
        public ErrorLayout(string errorText = "Ошибка!")
        {
            InitializeComponent();
            if (errorText == null)
            {
                throw new NullReferenceException("Parameter 'errorText' was null.") { Source = "ErrorLayout.ErrorLayout(string)" };
            }

            ErrorTextField.Text = errorText;
        }
    }
}
