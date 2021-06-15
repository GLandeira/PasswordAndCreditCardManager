using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DomainTests
{
    public class MockDataBreachesDataAccess : DataAccessMock<DataBreach>
    {
        public MockDataBreachesDataAccess()
        {
            _mockList = new List<DataBreach>();
            _fakeId = 0;
        }

        public override int Add(DataBreach entity)
        {
            _fakeId++;
            entity.DataBreachID = _fakeId;
            _mockList.Add(entity);

            return _fakeId;
        }

        public override void Delete(DataBreach entity)
        {
            throw new NotImplementedException();
        }

        public override DataBreach Get(int id)
        {
            return _mockList.FirstOrDefault(u => u.DataBreachID == id);
        }

        public override IEnumerable<DataBreach> GetAll()
        {
            return _mockList;
        }

        public override void Modify(DataBreach entity)
        {
            DataBreach dataBreachInList = _mockList.FirstOrDefault(u => u.DataBreachID == entity.DataBreachID);
            entity.DataBreachID = dataBreachInList.DataBreachID;
            dataBreachInList = entity;
        }
    }
}
