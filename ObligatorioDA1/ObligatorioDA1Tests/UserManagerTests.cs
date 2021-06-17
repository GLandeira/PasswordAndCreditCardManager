using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Domain;
using Domain.Exceptions;
using Repository;

namespace DomainTests
{
    [TestClass]
    public class UserManagerTests
    {
        private Domain.UserManager _mockDomain;
        private string _userNameInDomain;
        private string _userPasswordInDomain;

        public UserManagerTests()
        {
            _mockDomain = UserManager.Instance;
            _userNameInDomain = "User In Domain";
            _userPasswordInDomain = "PasswordDomain";
        }

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext tc)
        {
            DataAccessDTO mockDataAccess = new DataAccessDTO();
            mockDataAccess.UserDataAccess = new MockUserDataAccess();
            mockDataAccess.CategoryDataAccess = new MockCategoryDataAccess();
            mockDataAccess.DataBreachDataAccess = new MockDataBreachesDataAccess();
            mockDataAccess.CreditCardDataAccess = new MockCreditCardDataAccess();
            mockDataAccess.PasswordDataAccess = new MockPasswordDataAccess();
            new RepositoryFacade(mockDataAccess);
            new UserManager();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockDomain.Users.Clear();
        }

        [TestMethod]
        public void TestAddingAUserActuallyAddsIt()
        {
            string newName = "UserTest";
            User newUser = new User(newName, "pass1");
            newUser.Encryptor = new MockEncryptor();

            _mockDomain.AddUser(newUser);

            Assert.IsTrue(_mockDomain.Users.Contains(newUser));
        }

        [TestMethod]
        public void TestAddingAUserThatsAlreadyThereThrowsException()
        {
            User presentUser = new User(_userNameInDomain, _userPasswordInDomain);
            presentUser.Encryptor = new MockEncryptor();
            _mockDomain.AddUser(presentUser);

            User newUser2 = new User(_userNameInDomain, "pass2");
            Assert.ThrowsException<UserAlreadyExistsException>(() => _mockDomain.AddUser(newUser2));
        }

        [TestMethod]
        public void TestModifyingUserMainPasswordActuallyModifiesIt()
        {
            User presentUser = new User(_userNameInDomain, _userPasswordInDomain);
            presentUser.Encryptor = new MockEncryptor();
            _mockDomain.AddUser(presentUser);

            string newPassword = "fjk187Abs2";
            User modifiedUser = new User(presentUser.UserID, _userNameInDomain, newPassword);
            modifiedUser.Encryptor = new MockEncryptor();
            _mockDomain.ModifyPassword(modifiedUser);

            Assert.AreEqual(newPassword, _mockDomain.Users.First(us => us.Name == _userNameInDomain).MainPassword);
        }

        [TestMethod]
        public void TestModifyingMainPasswordForUnexistingUserThrowsException()
        {
            string userNameNotPresent = "Johny";
            string newPassword = "akshndjplk232";
            User modifiedUser = new User(userNameNotPresent, newPassword);
            modifiedUser.Encryptor = new MockEncryptor();
            Assert.ThrowsException<UserNotPresentException>(() => _mockDomain.ModifyPassword(modifiedUser));
        }

        [TestMethod]
        public void TestLoggingInCorrectlyLogsIn()
        {
            User presentUser = new User(_userNameInDomain, _userPasswordInDomain);
            presentUser.Encryptor = new MockEncryptor();
            _mockDomain.AddUser(presentUser);

            Assert.IsTrue(_mockDomain.LogIn(presentUser, _userPasswordInDomain));
        }

        [TestMethod]
        public void TestLoggingInWithWrongUserReturnsFalse()
        {
            string falseUsername = "Johny";
            User falseUser = new User(falseUsername, _userPasswordInDomain);
            falseUser.Encryptor = new MockEncryptor();


            Assert.IsFalse(_mockDomain.LogIn(falseUser, _userPasswordInDomain));
        }

        [TestMethod]
        public void TestLoggingInWithWrongPasswordReturnsFalse()
        {
            string falsePassword = "akakak23Aj/&";
            User falseUser = new User(_userNameInDomain, falsePassword);
            falseUser.Encryptor = new MockEncryptor();


            Assert.IsFalse(_mockDomain.LogIn(falseUser, falsePassword));
        }

        [TestMethod]
        public void TestLoggingInWithWrongUserAndPasswordReturnsFalse ()
        {
            string falseUsername = "Johny";
            string falsePassword = "akakak23Aj/&";
            User falseUser = new User(falseUsername, falsePassword);
            falseUser.Encryptor = new MockEncryptor();

            Assert.IsFalse(_mockDomain.LogIn(falseUser, falsePassword));
        }

        [TestMethod]
        public void TestGettingAUserThatExistsReturnsIt()
        {
            User presentUser = new User(_userNameInDomain, _userPasswordInDomain);
            presentUser.Encryptor = new MockEncryptor();
            _mockDomain.AddUser(presentUser);

            Assert.IsNotNull(_mockDomain.GetUser(_userNameInDomain));
        }

        [TestMethod]
        public void TestGettingAUserAfterAddingReturnsIt()
        {
            string userName = "testName";
            string userPassword = "akakak23Aj/&";
            User testUser = new User(userName, userPassword);
            testUser.Encryptor = new MockEncryptor();

            _mockDomain.AddUser(testUser);

            Assert.IsNotNull(_mockDomain.GetUser(userName));
        }

        [TestMethod]
        public void TestGettingAUserThatDoesntExistThrowsException()
        {
            string userNameThatDoesntExist = "testNameThatDoesntExist";

            Assert.ThrowsException<UserNotPresentException>(() => _mockDomain.GetUser(userNameThatDoesntExist));
        }
    }
}
