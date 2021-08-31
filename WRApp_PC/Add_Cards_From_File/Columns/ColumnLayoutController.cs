using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRApp_PC.Add_Cards_From_File
{
    /// <summary>
    /// Гарантирует, что из всех элементов, находящихся под контролем, 
    /// одновременно будут выбраны не более указанного числа элементов.
    /// </summary>
    public class ColumnLayoutController
    {
        // Сколько элементов могут быть одновременно выбранными.
        private readonly int maxElementsChosen;

        // Одновременно выбранные элементы.
        private List<IColumnLayout> elements;

        public ColumnLayoutController(int elementsChosen = 2)
        {
            maxElementsChosen = elementsChosen;
            elements = new List<IColumnLayout>();
        }

        // Отработать выбор элемента.
        private void ManageClickedElement(IColumnLayout element)
        {
            // Если элемент выбран
            if (element.IsSelected)
            {
                // Если уже выбрано достаточное кол-во элементов, а пользователь
                // хочет добавить еще один, делаем невыбранным первый(самый старый) элемент.
                if (elements.Count + 1 > maxElementsChosen)
                {
                    elements.First().MarkAsUnchecked();
                    elements.RemoveAt(0);
                }

                element.MarkAsChecked();
                elements.Add(element);
            }
            else
            {
                element.MarkAsUnchecked();
                elements.Remove(element);
            }
        }

        /// <summary>
        /// Добавить элемент в список отслеживаемых контроллером.
        /// </summary>
        public void TakeUnderControl(IColumnLayout element)
        {
            element.OnClicked += ManageClickedElement;
        }

        public List<IColumnLayout> GetChosenElements()
        {
            return elements;
        }
    }
}
