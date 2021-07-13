using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary
{
    /// <summary>
    /// Исключение, возникающее при попытке передать значению 
    /// строки пустую строку или null.
    /// </summary>
    public class NullOrEmptyStringException: ApplicationException
    {
        public override string Message => "The given string was null or empty.";
    }
}
