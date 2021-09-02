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

        public ColumnUILayout(Column column)
        {
            InitializeComponent();

            ColumnNameLabel.Text = column.ColumnName;
            ColumnIndex = column.Index;
            IsSelected = false;

            foreach (string value in column.Values)
            {
                Label label = new Label() { Content = value,
                    Foreground = Brushes.White,
                    FontSize = 15,
                    BorderBrush = Brushes.White,
                    BorderThickness = new Thickness(2)
                };

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
            ColumnNameLabel.Foreground = Brushes.DarkGray;

            foreach (Label label in ColumnValuesStack.Children)
            {
                label.Background = Brushes.Gray;
            }
        }

        public void MarkAsUnchecked()
        {
            IsSelected = false;
            ColumnNameLabel.Foreground = Brushes.White;

            foreach (Label label in ColumnValuesStack.Children)
            {
                label.Background = Brushes.Transparent;
            }
        }

        private void ColumnNameLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsSelected = !IsSelected;
            OnClicked?.Invoke(this);
        }
    }
}
