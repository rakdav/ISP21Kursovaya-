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
        public ObservableCollection<Edition> Editions { get; set; }
        public List<Author> authorList;
        public AuthorService authorService;
        public EditionService editionService;

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
    }
}
