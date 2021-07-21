using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.WRLibrary
{
    /// <summary>
    /// Возникает при попытке передать дату, которая еще не настала.
    /// </summary>
    public class FutureDateException : ApplicationException
    {
        public FutureDateException() : base("The given date is bigger than current date.") { }
        public FutureDateException(string message, Exception innerException) : base(message, innerException) { }
    }
}
