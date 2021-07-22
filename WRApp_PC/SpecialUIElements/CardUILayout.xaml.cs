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

namespace WRApp_PC.SpecialUIElements
{
    /// <summary>
    /// Interaction logic for CardUILayout.xaml
    /// </summary>
    public partial class CardUILayout : UserControl
    {
        public CardUILayout(Card card)
        {
            InitializeComponent();

            if (card is null)
            {
                throw new NullReferenceException("Parameter 'card' was null.") { Source = "CardUILayout.CardUILayout(Card)" };
            }

            TermTextBlock.Text = card.Term;
            ValueTextBlock.Text = card.Value;
        }
    }
}
