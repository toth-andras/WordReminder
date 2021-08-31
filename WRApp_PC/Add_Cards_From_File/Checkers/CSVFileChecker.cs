using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    /// Проверяет файлы формата .csv
    /// </summary>
    public class CSVFileChecker : IFileChecker
    {
        public List<ICriteria> Criterias { get; set; }

        public event Action<string> OnFileIsOk;
        public event Action<string> OnBasicError;
        public event SpecialErrorDelegate OnSpecialError;

        public CSVFileChecker()
        {
            Criterias = new List<ICriteria>()
            {
                new FileHasTwoColumnsCriteria()
            };
        }

        public void Check(string filePath)
        {
            try
            {
                string[] fileLines = File.ReadAllLines(filePath);

                foreach (ICriteria criteria in Criterias)
                {
                    criteria.Check(fileLines);
                }

                OnFileIsOk?.Invoke(filePath);
            }
            catch (NotEnoughColumnsInFileException)
            {
                OnBasicError?.Invoke("В файле недостаточно столбцов.");
            }
            catch (TooManyColumnsInFileException)
            {
                OnSpecialError?.Invoke(SpecialErrors.TooManyColumnsInFile, filePath, "В файле слишком много столбцов.");
            }
        }
    }
}
