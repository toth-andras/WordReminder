using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    /// Описывает фильтр для определенного типа файлов.
    /// </summary>
    public interface IFileFilter
    {
        string GetFilter();
    }
}
