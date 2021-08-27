using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    /// Фильтр для файлов формата .csv
    /// </summary>
    public class CSVFileFilter : IFileFilter
    {
        public string GetFilter()
        {
            return "CSV files (*.csv)|*.csv";
        }
    }
}
