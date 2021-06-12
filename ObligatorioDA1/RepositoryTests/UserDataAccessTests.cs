using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RepositoryTests
{
    [TestClass]
    public class UserDataAccessTests
    {
        private UserDataAccess _userDataAccess;
        private User _userTest1;
        private User _userTest2;
        private User _userTest3;

        public UserDataAccessTests()
        {
            _userDataAccess = new UserDataAccess();

            _userTest1 = new User("Juan", "123456");
            _userTest2 = new User("Ignacio", "papasF");
            _userTest3 = new User("Federico", "PapasFritas");
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

        [TestMethod]
        public void GetUserFromDataBaseGetsUserWithServices()
        {
            int id1 = _userDataAccess.Add(_userTest1);
            User gotUser = _userDataAccess.Get(id1);
            bool idsMakeSense = gotUser.UserCategories.UserCategoryID == id1
                             && gotUser.UserCreditCards.UserCreditCardID == id1
                             && gotUser.UserDataBreaches.UserDataBreachesID == id1
                             && gotUser.UserPasswords.UserPasswordID == id1;

            Assert.IsTrue(idsMakeSense);
        }

        [TestMethod]
        public void DeleteUserFromDataBase()
        {
            int id1 = _userDataAccess.Add(_userTest1);

            _userDataAccess.Delete(_userTest1);

            Assert.IsFalse(_userDataAccess.GetAll().Any(p => p.UserID == id1));
        }

        [TestMethod]
        public void DeleteAnotherUserFromDataBaseDoesntDeleteMine()
        {
            int id1 = _userDataAccess.Add(_userTest1);
            int id2 = _userDataAccess.Add(_userTest2);

            _userDataAccess.Delete(_userTest2);

            Assert.IsTrue(_userDataAccess.GetAll().Any(p => p.UserID == id1));
        }

        [TestMethod]
        public void ModifyUserOnDataBase()
        {
            int id1 = _userDataAccess.Add(_userTest1);

            string newPassword = "myNewPassword";
            _userTest1.MainPassword = newPassword;

            _userDataAccess.Modify(_userTest1);

            Assert.AreEqual(newPassword, _userDataAccess.Get(id1).MainPassword);
        }

        [TestMethod]
        public void ModifyUserOnDataBaseDoesntModifyMine()
        {
            int id1 = _userDataAccess.Add(_userTest1);
            int id2 = _userDataAccess.Add(_userTest2);

            string newPassword = "myNewPassword";
            _userTest1.MainPassword = newPassword;

            _userDataAccess.Modify(_userTest1);

            Assert.AreNotEqual(newPassword, _userDataAccess.Get(id2).MainPassword);
        }

        [TestMethod]
        public void GetAllBringsAllFromDatabase()
        {
            _userDataAccess.Add(_userTest1);
            _userDataAccess.Add(_userTest2);
            _userDataAccess.Add(_userTest3);

            List<User> allUsers = _userDataAccess.GetAll().ToList();

            Assert.IsTrue(allUsers.Contains(_userTest1) && allUsers.Contains(_userTest2) && allUsers.Contains(_userTest3));
        }
    }
}
