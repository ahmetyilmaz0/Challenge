using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private static ChallengeDBContext context;
        public ChallengeDBContext Context
        {
            get
            {
                if (context == null)
                {
                    context = new ChallengeDBContext();
                }

                return context;
            }
            set { context = value; }
        }

        public IList<T> List()
        {
            return Context.Set<T>().ToList();
        }

        public bool Add(T entity)
        {
            try
            {
                Context.Set<T>().Add(entity);
                Context.SaveChanges();
                Context = new ChallengeDBContext();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(T entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Deleted;
                Context.Set<T>().Attach(entity);
                Context.Set<T>().Remove(entity);
                Context.SaveChanges();
                Context = new ChallengeDBContext();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(T entity)
        {
            try
            {
                Context.Set<T>().AsNoTracking<T>();
                Context.Set<T>().Update(entity);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
