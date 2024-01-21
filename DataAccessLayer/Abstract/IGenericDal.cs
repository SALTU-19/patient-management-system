using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T: class
    {
        T Insert(T t);
        T Update(T t);
        T Delete(T t);
        List<T> GetAll();
        T GetByUId(Guid uId);
    }
}
