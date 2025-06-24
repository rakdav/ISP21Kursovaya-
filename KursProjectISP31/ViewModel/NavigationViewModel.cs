using KursProjectISP31.Utills;
using KursProjectISP31.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KursProjectISP31.ViewModel
{
    public class NavigationViewModel:ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public ICommand HomeCommand { get; set; }
        public ICommand AuthorCommand { get; set; }
        public ICommand EditionCommand { get; set; }
        private void Home(object obj) => CurrentView = new HomeViewModel();
        private void Author(object obj) => CurrentView = new AuthorViewModel();
        private void Edition(object obj) => CurrentView = new EditionViewModel();
        public NavigationViewModel()
        {
            HomeCommand = new RelayCommand(Home);
            AuthorCommand = new RelayCommand(Author);
            EditionCommand = new RelayCommand(Edition);
            // Startup Page
            CurrentView = new HomeViewModel();
        }
    }
}
