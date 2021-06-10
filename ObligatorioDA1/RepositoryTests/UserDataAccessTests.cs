﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestInitialize]
        public void TestInitialize()
        {
            _userDataAccess = new UserDataAccess();
            _userDataAccess.Clear();

            _userTest1 = new User
            {
                Name = "Juan",
                MainPassword = "123456"
            };
            _userTest2 = new User
            {
                Name = "Ignacio",
                MainPassword = "papasF"
            };
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


    }
}
