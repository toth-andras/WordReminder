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
using WRApp_PC.WRLibrary;

namespace WRApp_PC.UserControls.QuestionShowers
{
    /// <summary>
    /// Interaction logic for TextInputQuestionShower.xaml
    /// </summary>
    public partial class TextInputQuestionShower : UserControl, IQuestionShower
    {
        // Величина шрифта текста вопроса.
        private const int questionFontSize = 40;

        public IQuestion Question { get; set; }

        public event Action OnCorrectAnswer;
        public event Action OnMistake;

        public TextInputQuestionShower()
        {
            InitializeComponent();
        }

        public TextInputQuestionShower(IQuestion question) 
        {
            InitializeComponent();

            if (question is null)
            {
                throw new NullReferenceException("Parameter 'question' was null.") { Source= "TextInputQuestionShower.TextInputQuestionShower(IQuestion)" };
            }
            if (!(question is AskForValueQuestion))
            {
                throw new ArgumentException("'question' must be AskForValueQuestion.") { Source = "TextInputQuestionShower.TextInputQuestionShower(IQuestion)" };
            }

            Question = question;
            List<string> strings = GetDividedText(Question.TextDescription);

            foreach (string str in strings)
            {
                QuestionText.Children.Add(new TextBlock() { Text = str, FontSize = questionFontSize, Foreground = Brushes.White, Margin = new Thickness(0, 10, 0, 0) });
            }
        }

        // Разбивает текст на строчки (чтобы избежать выход текста за пределы экрана).
        private List<string> GetDividedText(string text)
        {
            // -5 на следующей строчке - 'запас'.
            int charsPerString = 700 / (questionFontSize / 2) - 5;
            string currentString = "";
            string[] words = text.Split();
            words = (from word in words where word != "" select word).ToArray();

            List<string> resultStrings = new List<string>();

            currentString += words[0];
            for (int i = 1; i < words.Length-1; i++)
            {
                if ( (currentString + words[i]).Length <= charsPerString)
                {
                    currentString += " " + words[i];
                }
                else
                {
                    resultStrings.Add(currentString);
                    currentString = words[i];
                }

                if (i == words.Length - 2)
                {
                    resultStrings.Add(currentString);
                }
            }

            if ( (words.Last() + resultStrings.Last()).Length <= charsPerString)
            {
                resultStrings[resultStrings.Count - 1] += " " + words.Last();
            }
            else
            {
                resultStrings.Add(words.Last());
            }

            return resultStrings;
        }

        public UserAnswer CheckAnswer()
        {
            return Question.CheckAnswer(UserAnswerTextBox.Text);
        }

        private void DoCheck()
        {
            if (CheckAnswer() == UserAnswer.CorrectAnswer)
            {
                OnCorrectAnswer?.Invoke();
            }
            else
            {
                OnMistake?.Invoke();
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            DoCheck();
        }

        private void UserAnswerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DoCheck();
            }
        }
    }
}
