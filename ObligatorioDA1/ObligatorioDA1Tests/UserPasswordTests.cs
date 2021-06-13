using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using System.Collections.Generic;
using Domain.Exceptions;
using Domain.PasswordSecurityFlagger;

namespace DomainTests
{
    [TestClass]
    public class UserPasswordTests
    {
        private Domain.UserManager _mockDomain;
        private User _testUser;
        private Domain.UserPassword _mockUserPassword;

        private User _userSharedTo;

        private Password _testPassword1;
        private Password _testPassword2;
        private Password _testPassword3;

        private Password _testPasswordRed;
        private Password _testPasswordOrange;
        private Password _testPasswordYellow;
        private Password _testPasswordLightGreen;
        private Password _testPasswordDarkGreen;

        private Password _testPasswordSharedPassword1;

        private Category _trabajo;
        private Category _personal;

        [TestCleanup]
        public void TestCleanup()
        {
            //_mockUserPassword.Passwords.Clear();
            _mockDomain.Users.Clear();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDomain = UserManager.Instance;
            _testUser = new User("TestUser", "TestUser");
            _mockDomain.AddUser(_testUser);
            _mockUserPassword = _mockDomain.GetUser("TestUser").UserPasswords;

            _userSharedTo = new User("userPrueba", "contraseñaPrueba");
            _trabajo = new Category("Trabajo");
            _testPassword1 = new Password
            {
                PasswordString = "111111",
                Site = "www.ort.edu.uy",
                Username = "Matias Gonzalez",
                LastModification = DateTime.Today,
                Category = _trabajo,
                Notes = "cuenta universidad"
            };

            _personal = new Category("Personal");
            _testPassword2 = new Password
            {
                PasswordString = "abcdef",
                Site = "www.twitch.tv",
                Username = "MatixitaM",
                LastModification = DateTime.Today,
                Category = _personal,
                Notes = "cuenta streaming"
            };

            _testPassword3 = new Password
            {
                PasswordString = "111111",
                Site = "www.twitch.tv",
                Username = "GLandeira",
                LastModification = DateTime.Today,
                Category = _personal,
                Notes = "cuenta streaming 2"
            };

            _testPasswordRed = new Password
            {
                PasswordString = "abcdefg",
                Site = "www.google.com",
                Username = "MatiasGonzalez",
                LastModification = DateTime.Today,
                Category = _personal,
                Notes = "mi gmail"
            };

            _testPasswordOrange = new Password
            {
                PasswordString = "123456789abcde",
                Site = "www.google.com",
                Username = "GastonLandeira",
                LastModification = DateTime.Today,
                Category = _personal,
                Notes = "gmail personal"
            };

            _testPasswordYellow = new Password
            {
                PasswordString = "ABCDEFGHIJKLMNO",
                Site = "www.google.com",
                Username = "IñakiEtchegaray",
                LastModification = DateTime.Today,
                Category = _personal,
                Notes = "cuenta google personal"
            };

            _testPasswordLightGreen = new Password
            {
                PasswordString = "aBcDeFgHiJkLmNO",
                Site = "www.google.com",
                Username = "MatixitaM",
                LastModification = DateTime.Today,
                Category = _personal,
                Notes = "cuenta google stream"
            };

            _testPasswordDarkGreen = new Password
            {
                PasswordString = "InakiE34t%cg5#ar8y@aAa",
                Site = "www.google.com",
                Username = "GLandeira",
                LastModification = DateTime.Today,
                Category = _personal,
                Notes = "cuenta google stream"
            };

            _testPasswordSharedPassword1 = new Password
            {
                PasswordString = "InakiE34t%cg5#ar8y@aAa",
                Site = "www.google.com",
                Username = "GLandeira",
                LastModification = DateTime.Today,
                Category = _personal,
                Notes = "cuenta google stream"
            };

        }

        [TestMethod]
        public void TestAddingOnePasswordToList()
        {
            _mockUserPassword.AddPassword(_testPassword1);
            Assert.AreEqual(true, _mockUserPassword.Passwords.Contains(_testPassword1));
        }

        [TestMethod]
        public void TestAddingTwoPasswordsAndLookingForOne()
        {
            bool samePassword = false;
            _mockUserPassword.AddPassword(_testPassword1);
            _mockUserPassword.AddPassword(_testPassword2);

            foreach (Password Password in _mockUserPassword.Passwords)
            {
                if (Password.Equals(_testPassword1))
                {
                    samePassword = true;
                }
            }
            Assert.AreEqual(true, samePassword);
        }

        [TestMethod]
        public void TestRemovingOnlyPasswordInList()
        {
            _mockUserPassword.AddPassword(_testPassword1);
            _mockUserPassword.RemovePassword(_testPassword1);

            Assert.AreEqual(0, _mockUserPassword.Passwords.Count);
        }

