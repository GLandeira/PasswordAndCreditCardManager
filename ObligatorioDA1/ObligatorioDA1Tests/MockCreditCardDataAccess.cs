using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DomainTests
{
    class MockCreditCardDataAccess : DataAccessMock<CreditCard>
    {

        public MockCreditCardDataAccess()
        {
            _mockList = new List<CreditCard>();
            _fakeId = 0;
        }

        public override int Add(CreditCard entity)
        {
            _fakeId++;
            entity.CreditCardID = _fakeId;
            _mockList.Add(entity);

            return _fakeId;
        }

        public override void Delete(CreditCard entity)
        {
            _mockList.Remove(entity);
        }

        public override CreditCard Get(int id)
        {
            return _mockList.FirstOrDefault(u => u.CreditCardID == id);
        }

        public override IEnumerable<CreditCard> GetAll()
        {
            return _mockList;
        }

        public override void Modify(CreditCard entity)
        {
            CreditCard userInList = _mockList.FirstOrDefault(u => u.CreditCardID == entity.CreditCardID);
            entity.CreditCardID = userInList.CreditCardID;
            userInList = entity;
        }
    }
}
