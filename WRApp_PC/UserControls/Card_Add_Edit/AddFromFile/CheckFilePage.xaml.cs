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

using WRApp_PC.SpecialUIElements;
using WRApp_PC.Add_Cards_From_File;

namespace WRApp_PC.UserControls
{
    /// <summary>
    /// Interaction logic for CheckFilePage.xaml
    /// </summary>
    public partial class CheckFilePage : UserControl
    {
        // Путь к прверяемому файлу.
        private readonly string filePath;

        IFileChecker checker;

        /// <summary>
        /// Вызывается, если при проверке файла не было обнаружено ошибок.
        /// </summary>
        public event Action<string> OnFileIsOk;

        /// <summary>
        /// Вызывается при особой ошибке, для обработки которой необходимы дополнительные действия.
        /// </summary>
        public event SpecialErrorDelegate OnSpecialError;

        /// <summary>
        /// Вызывается, когда пользователь нажал на кнопку "Выбрать другой файл";
        /// </summary>
        public event Action OnRetry;


        public void ShowError(string errorText)
        {
            ErrorStack.Children.Clear();
            ErrorStack.Children.Add(new ErrorLayout(errorText));
        }

        public CheckFilePage(string filePath, IFileChecker fileChecker)
        {
            InitializeComponent();

            this.filePath = filePath;
            checker = fileChecker;

            checker.OnFileIsOk += (string path) => OnFileIsOk?.Invoke(filePath);
            checker.OnBasicError += (errorText) => ShowError(errorText);
            checker.OnSpecialError += (SpecialErrors error, string filePath, string errorText) => 
            {
                ShowError(errorText);
                OnSpecialError?.Invoke(error, filePath, errorText);
            };
        }

        public void Check()
        {
            checker.Check(filePath);
        }

        private void ChooseAnotherFileButton_Click(object sender, RoutedEventArgs e)
        {
            OnRetry?.Invoke();
        }
    }
}