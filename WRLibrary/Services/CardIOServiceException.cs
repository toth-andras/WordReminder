using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary.Services
{
    /// <summary>
    /// Ошибки во время сохранения/чтения карточек.
    /// </summary>
    public class CardIOServiceException: ApplicationException
    {
        public CardIOServiceException() : base("An exception was thrown while cards IO process.") { }
        public CardIOServiceException(Exception innerException) : this("An exception was thrown while cards IO process.", innerException) { }
        public CardIOServiceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
