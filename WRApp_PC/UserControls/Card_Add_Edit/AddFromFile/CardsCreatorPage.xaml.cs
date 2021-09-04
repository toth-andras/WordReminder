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
using WRApp_PC.SpecialUIElements;
using WRApp_PC.Add_Cards_From_File;

namespace WRApp_PC.UserControls
{
    /// <summary>
    /// Interaction logic for CardsCreatorPage.xaml
    /// </summary>
    public partial class CardsCreatorPage : UserControl
    {
        private List<Card> cards;

        public CardsCreatorPage(ICardsCreator cardsCreator)
        {
            InitializeComponent();

            cards = cardsCreator.CreateCards();

            DisplayCards();
        }

        public void DisplayCards()
        {
            CardsStack.Children.Clear();

            foreach (Card card in cards)
            {
                CardUILayout layout = new CardUILayout(card, CardUILayoutButtons.Remove);
                layout.RemoveButtonPressed += (obj, e) => { cards.Remove(e.Card); DisplayCards(); };

                CardsStack.Children.Add(layout);
            }
        }
    }
}
