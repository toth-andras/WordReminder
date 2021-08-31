using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    /// Вызывается, когда в файле недостаточно столбцов.
    /// </summary>
    public class NotEnoughColumnsInFileException : ApplicationException
    {
        public NotEnoughColumnsInFileException() : base("Not enough columns in file.") { }

        public NotEnoughColumnsInFileException(int columnsGiven, int columnsMustBe) : base($"Not enough columns in file. Must be {columnsMustBe}, {columnsGiven} was/were given.") { }
    }
}
