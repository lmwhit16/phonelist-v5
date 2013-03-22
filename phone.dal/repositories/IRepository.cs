using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace scholarship.dal
{
    interface IRepository<T>
    {
        T getById(T object2Add);
        T[] getAll();
        void add(T object2Add);
        void update(T object2Update);
        void remove(T object2Remove);
        IQueryable<T> query(Expression<Func<T, bool>> filter); 
    }
}
