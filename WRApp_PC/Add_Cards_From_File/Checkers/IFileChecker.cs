using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    /// Описывает поведение класса, осуществляющего проверку файла.
    /// </summary>
    public interface IFileChecker
    {
        /// <summary>
        /// Список критериев, на соответсвие которым будет проверен файл.
        /// </summary>
        List<ICriteria> Criterias { get; set; }

        /// <summary>
        /// Проверить файл.
        /// </summary>
        void Check(string filePath);

        /// <summary>
        /// Вызывается, когда при проверке файла возникает ошибка,
        /// не требующая для обработки ничего, кроме отображения.
        /// string - текст ошибки.
        /// </summary>
        event Action<string> OnBasicError;

        /// <summary>
        /// Вызывается, когда при проверке файла возникает ошибка,
        /// требующая для обработки дополнительных действий.
        /// SpecialErrors - тип особой ошибки,
        /// string - путь к файлу, который проверялся,
        /// string - текст ошибки.
        /// </summary>
        event SpecialErrorDelegate OnSpecialError;

        /// <summary>
        /// Вызывается, когда во время проверки файла не было обнаружено ошибок.
        /// string - путь к файлу.
        /// </summary>
        event Action<string> OnFileIsOk;
    }
}
