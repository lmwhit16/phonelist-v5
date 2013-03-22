using phone.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholarship.dal.Repositories
{
    public class PhoneCodeRepo : IRepository<PhoneCD>
    {
        private PhoneDBEntities _context = null;

        public PhoneCodeRepo()
        {
            _context = new PhoneDBEntities();
        }
        public PhoneCD getById(PhoneCD phone)
        {
            //return _context.PhoneCDs.Find(cd);
            return _context.PhoneCDs.Where(
                    pc => pc.PHONE_CD == phone.PHONE_CD
                ).FirstOrDefault();
        }

        public PhoneCD[] getAll()
        {
            return _context.PhoneCDs.ToArray();
        }

        public void add(PhoneCD phoneCode2Cd){
            _context.PhoneCDs.Add(phoneCode2Cd);
            _context.SaveChanges();
        }

        public void update(PhoneCD phoneCode2Update)
        {
            _context.Entry(phoneCode2Update).State = EntityState.Modified;
            _context.SaveChanges();
        }

      
        public void remove(PhoneCD phone2remove)
        {
            _context.PhoneCDs.Remove(phone2remove);
            _context.SaveChanges();
        }

        public IQueryable<PhoneCD> query(System.Linq.Expressions.Expression<Func<PhoneCD, bool>> filter)
        {
            return _context.PhoneCDs.Where(filter);
        }
    }
}