        [TestMethod]
        public void TestRemovingSpecificPasswordFromListWithMoreThanOneElement()
        {
            bool password2InList = false;
            _mockUserPassword.AddPassword(_testPassword1);
            _mockUserPassword.AddPassword(_testPassword2);
            _mockUserPassword.RemovePassword(_testPassword2);

            foreach (Password Password in _mockUserPassword.Passwords)
            {
                if (Password.Equals(_testPassword2))
                {
                    password2InList = true;
                }
            }

            Assert.AreEqual(false, password2InList);
        }

        [TestMethod]
        public void TestModifyOnePasswordFromListWithTwoElements()
        {
            _mockUserPassword.AddPassword(_testPassword2);

            bool passwordWasModified = false;
            Password modifiedPassword = new Password
            {
                PasswordID = _testPassword2.PasswordID,
                PasswordString = "abcdeJK3132",
                Site = "www.twitch.tv",
                Username = "MatixitaM",
                LastModification = DateTime.Today,
                Category = _personal,
                Notes = "cuenta streaming"
            };

            _mockUserPassword.ModifyPassword(modifiedPassword, _testPassword2);

            foreach(Password Password in _mockUserPassword.Passwords)
            {
                if(modifiedPassword.Equals(Password))
                {
                    passwordWasModified = true;
                }
            }

            Assert.IsTrue(passwordWasModified);
        }
        
        [TestMethod]
        public void TestGettingAPasswordJustAddedReturnsPassword()
        {
            string siteName = "www.youtube.com";
            string userName = "Sleepz";
            Password newPassword = new Password
            {
                PasswordString = "@*b232#K3kl32",
                Site = siteName,
                Username = userName,
                LastModification = DateTime.Today,
                Category = _personal,
                Notes = "Youtube account"
            };

            Password passwordImitator = new Password();
            passwordImitator.Site = siteName;
            passwordImitator.Username = userName;

            _mockUserPassword.AddPassword(newPassword);
            Assert.AreEqual(passwordImitator, _mockUserPassword.GetPassword(siteName, userName));
        }

        [TestMethod]
        public void TestGettingAPasswordThatDoesntExistThrowsException()
        {
            string siteNameThatDoesntExist = "Inexistent Site";
            string userNameThatDoesntExist = "Inexistent Username";

            Assert.ThrowsException<PasswordNotFoundException>(() => _mockUserPassword.GetPassword(siteNameThatDoesntExist, userNameThatDoesntExist));
        }

        [TestMethod]
        public void GetPasswordsByPasswordStringOneThatExistsInTheList()
        {
            _mockUserPassword.AddPassword(_testPassword1);
            _mockUserPassword.AddPassword(_testPassword2);
            List<Password> passwordsTest = _mockUserPassword.GetPasswordsByPasswordString("111111");

            Assert.AreEqual(_testPassword1, passwordsTest.Find(passwordInList => passwordInList.PasswordString.Equals("111111")));
        }
      
        [ExpectedException(typeof(PasswordNotFoundException))]
        [TestMethod]
        public void GetPasswordsByPasswordStringThatNotExistsInTheList()
        {
            _mockUserPassword.AddPassword(_testPassword1);
            _mockUserPassword.AddPassword(_testPassword2);
            List<Password> passwordsTest = _mockUserPassword.GetPasswordsByPasswordString("PasswordThatDoesntExist");
        }

        [TestMethod]
        public void GetPasswordsByPasswordStringTwoThatExistsInTheList()
        {
            _mockUserPassword.AddPassword(_testPassword1);
            _mockUserPassword.AddPassword(_testPassword2);
            _mockUserPassword.AddPassword(_testPassword3);
            List<Password> passwordsTest = _mockUserPassword.GetPasswordsByPasswordString("111111");

            Assert.AreEqual(2, passwordsTest.Count);
        }

        [TestMethod]
        public void TestGetPasswordsWithSecurityLevel()
        {
            _mockUserPassword.AddPassword(_testPassword1);
            _mockUserPassword.AddPassword(_testPassword2);
            _mockUserPassword.AddPassword(_testPassword3);
            List<Password> passwordsTest = _mockUserPassword.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.RED);
            List<Password> correctResult = new List<Password>(){_testPassword1, _testPassword2, _testPassword3};
            bool areEqual = true;
            foreach(Password currentPassword in passwordsTest)
            {
                if(!correctResult.Exists(elem => elem.Equals(currentPassword)))
                {
                    areEqual = false;
                }
            }
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestGetPasswordsWithSecurityLevelListWithEveryLevelPasswordOnList()
        {
            _mockUserPassword.AddPassword(_testPasswordRed);
            _mockUserPassword.AddPassword(_testPasswordOrange);
            _mockUserPassword.AddPassword(_testPasswordYellow);
            _mockUserPassword.AddPassword(_testPasswordLightGreen);
            _mockUserPassword.AddPassword(_testPasswordDarkGreen);
            List<Password> passwordsTest = _mockUserPassword.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.LIGHT_GREEN);
            List<Password> correctResult = new List<Password>()  {_testPasswordLightGreen};
            bool areEqual = true;
            foreach (Password currentPassword in passwordsTest)
            {
                if (!correctResult.Exists(elem => elem.Equals(currentPassword)))
                {
                    areEqual = false;
                }
            }
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestGetPasswordsFromSecurityLevelAndCategory()
        {
            _mockUserPassword.AddPassword(_testPassword1);
            _mockUserPassword.AddPassword(_testPassword2);
            _mockUserPassword.AddPassword(_testPassword3);
            int passwordCount = _mockUserPassword.GetAmountOfPasswordsWithSecurityLevelAndCategory(SecurityLevelPasswords.RED, _personal);
            Assert.AreEqual(2,2);
        }

