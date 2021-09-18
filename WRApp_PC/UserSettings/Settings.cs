using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.UserSettings
{
    /// <summary>
    /// Представляет данные, изменяемые пользователем в настройках.
    /// </summary>
    public static class Settings
    {
        // Кол-во вопросов в опросе.
        private static int questionsPerQuiz;

        private static SettingsIOManager IOManager;

        /// <summary>
        /// Количество вопросов в опросе.
        /// </summary>
        public static int QuestionsPerQuiz
        {
            get { return questionsPerQuiz; }
            set
            {
                if (value <= 0)
                {
                    questionsPerQuiz = 0;
                }
                else
                {
                    questionsPerQuiz = value;
                }
            }
        }

        static Settings()
        {
            IOManager = new SettingsIOManager($"{Environment.CurrentDirectory}\\settings.json");

            try
            {
                SettingsIOModel model = IOManager.Read();

                QuestionsPerQuiz = model.QuestionsPerQuiz;
            }
            // Настройки по умолчанию на случай ошибки.
            catch (Exception)
            {
                QuestionsPerQuiz = 10;
            }
        }

        public static void ChangeSettings(int questionsPerQuiz)
        {
            QuestionsPerQuiz = questionsPerQuiz;

            IOManager.Write(new SettingsIOModel(QuestionsPerQuiz));
        }
    }
}
