using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests
{
    public abstract class DataAccessMock<T> : IDataAccess<T>
    {
        protected List<T> _mockList;
        protected static int _fakeId;

        public abstract int Add(T entity);
        public abstract void Modify(T entity);
        public abstract T Get(int id);
        public abstract IEnumerable<T> GetAll();
        public abstract void Delete(T entity);
    }
}
