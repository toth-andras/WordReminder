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

using System.IO;

using WRApp_PC.SpecialUIElements;
using WRApp_PC.Add_Cards_From_File;

namespace WRApp_PC.UserControls
{
    /// <summary>
    /// Interaction logic for ChooseIndexesPage.xaml
    /// </summary>
    public partial class ChooseIndexesPage : UserControl
    {
        private ColumnLayoutController controller = new ColumnLayoutController();

        /// <summary>
        /// Вызывается, когда пользователь выбрал индексы.
        /// </summary>
        public event Action<int, int> OnIndexesChosen;

        public ChooseIndexesPage(string filePath)
        {
            InitializeComponent();

            (string[] columnNames, List<List<string>> values) = SeparateToColumns(File.ReadAllLines(filePath));

            for (int i = 0; i < columnNames.Length; i++)
            {
                ColumnUILayout layout = new ColumnUILayout(columnNames[i], values[i].ToArray(), i);
                controller.TakeUnderControl(layout);

                ColumnsStack.Children.Add(layout);
            }
        }

        private Tuple<string[], List<List<string>>> SeparateToColumns(string[] fileText)
        {
            List<List<string>> columns = new List<List<string>>();

            string[] columnNames = (from word in fileText[0].Split(',') where word != "" select word).ToArray();

            for (int i = 0; i < columnNames.Length; i++)
            {
                columns.Add(new List<string>());
            }

            for (int i = 1; i < columnNames.Length; i++)
            {
                string[] values = fileText[i].Split(',');

                for (int j = 0; j < values.Length; j++)
                {
                    columns[j].Add(values[j]);
                }
            }

            return new Tuple<string[], List<List<string>>>(columnNames, columns);
        }
    }
}
