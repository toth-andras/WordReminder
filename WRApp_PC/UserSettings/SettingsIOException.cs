using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.UserSettings
{
    public class SettingsIOException : ApplicationException 
    {
        public SettingsIOException(string message, Exception innerException) : base(message, innerException) { }
        public SettingsIOException(Exception exception) : this("Exception was thrown during the IO process of Settings", exception) { }
    }
}
