using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    /// Класс, представляющий компонент, проверяющий текст 
    /// файла на соответсвие одному критерию.
    /// </summary>
    public interface ICriteria
    {
        void Check(string[] fileLines);
    }
}
