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

            List<Column> columns = SeparateToColumns(File.ReadAllLines(filePath));

            for (int i = 0; i < columns.Count; i++)
            {
                ColumnUILayout layout = new ColumnUILayout(columns[i]);
                controller.TakeUnderControl(layout);

                ColumnsStack.Children.Add(layout);
            }
        }

        // Разбитие файла на столбцы.
        private List<Column> SeparateToColumns(string[] fileText)
        {
            List<Column> columns = new List<Column>();

            // Индексы столбцов, у которых есть имя или хотя бы 1 значение.
            List<int> goodIndexes = ChooseGoodIndexes(fileText);

            // Заполнить список столбцов пустыми объектами.
            for (int i = 0; i < goodIndexes.Count; i++)
            {
                columns.Add(new Column());
            }

            // Указать имена столбцов.
            string[] columnNames = fileText[0].Split(',');
            for (int i = 0; i < goodIndexes.Count; i++)
            {
                columns[i].ColumnName = columnNames[goodIndexes[i]];
            }

            // Указать значения столбцов и их индексы в файле.
            for (int i = 1; i < fileText.Length; i++)
            {
                string[] currentValues = fileText[i].Split(',');

                for (int j = 0; j < goodIndexes.Count; j++)
                {
                    columns[j].AddValue(currentValues[goodIndexes[j]]);
                    columns[j].Index = goodIndexes[j];
                }
            }

            return columns;
        }

        // Выбирает индексы столбцов, у которых есть имя или хотя бы одно значение.
        private List<int> ChooseGoodIndexes(string[] fileText)
        {
            List<int> goodIndexes = new List<int>();

            string[] columnNames = fileText[0].Split(',');

            for (int i = 0; i < columnNames.Length; i++)
            {
                if (columnNames[i] != "")
                {
                    goodIndexes.Add(i);
                }
                else
                {
                    if (ColumnHasValues(fileText, i))
                    {
                        goodIndexes.Add(i);
                    }
                }
            }

            return goodIndexes;
        }

        // Проверяет, есть ли у столбца с заданным индексом значения.
        private bool ColumnHasValues(string[] fileText, int index)
        {
            // С единицы, так как 0-й индекс - названия столбцов. 
            for (int i = 1; i < fileText.Length; i++)
            {
                if (fileText[i].Split(',')[index] != "")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
