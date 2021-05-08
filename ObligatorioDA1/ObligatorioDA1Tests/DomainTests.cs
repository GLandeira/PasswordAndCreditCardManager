using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Domain;
using Domain.Exceptions;

namespace DomainTests
{
    [TestClass]
    public class DomainTests
    {
        private Domain.Domain _mockDomain;
        private string _userNameInDomain;
        private string _userPasswordInDomain;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDomain = new Domain.Domain();

            _userNameInDomain = "User In Domain";
            _userPasswordInDomain = "Password for User In Domain";
            User presentUser = new User(_userNameInDomain, _userPasswordInDomain);
            _mockDomain.Users.Add(presentUser);
        }

        [TestMethod]
        public void TestAddingAUserActuallyAddsIt()
        {
            string newName = "UserTest";
            User newUser = new User(newName, "pass1");

            _mockDomain.AddUser(newUser);

            Assert.IsTrue(_mockDomain.Users.Contains(newUser));
        }

        [TestMethod]
        public void TestAddingAUserThatsAlreadyThereThrowsException()
        {
            User newUser2 = new User(_userNameInDomain, "pass2");
            Assert.ThrowsException<UserAlreadyExistsException>(() => _mockDomain.AddUser(newUser2));
        }

        [TestMethod]
        public void TestModifyingUserMainPasswordActuallyModifiesIt()
        {
            string newPassword = "fjk187Abs2";
            User modifiedUser = new User(_userNameInDomain, newPassword);
            _mockDomain.ModifyPassword(modifiedUser);

            Assert.AreEqual(newPassword, _mockDomain.Users.First(us => us.Name == _userNameInDomain).MainPassword);
        }

        [TestMethod]
        public void TestModifyingMainPasswordForUnexistingUserThrowsException()
        {
            string userNameNotPresent = "Johny";
            string newPassword = "akshndjplk232";
            User modifiedUser = new User(userNameNotPresent, newPassword);
            Assert.ThrowsException<UserNotPresentException>(() => _mockDomain.ModifyPassword(modifiedUser));
        }

        [TestMethod]
        public void TestLoggingInCorrectlyLogsIn()
        {
            Assert.IsTrue(_mockDomain.LogIn(_userNameInDomain, _userPasswordInDomain));
        }

        [TestMethod]
        public void TestLoggingInWithWrongUserReturnsFalse()
        {
            string falseUsername = "Johny";

            Assert.IsFalse(_mockDomain.LogIn(falseUsername, _userPasswordInDomain));
        }

        [TestMethod]
        public void TestLoggingInWithWrongPasswordReturnsFalse()
        {
            string falsePassword = "akakak23Aj/&";

            Assert.IsFalse(_mockDomain.LogIn(_userNameInDomain, falsePassword));
        }

        [TestMethod]
        public void TestLoggingInWithWrongUserAndPasswordReturnsFalse ()
        {
            string falseUsername = "Johny";
            string falsePassword = "akakak23Aj/&";

            Assert.IsFalse(_mockDomain.LogIn(falseUsername, falsePassword));
        }

        [TestMethod]
        public void TestGettingAUserThatExistsReturnsIt()
        {
            Assert.IsNotNull(_mockDomain.GetUser(_userNameInDomain));
        }

        [TestMethod]
        public void TestGettingAUserAfterAddingReturnsIt()
        {
            string userName = "testName";
            string userPassword = "akakak23Aj/&";
            User testUser = new User(userName, userPassword);

            _mockDomain.AddUser(testUser);

            Assert.IsNotNull(_mockDomain.GetUser(userName));
        }

        [TestMethod]
        public void TestGettingAUserThatDoesntExistThrowsException()
        {
            string userNameThatDoesntExist = "testName";

            Assert.ThrowsException<UserNotPresentException>(() => _mockDomain.GetUser(userNameThatDoesntExist));
        }
    }
}
