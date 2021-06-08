using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IDataAccess<T>
    {
        int Add(T entity);
        void Modify(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Delete(T entity);
    }
}