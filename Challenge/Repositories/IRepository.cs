using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Repositories
{
    public interface IRepository<T>
    {
        IList<T> List();
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
    }
}
