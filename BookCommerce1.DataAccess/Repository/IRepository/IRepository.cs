using BookCommerce1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookCommerce1.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> ListoTeGjitha();
        T FirstOrDefault(Expression<Func<T, bool>> filteri);
        void Add(T entiteti);
        void Remove(T entiteti);
        void RemoveRange(IEnumerable<T> entitetiet);
    }
}
