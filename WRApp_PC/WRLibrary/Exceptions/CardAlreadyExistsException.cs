using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.WRLibrary
{
    /// <summary>
    /// Вызывается при попытке создания дубликата карточки.
    /// </summary>
    public class CardAlreadyExistsException : ApplicationException
    {
        public CardAlreadyExistsException() : base("A card with these term and value has already been added to storage.") { }
        public CardAlreadyExistsException(string message) : base(message) { }
        public CardAlreadyExistsException(Exception innerException) : this("A card with these term and value has already been added to storage.", innerException) { }
        public CardAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
    }
}
