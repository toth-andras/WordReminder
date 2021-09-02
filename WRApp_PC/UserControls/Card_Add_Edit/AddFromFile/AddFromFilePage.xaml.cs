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

using WRApp_PC.UserControls;
using WRApp_PC.Add_Cards_From_File;

namespace WRApp_PC.UserControls
{
    /// <summary>
    /// Interaction logic for AddFromFilePage.xaml
    /// </summary>
    public partial class AddFromFilePage : UserControl
    {
        public Action OnFinished;


        public AddFromFilePage()
        {
            InitializeComponent();

            ChooseFileTypePage page = new ChooseFileTypePage();
            page.FileChosen += (path) => CheckFilePage(path);

            SetMainGrid(page);
        }

        // Обработка особых ошибок.
        private void ManageSpecialError(SpecialErrors error, string filePath)
        {
            switch (error)
            {
                case SpecialErrors.TooManyColumnsInFile:
                    ChooseIndexesPage(filePath);
                    break;
                default:
                    break;
            }
        }

        // Открыть страницу для проверки файла.
        private void CheckFilePage(string filePath)
        {
            CheckFilePage page = new CheckFilePage(filePath, new CSVFileChecker());
            page.OnFileIsOk += (filePath) => { };
            page.OnSpecialError += (SpecialErrors error, string filePath, string errorText) => ManageSpecialError(error, filePath);

            SetMainGrid(page);

            page.Check();
        }
        
        // Открыть страницу для выбора индексов, из которыз будут созданы карточки.
        private void ChooseIndexesPage(string filePath)
        {
            ChooseIndexesPage page = new ChooseIndexesPage(filePath);
            page.OnIndexesChosen += (Column c1, Column c2) => 
            {
                
            };
            SetMainGrid(page);
        }

        private void SetMainGrid(UIElement page)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(page);
        }
    }
}
