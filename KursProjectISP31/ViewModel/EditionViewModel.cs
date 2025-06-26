using KursProjectISP31.Model;
using KursProjectISP31.Services;
using KursProjectISP31.Utills;
using KursProjectISP31.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProjectISP31.ViewModel
{
    public class EditionViewModel: ViewModelBase
    {
        private ObservableCollection<Edition> editions;
        public ObservableCollection<Edition> Editions
        {
            get { return editions; }
            set
            {
                if (editions != value)
                {
                    editions = value;
                    OnPropertyChanged(nameof(Editions));
                }
            }
        }
        public List<Author> authorList;
        public AuthorService authorService;
        public EditionService editionService;
        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }
        public EditionViewModel()
        {
            authorService = new AuthorService();
            editionService = new EditionService();
            Editions = new ObservableCollection<Edition>(editionService.GetAll());
            authorList = authorService.GetAll();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      EditionWindow window = new EditionWindow(new Edition());
                      if (window.ShowDialog() == true)
                      {
                          editionService.Add(window.ThisEdition);
                          Editions.Add(window.ThisEdition);
                      }
                  }));
            }
        }
        private RelayCommand? searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return searchCommand ??
                  (searchCommand = new RelayCommand((o) =>
                  {
                      if (String.IsNullOrEmpty(SearchText))
                      {
                          Editions = new ObservableCollection<Edition>(editionService.GetAll());
                      }
                      else
                      {
                          Editions = new ObservableCollection<Edition>(editionService.Search(SearchText));
                      }
                  }));
            }
        }
    }
}
