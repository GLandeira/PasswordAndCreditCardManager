using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using System.Collections.Generic;
using Domain.Exceptions;

namespace DomainTests
{
    [TestClass]
    public class UserPasswordTests
    {

        UserPassword userPasswordTest;
        Password testPassword1;
        Password testPassword2;
        Password testPassword3;
        Category trabajo;
        Category personal;

        [TestInitialize]
        public void TestInitialize()
        {
            userPasswordTest = new UserPassword();

            Category trabajo = new Category("trabajo");
            testPassword1 = new Password
            {
                PasswordString = "1111",
                Site = "www.ort.edu.uy",
                Username = "Matias Gonzalez",
                LastModification = DateTime.Today,
                Category = trabajo,
                Notes = "cuenta universidad"
            };

            Category personal = new Category("personal");
            testPassword2 = new Password
            {
                PasswordString = "abcd",
                Site = "www.twitch.tv",
                Username = "MatixitaM",
                LastModification = DateTime.Today,
                Category = personal,
                Notes = "cuenta streaming"
            };

            testPassword3 = new Password
            {
                PasswordString = "1111",
                Site = "www.twitch.tv",
                Username = "GLandeira",
                LastModification = DateTime.Today,
                Category = personal,
                Notes = "cuenta streaming 2"
            };

        }


        [TestMethod]
        public void TestAddingOnePasswordToList()
        {
            userPasswordTest.AddPassword(testPassword1);
            Assert.AreEqual(1, userPasswordTest.Passwords.Count);
        }

        [TestMethod]
        public void TestAddingTwoPasswordsAndLookingForOne()
        {
            bool samePassword = false;
            userPasswordTest.AddPassword(testPassword1);
            userPasswordTest.AddPassword(testPassword2);

            foreach (Password Password in userPasswordTest.Passwords)
            {
                if (Password.Equals(testPassword1))
                {
                    samePassword = true;
                }
            }
            Assert.AreEqual(true, samePassword);
        }

        [TestMethod]
        public void TestRemovingOnlyPasswordInList()
        {
            userPasswordTest.AddPassword(testPassword1);
            userPasswordTest.RemovePassword(testPassword1);

            Assert.AreEqual(0, userPasswordTest.Passwords.Count);
        }

        [TestMethod]
        public void TestRemovingSpecificPasswordFromListWithMoreThanOneElement()
        {
            bool password2InList = false;
            userPasswordTest.AddPassword(testPassword1);
            userPasswordTest.AddPassword(testPassword2);
            userPasswordTest.RemovePassword(testPassword2);

            foreach (Password Password in userPasswordTest.Passwords)
            {
                if (Password.Equals(testPassword2))
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
                Category = personal,
                Notes = "cuenta streaming"
            };

            userPasswordTest.ModifyPassword(modifiedPassword, testPassword2);

            foreach(Password Password in userPasswordTest.Passwords)
            {
                if(modifiedPassword.Equals(Password))
                {
                    passwordWasModified = true;
                }
            }

            Assert.AreEqual(true, passwordWasModified);
        }

        [TestMethod]
        public void GetPasswordsByPasswordStringOneThatExistsInTheList()
        {
            userPasswordTest.AddPassword(testPassword1);
            userPasswordTest.AddPassword(testPassword2);
            List<Password> passwordsTest = userPasswordTest.GetPasswordsByPasswordString("1111");

            Assert.AreEqual(testPassword1, passwordsTest.Find(passwordInList => passwordInList.PasswordString.Equals("1111")));
        }

        [ExpectedException(typeof(PasswordNotFoundException))]
        [TestMethod]
        public void GetPasswordsByPasswordStringThatNotExistsInTheList()
        {
            userPasswordTest.AddPassword(testPassword1);
            userPasswordTest.AddPassword(testPassword2);
            List<Password> passwordsTest = userPasswordTest.GetPasswordsByPasswordString("PasswordThatDoesntExist");
        }

        [TestMethod]
        public void GetPasswordsByPasswordStringTwoThatExistsInTheList()
        {
            userPasswordTest.AddPassword(testPassword1);
            userPasswordTest.AddPassword(testPassword2);
            userPasswordTest.AddPassword(testPassword3);
            List<Password> passwordsTest = userPasswordTest.GetPasswordsByPasswordString("1111");

            Assert.AreEqual(2, passwordsTest.Count);
        }
    }
}
