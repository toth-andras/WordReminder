using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WRApp_PC.WRLibrary;

namespace WRApp_PC.Core
{
    /// <summary>
    /// Позволяет взаимоддействовать с WRLibrary разным участкам программы.
    /// </summary>
    public static class WRLibraryManager
    {
        public static CardStorage CardStorage { get; set; }

        /// <summary>
        /// Необходимо выполнить перед использованием класса.
        /// </summary>
        public static void Initialize()
        {
            CardStorage = new CardStorage();
        }
    }
}
