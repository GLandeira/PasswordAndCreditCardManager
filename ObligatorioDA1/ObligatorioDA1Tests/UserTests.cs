using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Exceptions;

namespace DomainTests
{
    [TestClass]
    public class UserTests
    {
        private User _testUser;
        private UserManager _userManager;

        [TestInitialize]
        public void TestInitialize()
        {
            _userManager = UserManager.Instance;
            _testUser = new User("UserName", "SomePassword");
        }
        
        [TestMethod]
        public void TestGoodEqualsCase()
        {
            string name = "Pablo";
            User userOne = new User(name, "pass1");
            User userTwo = new User(name, "pass2");

            Assert.AreEqual(userOne, userTwo);
        }

        [TestMethod]
        public void TestBadEqualsCase()
        {
            string name1 = "Johnny";
            string name2 = "Alice";
            User userOne = new User(name1, "pass1");
            User userTwo = new User(name2, "pass2");

            Assert.AreNotEqual(userOne, userTwo);
        }
    }
}
