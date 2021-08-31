using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    /// Делегат для событий, которые вызываются, когда при 
    /// проверке файла возникает ошибка, требующая для обработки
    /// дополнительных действий.
    /// SpecialErrors - тип особой ошибки,
    /// string - путь к файлу, который проверялся,
    /// string - текст ошибки.
    /// </summary>
    public delegate void SpecialErrorDelegate(SpecialErrors error, string filePath, string errorText);
}
