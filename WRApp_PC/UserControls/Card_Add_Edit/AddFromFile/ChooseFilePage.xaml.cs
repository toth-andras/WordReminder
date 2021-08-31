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

namespace WRApp_PC.UserControls
{
    /// <summary>
    /// Interaction logic for ChooseFileTypePage.xaml
    /// </summary>
    public partial class ChooseFileTypePage : UserControl
    {
        /// <summary>
        /// Вызывается после выбора пользователем файла.
        /// </summary>
        public event Action<string> FileChosen;

        public ChooseFileTypePage()
        {
            InitializeComponent();
        }

        // Открыть диалог для выбора файла.
        private void ShowDialog(IFileFilter filter)
        {
            using (System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog())
            {
                dialog.Filter = filter.GetFilter();

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = dialog.FileName;
                    FileChosen?.Invoke(path);
                }
            }
        }

        private void CsvFileButton_Click(object sender, RoutedEventArgs e)
        {
            ShowDialog(new CSVFileFilter());
        }
    }
}