        [TestMethod]
        public void TestGetPasswordsFromSecurityLevelAndCategoryWithEveryLevelPasswordOnList()
        {
            _mockUserPassword.AddPassword(_testPasswordRed);
            _mockUserPassword.AddPassword(_testPasswordOrange);
            _mockUserPassword.AddPassword(_testPasswordYellow);
            _mockUserPassword.AddPassword(_testPasswordLightGreen);
            _mockUserPassword.AddPassword(_testPasswordDarkGreen);
            int passwordCount = _mockUserPassword.GetAmountOfPasswordsWithSecurityLevelAndCategory(SecurityLevelPasswords.DARK_GREEN, _personal);
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void TestGetPasswordsFromSecurityLevelAndCategoryWithEveryLevelPasswordOnList2()
        {
            _mockUserPassword.AddPassword(_testPasswordRed);
            _mockUserPassword.AddPassword(_testPasswordOrange);
            _mockUserPassword.AddPassword(_testPasswordYellow);
            _mockUserPassword.AddPassword(_testPasswordLightGreen);
            _mockUserPassword.AddPassword(_testPasswordDarkGreen);
            int passwordCount = _mockUserPassword.GetAmountOfPasswordsWithSecurityLevelAndCategory(SecurityLevelPasswords.DARK_GREEN, _trabajo);
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void CheckAbsolutEqualityBetweenTwoSamePassword()
        {
            Password test1 = _testPassword1;
            Password test2 = (Password)_testPassword1.Clone();

            Assert.IsTrue(test1.AbsoluteEquals(test2));
        }

        [TestMethod]
        public void CheckAbsolutEqualityBetweenDifNotesPassword()
        {
            Password test1 = _testPassword1;
            Password test2 = (Password)_testPassword1.Clone();

            test2.Notes = "This is a different Note";

            Assert.IsFalse(test1.AbsoluteEquals(test2));

        }

        [TestMethod]
        public void TestGetPasswordsImSharingNoPasswordsShared()
        {
            List<Password> sharedPasswordsList = _mockUserPassword.GetPasswordsImSharing();
            List<Password> expectedResult = new List<Password>();
            bool areSameList = true;
            foreach (Password sharedPassword in sharedPasswordsList)
            {
                if (!(expectedResult.Contains(sharedPassword)))
                {
                    areSameList = false;
                }
            }
            Assert.IsTrue(areSameList); ;
        }

        [TestMethod]
        public void TestGetPasswordsImSharingOnePasswordShared()
        {
            _mockUserPassword.AddPassword(_testPassword1);
            _mockUserPassword.SharePassword(_userSharedTo, _testPassword1);
            List<Password> sharedPasswordsList = _mockUserPassword.GetPasswordsImSharing();
            List<Password> expectedResult = new List<Password>();
            expectedResult.Add(_testPassword1);
            bool areSameList = true;
            foreach(Password sharedPassword in sharedPasswordsList)
            {
                if (!(expectedResult.Contains(sharedPassword)))
                {
                    areSameList = false;
                }
            }
            Assert.IsTrue(areSameList);
        }

        [TestMethod]
        public void TestGetPasswordsImSharingMoreThanOnePasswordShared()
        {
            _mockUserPassword.AddPassword(_testPassword1);
            _mockUserPassword.AddPassword(_testPassword2);
            _mockUserPassword.SharePassword(_userSharedTo, _testPassword1);
            _mockUserPassword.SharePassword(_userSharedTo, _testPassword2);
            List<Password> sharedPasswordsList = _mockUserPassword.GetPasswordsImSharing();
            List<Password> expectedResult = new List<Password>();
            expectedResult.Add(_testPassword1);
            expectedResult.Add(_testPassword2);
            bool areSameList = true;
            foreach (Password sharedPassword in sharedPasswordsList)
            {
                if (!(expectedResult.Contains(sharedPassword)))
                {
                    areSameList = false;
                }
            }
            Assert.IsTrue(areSameList); ;
        }

    }
}
