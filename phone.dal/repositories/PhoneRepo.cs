using scholarship.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone.dal.respositories
{
    public class PhoneRepo : IRepository<Phone>
    {
        private PhoneDBEntities _context = null;

        public PhoneRepo() {
            _context = new PhoneDBEntities();    
        }
        public Phone getById(Phone object2get)
        {
            return _context.Phones.Find(object2get.PHONE_ID);
        }

        public Phone[] getAll()
        {
            return _context.Phones.ToArray();
        }

        public void add(Phone phone2add)
        {
            _context.Phones.Add(phone2add);
            _context.SaveChanges();
        }

        public void update(Phone phone2update)
        {
            _context.Entry(phone2update).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void remove(Phone phone2remove)
        {
            _context.Phones.Remove(phone2remove);
            _context.SaveChanges();
        }

        public IQueryable<Phone> query(System.Linq.Expressions.Expression<Func<Phone, bool>> filter)
        {
            return _context.Phones.Where(filter);
        }
    }
}
