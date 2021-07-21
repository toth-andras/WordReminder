using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.WRLibrary
{
    /// <summary>
    /// Возникает при попытке передать в поддерживающий IQuestion
    /// класс ответ в неправильном формате.
    /// </summary>
    class UserAnswerOnQuestionException : ApplicationException
    {
        public UserAnswerOnQuestionException() : base("User answer's format was incorrect.") { }
        public UserAnswerOnQuestionException(string message) : base(message) { }
        public UserAnswerOnQuestionException(Exception innerException) : this("User answer's format was incorrect.", innerException) { }
        public UserAnswerOnQuestionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
