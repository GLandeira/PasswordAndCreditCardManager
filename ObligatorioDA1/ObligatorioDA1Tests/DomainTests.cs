using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Domain.Exceptions;

namespace DomainTests
{
    [TestClass]
    public class DomainTests
    {
        private Domain.Domain _testDomain;

        [TestInitialize]
        public void TestInitialize()
        {
            _testDomain = new Domain.Domain();
        }

        [TestMethod]
        public void TestAddingAUserActuallyAddsIt()
        {
            string newName = "User";
            User newUser = new User(newName, "pass1");

            _testDomain.AddUser(newUser);

            Assert.IsTrue(_testDomain.Users.Contains(newUser));
        }

        [TestMethod]
        public void TestAddingAUserThatsAlreadyThereThrowsException()
        {
            string presentUserName = "User";
            User newUser1 = new User(presentUserName, "pass1");

            _testDomain.AddUser(newUser1);

            User newUser2 = new User(presentUserName, "pass2");
            Assert.ThrowsException<UserAlreadyExistsException>(() => _testDomain.AddUser(newUser2));
        }

        [TestMethod]
        public void TestModifyingUserMainPasswordActuallyModifiesIt()
        {

        }

        [TestMethod]
        public void TestModifyingMainPasswordForUnexistingUserThrowsException()
        {
        }

        [TestMethod]
        public void TestLoggingInCorrectlyLogsIn()
        {
        }

        [TestMethod]
        public void TestLoggingInWithWrongUserThrowsException()
        {
        }

        [TestMethod]
        public void TestLoggingInWithWrongPasswordThrowsException()
        {
        }

        [TestMethod]
        public void TestLoggingInWithWrongUserAndPasswordThrowsExceptionForUser()
        {
        }
    }
}
