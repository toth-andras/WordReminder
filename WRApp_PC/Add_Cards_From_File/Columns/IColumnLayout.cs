using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    /// Описывает требования к элементу, отображающему столбец слов дял создания карточек.
    /// </summary>
    public interface IColumnLayout
    {
        /// <summary>
        /// Отображаемый столбец.
        /// </summary>
        Column Column { get; }

        /// <summary>
        /// Показывает, выбран ли элемент. Должен быть изменен до вызова OnClicked.
        /// </summary>
        bool IsSelected { get; }

        /// <summary>
        /// Заставляет элемент перейти в состояние выбранного.
        /// </summary>
        void MarkAsChecked();

        /// <summary>
        /// Заставляет элемент перейти в состояние невыбранного.
        /// </summary>
        void MarkAsUnchecked();

        /// <summary>
        /// Вызывается, когда пользователь кликнул по элементу.
        /// </summary>
        event Action<IColumnLayout> OnClicked;
    }
}
