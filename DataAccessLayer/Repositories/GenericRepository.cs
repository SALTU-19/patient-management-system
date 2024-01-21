using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        protected Context context = new Context();
        public T Delete(T t)
        {
            context.Remove(t);
            context.SaveChanges();

            return t;
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetByUId(Guid uId)
        {

            return context.Set<T>().Find(uId);

        }

        public T Insert(T t)
        {
     
            context.Add(t);
            context.SaveChanges();
            return t;

        }

        public T Update(T t)
        {

            context.Update(t);
            context.SaveChanges();
            return t;

        }
    }
}
