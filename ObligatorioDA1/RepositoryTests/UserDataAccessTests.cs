using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using Domain;
using System;
using System.Linq;

namespace RepositoryTests
{
    [TestClass]
    public class UserDataAccessTests
    {
        private UserDataAccess _userDataAccess;
        private User _userTest1;
        private User _userTest2;

        public UserDataAccessTests()
        {
            _userDataAccess = new UserDataAccess();


            _userTest1 = new User("Juan", "123456");
            _userTest2 = new User("Ignacio", "papasF");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _userDataAccess.Clear();
        }

        [TestMethod]
        public void AddOneUserToTheDataBase()
        {
            _userDataAccess.Add(_userTest1);

            Assert.AreEqual(_userDataAccess.GetAll().ToList().Count, 1);
        }

        [TestMethod]
        public void AddTwoUsersToTheDataBase()
        {
            _userDataAccess.Add(_userTest1);
            _userDataAccess.Add(_userTest2);

            Assert.AreEqual(_userDataAccess.GetAll().ToList().Count, 2);
        }

        [TestMethod]
        public void GetUserFromDataBase()
        {
            int id = _userDataAccess.Add(_userTest1);

            Assert.AreEqual(id, _userDataAccess.Get(id).UserID);
        }

        [TestMethod]
        public void GetUserFromDataBaseIsNotOtherUser()
        {
            int id1 = _userDataAccess.Add(_userTest1);
            int id2 = _userDataAccess.Add(_userTest2);

            Assert.AreNotEqual(id2, _userDataAccess.Get(id1).UserID);
        }
    }
}
