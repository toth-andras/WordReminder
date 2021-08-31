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

using WRApp_PC.Add_Cards_From_File;

namespace WRApp_PC.SpecialUIElements
{
    /// <summary>
    /// Interaction logic for ColumnUILayout.xaml
    /// </summary>
    public partial class ColumnUILayout : UserControl, IColumnLayout
    {
        public int ColumnIndex { get; private set; }

        public bool IsSelected { get; private set; }

        public event Action<IColumnLayout> OnClicked;

        public ColumnUILayout(string columnName, string[] columnValues, int columnIndex)
        {
            InitializeComponent();

            ColumnNameLabel.Text = columnName;
            ColumnIndex = columnIndex;
            IsSelected = false;

            foreach (string value in columnValues)
            {
                Label label = new Label() { Content = value };
                label.MouseLeftButtonDown += (sender, e) =>
                {
                    IsSelected = !IsSelected;
                    OnClicked?.Invoke(this);
                };

                ColumnValuesStack.Children.Add(label);
            }
        }

        public void MarkAsChecked()
        {
            IsSelected = true;
            ColumnNameCheckBox.IsChecked = true;

            foreach (Label label in ColumnValuesStack.Children)
            {
                label.Foreground = Brushes.Gray;
            }
        }

        public void MarkAsUnchecked()
        {
            IsSelected = false;
            ColumnNameCheckBox.IsChecked = false;

            foreach (Label label in ColumnValuesStack.Children)
            {
                label.Foreground = Brushes.White;
            }
        }

        private void ColumnNameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            IsSelected = !IsSelected;
            OnClicked?.Invoke(this);
        }
    }
}
