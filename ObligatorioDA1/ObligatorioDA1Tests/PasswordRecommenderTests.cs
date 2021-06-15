using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using System.Collections.Generic;
using Domain.PasswordRecommender;

namespace DomainTests
{
    [TestClass]
    public class PasswordRecommenderTests
    {
        private UserManager _mockDomain;
        private User _testUser;

        private Category _trabajo;
        private Category _personal;

        private Password _testPassword1;
        private Password _testPassword2;

        private PasswordHistory _passwordHistories;

        private DataBreach _dataBreach1;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDomain = UserManager.Instance;

            _testUser = new User("Juana", "123456");
            _mockDomain.AddUser(_testUser);


            _trabajo = new Category("Trabajo");
            _personal = new Category("Personal");

            _testPassword1 = new Password
            {
                PasswordString = "111111111111111",
                Site = "www.ort.edu.uy",
                Username = "Matias Gonzalez",
                LastModification = DateTime.Today,
                Category = _trabajo,
                Notes = "cuenta universidad"
            };

            _testPassword2 = new Password
            {
                PasswordString = "Abcdef@1234567",
                Site = "www.twitch.tv",
                Username = "MatixitaM",
                LastModification = DateTime.Today,
                Category = _personal,
                Notes = "cuenta streaming"
            };

            _testUser.UserPasswords.AddPassword(_testPassword1);
            _testUser.UserPasswords.AddPassword(_testPassword2);

            _passwordHistories = new PasswordHistory()
            {
                Password = _testPassword1,
                BreachedPasswordString = "0ldPassw0rd1234"
            };

            List<PasswordHistory> fakePasswordHistories1 = new List<PasswordHistory>();
            fakePasswordHistories1.Add(_passwordHistories);

            _dataBreach1 = new DataBreach();
            _dataBreach1.PasswordBreaches = fakePasswordHistories1;

            _testUser.UserDataBreaches.AddDataBreach(_dataBreach1);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockDomain.Users.Clear();
        }

        [TestMethod]
        public void TestNotSafePasswordInPreviousDataBreach()
        {
            bool isSafe = PasswordRecommender.isASafePassword("0ldPassw0rd1234", _testUser);
            Assert.IsFalse(isSafe);
        }

        [TestMethod]
        public void TestNotSafePasswordStringAlreadyUsed()
        {
            bool isSafe = PasswordRecommender.isASafePassword("Abcdef@1234567", _testUser);
            Assert.IsFalse(isSafe);
        }

        [TestMethod]
        public void TestNotSafePasswordNotDarkorLightGreen()
        {
            bool isSafe = PasswordRecommender.isASafePassword("123456", _testUser);
            Assert.IsFalse(isSafe);
        }

        [TestMethod]
        public void TestSafePassword()
        {
            bool isSafe = PasswordRecommender.isASafePassword("Matias@Gonzalez123.com", _testUser);
            Assert.IsTrue(isSafe);
        }


    }
}
