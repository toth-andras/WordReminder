using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WRApp_PC.WRLibrary;

namespace WRApp_PC.UserControls
{
    /// <summary>
    /// Interaction logic for AddEditCard_Page.xaml
    /// </summary>
    
    // Тип страницы.
    enum PageType { AddCard, EditCard }

    public partial class AddEditCard_Page : UserControl
    {
        private Card card;
        private PageType type;

        /// <summary>
        /// Вызывается, когда странница произвела все необходимые действия и может быть закрыта.
        /// </summary>
        public Action OnFinished;

        public AddEditCard_Page()
        {
            InitializeComponent();

            // Если карточка не передана - значит, нужен режим создания.
            type = PageType.AddCard;

            SetUI();
        }
        public AddEditCard_Page(Card card)
        {
            InitializeComponent();

            this.card = card;
            type = PageType.EditCard;

            SetUI();
        }

        // Формирует интрефейс страницы, основываясь на типе страницы.
        private void SetUI()
        {
            switch (type)
            {
                case PageType.AddCard:
                    AddCardType();
                    break;

                case PageType.EditCard:
                    EditCardType();
                    break;

                default:
                    break;
            }
        }

        // Формирует интерфейс страницы для типа страницы "Добавить карточку".
        private void AddCardType()
        {
            PageTitleLabel.Content = "Добавить карточку";
        }

        // Формирует интерфейс страницы для типа страницы "Редактировать карточку".
        private void EditCardType()
        {
            PageTitleLabel.Content = "Редактировать карточку";
        }
    }
}
