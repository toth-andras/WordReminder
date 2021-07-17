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
        public HomeViewModel HomeVM { get; set; }

        public object CurrentView
        {
            get { return currentView; }
            set { currentView = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            CurrentView = HomeVM;
        }
    }
}
