using KursProjectISP31.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursProjectISP31.Services
{
    public class AuthorService : BaseService<Author>
    {

        public override bool Add(Author obj)
        {
            using (KursovayaContext db=new KursovayaContext()) {
                db.Authors.Add(obj);
                db.SaveChangesAsync();
            }
            return true;
        }

        public override bool Delete(Author obj)
        {
            using (KursovayaContext db = new KursovayaContext())
            {
                db.Authors.Remove(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
        public override List<Author> GetAll()
        {
            using (KursovayaContext db = new KursovayaContext())
            {
                return db.Authors.ToList();
            }
        }
        public override bool Update(Author obj)
        {
            using (KursovayaContext db = new KursovayaContext())
            {
                db.Authors.Update(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
        public override List<Author> Search(string str)
        {
            using (KursovayaContext db = new KursovayaContext())
            {
               return db.Authors.Where(p => p.Surname!.StartsWith(str)).ToList();
            }
        }
    }
}
