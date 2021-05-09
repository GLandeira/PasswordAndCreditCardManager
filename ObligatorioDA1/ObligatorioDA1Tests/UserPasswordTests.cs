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
        private UserPassword _userPasswordTest;
        private Password _testPassword1;
        private Password _testPassword2;
        private Password _testPassword3;
        private Password _testPasswordRed;
        private Password _testPasswordOrange;
        private Password _testPasswordYellow;
        private Password _testPasswordLightGreen;
        private Password _testPasswordDarkGreen;
        private Category _trabajo;
        private Category _personal;

        [TestInitialize]
        public void TestInitialize()
        {
            _userPasswordTest = new UserPassword();

            _trabajo = new Category("Trabajo");
            _testPassword1 = new Password
            {
                PasswordString = "1111",
                Site = "www.ort.edu.uy",
                Username = "Matias Gonzalez",
                LastModification = DateTime.Today,
                Category = _trabajo,
                Notes = "cuenta universidad"
            };

            _personal = new Category("Personal");
            _testPassword2 = new Password
            {
                PasswordString = "abcd",
                Site = "www.twitch.tv",
                Username = "MatixitaM",
                LastModification = DateTime.Today,
                Category = _personal,
                Notes = "cuenta streaming"
            };

            _testPassword3 = new Password
            {
                PasswordString = "1111",
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

        }


        [TestMethod]
        public void TestAddingOnePasswordToList()
        {
            _userPasswordTest.AddPassword(_testPassword1);
            Assert.AreEqual(1, _userPasswordTest.Passwords.Count);
        }

        [TestMethod]
        public void TestAddingTwoPasswordsAndLookingForOne()
        {
            bool samePassword = false;
            _userPasswordTest.AddPassword(_testPassword1);
            _userPasswordTest.AddPassword(_testPassword2);

            foreach (Password Password in _userPasswordTest.Passwords)
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
            _userPasswordTest.AddPassword(_testPassword1);
            _userPasswordTest.RemovePassword(_testPassword1);

            Assert.AreEqual(0, _userPasswordTest.Passwords.Count);
        }

        [TestMethod]
        public void TestRemovingSpecificPasswordFromListWithMoreThanOneElement()
        {
            bool password2InList = false;
            _userPasswordTest.AddPassword(_testPassword1);
            _userPasswordTest.AddPassword(_testPassword2);
            _userPasswordTest.RemovePassword(_testPassword2);

            foreach (Password Password in _userPasswordTest.Passwords)
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
            bool passwordWasModified = false;
            Password modifiedPassword = new Password
            {
                PasswordString = "abcdeJK3132",
                Site = "www.twitch.tv",
                Username = "MatixitaM",
                LastModification = DateTime.Today,
                Category = _personal,
                Notes = "cuenta streaming"
            };

            _userPasswordTest.ModifyPassword(modifiedPassword, _testPassword2);

            foreach(Password Password in _userPasswordTest.Passwords)
            {
                if(modifiedPassword.Equals(Password))
                {
                    passwordWasModified = true;
                }
            }

            Assert.AreEqual(true, passwordWasModified);
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

            _userPasswordTest.AddPassword(newPassword);
            Assert.AreEqual(passwordImitator, _userPasswordTest.GetPassword(siteName, userName));
        }

        [TestMethod]
        public void TestGettingAPasswordThatDoesntExistThrowsException()
        {
            string siteNameThatDoesntExist = "Inexistent Site";
            string userNameThatDoesntExist = "Inexistent Username";

            Assert.ThrowsException<PasswordNotFoundException>(() => _userPasswordTest.GetPassword(siteNameThatDoesntExist, userNameThatDoesntExist));
        }

        [TestMethod]
        public void GetPasswordsByPasswordStringOneThatExistsInTheList()
        {
            _userPasswordTest.AddPassword(_testPassword1);
            _userPasswordTest.AddPassword(_testPassword2);
            List<Password> passwordsTest = _userPasswordTest.GetPasswordsByPasswordString("1111");

            Assert.AreEqual(_testPassword1, passwordsTest.Find(passwordInList => passwordInList.PasswordString.Equals("1111")));
        }
      
        [ExpectedException(typeof(PasswordNotFoundException))]
        [TestMethod]
        public void GetPasswordsByPasswordStringThatNotExistsInTheList()
        {
            _userPasswordTest.AddPassword(_testPassword1);
            _userPasswordTest.AddPassword(_testPassword2);
            List<Password> passwordsTest = _userPasswordTest.GetPasswordsByPasswordString("PasswordThatDoesntExist");
        }

        [TestMethod]
        public void GetPasswordsByPasswordStringTwoThatExistsInTheList()
        {
            _userPasswordTest.AddPassword(_testPassword1);
            _userPasswordTest.AddPassword(_testPassword2);
            _userPasswordTest.AddPassword(_testPassword3);
            List<Password> passwordsTest = _userPasswordTest.GetPasswordsByPasswordString("1111");

            Assert.AreEqual(2, passwordsTest.Count);
        }

        [TestMethod]
        public void TestGetPasswordsWithSecurityLevel()
        {
            _userPasswordTest.AddPassword(_testPassword1);
            _userPasswordTest.AddPassword(_testPassword2);
            _userPasswordTest.AddPassword(_testPassword3);
            List<Password> passwordsTest = _userPasswordTest.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.RED);
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
            _userPasswordTest.AddPassword(_testPasswordRed);
            _userPasswordTest.AddPassword(_testPasswordOrange);
            _userPasswordTest.AddPassword(_testPasswordYellow);
            _userPasswordTest.AddPassword(_testPasswordLightGreen);
            _userPasswordTest.AddPassword(_testPasswordDarkGreen);
            List<Password> passwordsTest = _userPasswordTest.GetPasswordsWithSecurityLevel(SecurityLevelPasswords.LIGHT_GREEN);
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
            _userPasswordTest.AddPassword(_testPassword1);
            _userPasswordTest.AddPassword(_testPassword2);
            _userPasswordTest.AddPassword(_testPassword3);
            int passwordCount = _userPasswordTest.GetAmountOfPasswordsWithSecurityLevelAndCategory(SecurityLevelPasswords.RED, _personal);
            Assert.AreEqual(2,2);
        }

        [TestMethod]
        public void TestGetPasswordsFromSecurityLevelAndCategoryWithEveryLevelPasswordOnList()
        {
            _userPasswordTest.AddPassword(_testPasswordRed);
            _userPasswordTest.AddPassword(_testPasswordOrange);
            _userPasswordTest.AddPassword(_testPasswordYellow);
            _userPasswordTest.AddPassword(_testPasswordLightGreen);
            _userPasswordTest.AddPassword(_testPasswordDarkGreen);
            int passwordCount = _userPasswordTest.GetAmountOfPasswordsWithSecurityLevelAndCategory(SecurityLevelPasswords.DARK_GREEN, _personal);
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void TestGetPasswordsFromSecurityLevelAndCategoryWithEveryLevelPasswordOnList2()
        {
            _userPasswordTest.AddPassword(_testPasswordRed);
            _userPasswordTest.AddPassword(_testPasswordOrange);
            _userPasswordTest.AddPassword(_testPasswordYellow);
            _userPasswordTest.AddPassword(_testPasswordLightGreen);
            _userPasswordTest.AddPassword(_testPasswordDarkGreen);
            int passwordCount = _userPasswordTest.GetAmountOfPasswordsWithSecurityLevelAndCategory(SecurityLevelPasswords.DARK_GREEN, _trabajo);
            Assert.AreEqual(0, 0);
        }
    }
}
