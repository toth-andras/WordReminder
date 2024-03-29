﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLibrary
{
    public delegate void QuestionDelegate(object sender, EventArgs e);

    /// <summary>
    /// Интерфейс для определения базового функционала вопроса.
    /// </summary>
    public interface IQuestion
    {
        Card Card { get; set; }

        /// <summary>
        /// Формулировка вопроса в формате строки.
        /// </summary>
        public string TextDescription { get; }

        /// <summary>
        /// Вызывается при правильном ответе на вопрос.
        /// </summary>
        public event QuestionDelegate OnCorrectAnswer;

        /// <summary>
        /// Вызывается при неправильном ответе на вопрос.
        /// </summary>
        public event QuestionDelegate OnMistake;

        /// <summary>
        /// Проверить ответ пользователя.
        /// </summary>
        /// <param name="userChoice">Ответ пользователя в какой-либо форме.</param>
        /// <returns>Один из вариантов результата проверки.</returns>
        public UserAnswer CheckAnswer(object userChoice);
    }
}
