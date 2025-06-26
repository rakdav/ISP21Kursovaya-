using KursProjectISP31.Model;
using KursProjectISP31.Services;
using KursProjectISP31.Utills;
using KursProjectISP31.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KursProjectISP31.ViewModel
{
    public class AuthorViewModel:ViewModelBase
    {
        private AuthorService authorService;

        private ObservableCollection<Author> authors;
        public ObservableCollection<Author> Authors
        {
            get { return authors; }
            set
            {
                if (authors != value)
                {
                    authors = value;
                    OnPropertyChanged(nameof(Authors));
                }
            }
        }
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

        private Author selectedAuthor;
        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set
            {
                selectedAuthor = value;
                OnPropertyChanged(nameof(SelectedAuthor));
            }
        }

        public AuthorViewModel()
        {
            authorService = new AuthorService();
            Authors = new ObservableCollection<Author>(authorService.GetAll());
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      AuthorWindow window = new AuthorWindow(new Author());
                      if (window.ShowDialog() == true)
                      {
                          authorService.Add(window.Author);
                          authors.Add(window.Author);
                      }
                  }));
            }
        }
        private RelayCommand? editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((o) =>
                  {
                      Author author = (o as Author)!;
                      AuthorWindow window = new AuthorWindow(author);
                      if (window.ShowDialog() == true)
                      {
                          authorService.Update(window.Author);
                      }
                  }));
            }
        }
        private RelayCommand? deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((o) =>
                  {
                      Author author = (o as Author)!;
                      MessageBoxResult result= MessageBox.Show("Вы действительно хотите удалить объект " + author!.Surname+" "+author.FirstName!.Substring(0,1)+"."+
                          author.LastName!.Substring(0,1)+".", "Удаление объекта", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                      if (result == MessageBoxResult.Yes)
                      {
                          authorService.Delete(author);
                          authors.Remove(author);
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
                          Authors = new ObservableCollection<Author>(authorService.GetAll());
                      }
                      else
                      {
                          Authors = new ObservableCollection<Author>(authorService.Search(SearchText));
                      }
                  }));
            }
        }
    }
}
