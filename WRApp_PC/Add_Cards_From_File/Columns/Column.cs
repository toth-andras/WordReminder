using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    /// Столбец
    /// </summary>
    public class Column
    {
        // Элементы столбца.
        private List<string> values;

        /// <summary>
        /// Название столбца.
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// Элементы столбца.
        /// </summary>
        public string[] Values => values.ToArray();

        /// <summary>
        /// Индекс столбца в файле.
        /// </summary>
        public int Index { get; set; }

        public Column()
        {
            ColumnName = "";
            values = new List<string>();
            Index = 0;
        }

        public Column(string columnName, string[] values)
        {
            ColumnName = columnName;
            this.values = values.ToList();
        }

        /// <summary>
        /// Добавить к элементам столбца ещё один.
        /// </summary>
        public void AddValue(string value)
        {
            values.Add(value);
        }
    }
}
