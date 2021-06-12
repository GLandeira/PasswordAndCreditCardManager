using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DomainTests
{
    public class MockCategoryDataAccess : DataAccessMock<Category>
    {
        public MockCategoryDataAccess()
        {
            _mockList = new List<Category>();
            _fakeId = 0;
        }

        public override int Add(Category entity)
        {
            _fakeId++;
            entity.CategoryID = _fakeId;
            _mockList.Add(entity);

            return _fakeId;
        }

        public override void Delete(Category entity)
        {
            _mockList.Remove(entity);
        }

        public override Category Get(int id)
        {
            return _mockList.FirstOrDefault(u => u.CategoryID == id);
        }

        public override IEnumerable<Category> GetAll()
        {
            return _mockList;
        }

        public override void Modify(Category entity)
        {
            Category userInList = _mockList.FirstOrDefault(u => u.CategoryID == entity.CategoryID);
            entity.CategoryID = userInList.CategoryID;
            userInList = entity;
        }
    }
}
