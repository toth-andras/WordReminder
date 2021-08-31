using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    /// Критерий, согласно которому в файле должно быть строго два столбца.
    /// </summary>
    public class FileHasTwoColumnsCriteria : ICriteria
    {
        public void Check(string[] fileLines)
        {
            string firstLine = fileLines[0];
            string[] firstLineWords = (from word in firstLine.Split(',') where word != "" select word).ToArray();

            if (firstLineWords.Length < 2)
            {
                throw new NotEnoughColumnsInFileException(firstLineWords.Length, 2);
            }
            else if (firstLineWords.Length > 2)
            {
                throw new TooManyColumnsInFileException(firstLineWords.Length, 2);
            }
        }
    }
}
