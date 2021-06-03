using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDataAccess<T>
    {
        void Add(T entity);
        void Modify(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Delete(T entity);
    }
}
