using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository
{
    public class MockUserDataAccess : DataAccessMock<User>
    {
        public MockUserDataAccess()
        {
            _mockList = new List<User>();
            _fakeId = 0;
        }

        public override int Add(User entity)
        {
            _fakeId++;
            entity.UserID = _fakeId;
            _mockList.Add(entity);
            
            return _fakeId;
        }

        public override void Delete(User entity)
        {
            _mockList.Remove(entity);
        }

        public override User Get(int id)
        {
            return _mockList.FirstOrDefault(u => u.UserID == id);
        }

        public override IEnumerable<User> GetAll()
        {
            return _mockList;
        }

        public override void Modify(User entity)
        {
            User userInList = _mockList.FirstOrDefault(u => u.UserID == entity.UserID);
            entity.UserID = userInList.UserID;
            userInList = entity;
        }
    }
}
