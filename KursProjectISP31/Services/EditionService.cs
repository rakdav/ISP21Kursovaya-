using KursProjectISP31.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProjectISP31.Services
{
    public class EditionService : BaseService<Edition>
    {
        public override bool Add(Edition obj)
        {
            using (KursovayaContext db = new KursovayaContext())
            {
                db.Editions.Add(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
        public override bool Delete(Edition obj)
        {
            using (KursovayaContext db = new KursovayaContext())
            {
                db.Editions.Remove(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
        public override List<Edition> GetAll()
        {
            using (KursovayaContext db = new KursovayaContext())
            {
                return db.Editions.ToList();
            }
        }

        public override List<Edition> Search(string str)
        {
            using (KursovayaContext db = new KursovayaContext())
            {
                return db.Editions.Where(p => p.EditionName!.StartsWith(str) ||
                p.Volume.ToString().StartsWith(str)||
                p.Circulation.ToString().StartsWith(str)
                ).ToList();
            }
        }

        public override bool Update(Edition obj)
        {
            using (KursovayaContext db = new KursovayaContext())
            {
                db.Editions.Update(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
    }
}
