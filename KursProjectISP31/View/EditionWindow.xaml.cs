using KursProjectISP31.Model;
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
using System.Windows.Shapes;

namespace KursProjectISP31.View
{
    /// <summary>
    /// Логика взаимодействия для EditionWindow.xaml
    /// </summary>
    public partial class EditionWindow : Window
    {
        public Edition ThisEdition { get; private set; }
        private KursovayaContext db = new KursovayaContext();
        public EditionWindow(Edition edition)
        {
            InitializeComponent();
            ThisEdition = edition;
            DataContext = ThisEdition;
            AuthorsComboBox.ItemsSource = db.Authors.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
