using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.WRLibrary.Services
{
    /// <summary>
    /// Класс-конейнер для чтения и записи карточек.
    /// </summary>
    public class CardIOModel
    {
        public string Term { get; set; }

        public string Value { get; set; }

        public CardCategory Category { get; set; }

        public int TotalMistakesCount { get; set; }

        public int TotalCorrectAnswerCount { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? LastMistakeDate { get; set; }

        public DateTime? LastUsedDate { get; set; }

        public UserAnswer? LastAnswer { get; set; }

        public CardIOModel(string term, string value, CardCategory category, int totalMistakesCount, int totalCorrectAnswerCount,
                           DateTime creationDate, DateTime? lastMistakeDate, DateTime? lastUsedDate, UserAnswer? lastAnswer)
        {
            Term = term;
            Value = value;
            Category = category;
            TotalMistakesCount = totalMistakesCount;
            TotalCorrectAnswerCount = totalCorrectAnswerCount;
            CreationDate = creationDate;
            LastMistakeDate = lastMistakeDate;
            LastUsedDate = lastUsedDate;
            LastAnswer = lastAnswer;
        }
    }
}
