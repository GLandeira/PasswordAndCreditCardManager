using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DomainTests
{
    public class MockPasswordDataAccess : DataAccessMock<Password>
    {
        public MockPasswordDataAccess()
        {
            _mockList = new List<Password>();
            _fakeId = 0;
        }

        public override int Add(Password entity)
        {
            _fakeId++;
            entity.PasswordID = _fakeId;
            _mockList.Add(entity);

            return _fakeId;
        }

        public override void Delete(Password entity)
        {
            _mockList.Remove(entity);
        }

        public override Password Get(int id)
        {
            return _mockList.FirstOrDefault(u => u.PasswordID == id);
        }

        public override IEnumerable<Password> GetAll()
        {
            return _mockList;
        }

        public override void Modify(Password entity)
        {
            Password userInList = _mockList.FirstOrDefault(u => u.PasswordID == entity.PasswordID);
            entity.PasswordID = userInList.PasswordID;
            userInList = entity;
        }
    }
}
