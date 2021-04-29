using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;

namespace DomainTests
{
    [TestClass]
    public class UserPasswordTests
    {

        UserPassword userPasswordTest;
        Password testPassword1;
        Password testPassword2;
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



    }
}
