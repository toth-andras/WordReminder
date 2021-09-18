using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.UserSettings
{
    /// <summary>
    /// Модель для хранения пользовательских настроек в файле.
    /// </summary>
    class SettingsIOModel
    {
        public int QuestionsPerQuiz { get; set; }

        public SettingsIOModel(int questionsPerQuiz)
        {
            QuestionsPerQuiz = questionsPerQuiz; 
        }
    }
}
