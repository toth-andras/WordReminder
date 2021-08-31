using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.Add_Cards_From_File
{
    public class TooManyColumnsInFileException : ApplicationException
    {
        /// <summary>
        /// Вызывается, когда в файле слишком много столбцов.
        /// </summary>
        public TooManyColumnsInFileException() : base("Too many columns in file.") { }

        public TooManyColumnsInFileException(int columnsGiven, int columnsMustBe) : base($"Too many columns in file. Must be {columnsMustBe}, {columnsGiven} was/were given.") { }
    }
}
