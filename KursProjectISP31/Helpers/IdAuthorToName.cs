using KursProjectISP31.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KursProjectISP31.Helpers
{
    public class IdAuthorToName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id = int.Parse(value.ToString()!);
            using (KursovayaContext db = new KursovayaContext()) 
            {
                return db.Authors.Where(p => p.IdAuthor == id).FirstOrDefault()!.Surname!;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
