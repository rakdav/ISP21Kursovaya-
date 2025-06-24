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
using System.Windows;

namespace KursProjectISP31.ViewModel
{
    public class AuthorViewModel:ViewModelBase
    {
        public ObservableCollection<Author> Authors { get; set; }
        public AuthorService authorService;
        
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
            Load();
        }
        private void Load()
        {
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
                          Authors.Add(window.Author);
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
                          Authors.Remove(author);
                      } 
                  }));
            }
        }
    }
}
