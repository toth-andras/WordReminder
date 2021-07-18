using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordReminder_PC.Core;

namespace WordReminder_PC.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        private object currentView;

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand CardsViewCommand { get; set; }
        public RelayCommand AddCardViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public CardsViewModel CardsVM { get; set; }
        public AddCardViewModel AddCardVM { get; set; }

        public object CurrentView
        {
            get { return currentView; }
            set { currentView = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            CardsVM = new CardsViewModel();
            AddCardVM = new AddCardViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVM; });
            CardsViewCommand = new RelayCommand(o => { CurrentView = CardsVM; });
            AddCardViewCommand = new RelayCommand(o => { CurrentView = AddCardVM; });
        }
    }
}
