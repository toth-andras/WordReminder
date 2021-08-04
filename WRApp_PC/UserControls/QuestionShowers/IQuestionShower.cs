using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WRApp_PC.WRLibrary;

namespace WRApp_PC.UserControls
{
    /// <summary>
    /// Общий интерфейс для всех отображающих вопрос элементов.
    /// </summary>
    public interface IQuestionShower
    {
        IQuestion Question { get; set; }

        public event Action OnCorrectAnswer;
        public event Action OnMistake;

        /// <summary>
        /// Проверка ответа пользователя. 
        /// </summary>
        public UserAnswer CheckAnswer();
    }
}
