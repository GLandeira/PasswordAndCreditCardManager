using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Exceptions;
using System.Collections.Generic;

namespace DomainTests
{
    [TestClass]
    public class SharedPasswordsTests
    {
        private Domain.UserManager _testDomain;

        private string _sharerName = "Sharer";
        private User _testUserSharer;
        private string _shareeNameOne = "ShareeOne";
        private User _testUserShareeOne;
        private string _shareeNameOneTwo = "ShareeTwo";
        private User _testUserShareeTwo;
        private string _shareeNameOneThree = "ShareeThree";
        private User _testUserShareeThree;

        private Password _sharedPassword;
        private Category _testCategory;

        public SharedPasswordsTests()
        {

            if(UserManager.Instance == null)
            {
                new UserManager();
            }
            _testDomain = UserManager.Instance;
            _testDomain.Users = new List<User>();
            _testUserSharer = SetupSharer();

            _testUserShareeOne = new User(_shareeNameOne, "password");
            _testUserShareeTwo = new User(_shareeNameOneTwo, "password");
            _testUserShareeThree = new User(_shareeNameOneThree, "password");

            _testDomain.AddUser(_testUserSharer);
            _testDomain.AddUser(_testUserShareeOne);
            _testDomain.AddUser(_testUserShareeTwo);
            _testDomain.AddUser(_testUserShareeThree);
        }

        private User SetupSharer()
        {
            User sharer = new User(_sharerName, "password");

            _testCategory = new Category("TestCategory");
            _sharedPassword = new Password
            {
                PasswordString = "abcd1234",
                Site = "www.brilliantly.com",
                Username = "John Cage",
                LastModification = DateTime.Today,
                Category = _testCategory,
                Notes = "My Brilliantly Account."
            };
            
            sharer.UserCategories.AddCategory(_testCategory);
            sharer.UserPasswords.AddPassword(_sharedPassword);

            return sharer;
        }

        [TestMethod]
        public void SharedPasswordIsActuallySharedTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);

            Assert.IsTrue(_testUserSharer.UserPasswords.Passwords.Any(pass => pass.Equals(_sharedPassword)));
        }

        [TestMethod]
        public void SharingAPasswordAlreadySharedThrowsExceptionTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);

            Assert.ThrowsException<PasswordAlreadySharedException>(() => _testUserSharer.UserPasswords.SharePassword(_testUserShareeOne, _sharedPassword));
        }

        [TestMethod]
        public void SharedPasswordHasRightCategoryTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);
            Password sharedPasswordInSharee = _testUserShareeOne.UserPasswords.GetPassword(_sharedPassword.Site, _sharedPassword.Username);

            Assert.AreEqual(UserCategory.SHARED_WITH_ME_CATEGORY, sharedPasswordInSharee.Category);
        }

        [TestMethod]
        public void SharedPasswordHasRightCategoryAfterRemovingAnotherPasswordTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserShareeTwo, _sharedPassword);
            _testUserSharer.UserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);
            
            Password sharedPasswordInSharee = _testUserShareeOne.UserPasswords.GetPassword(_sharedPassword.Site, _sharedPassword.Username);

            _testUserSharer.UserPasswords.StopSharingPassword(_testUserShareeTwo, _sharedPassword);

            Assert.AreEqual(UserCategory.SHARED_WITH_ME_CATEGORY, sharedPasswordInSharee.Category);
        }

        [TestMethod]
        public void SharedPasswordHasRightCategoryAfterModificationTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);

            Password modifiedPassword = new Password
            {
                PasswordID = _sharedPassword.PasswordID,
                PasswordString = "newPassword123",
                Site = "www.brilliantly.com",
                Username = "John Cage",
                LastModification = DateTime.Today,
                Category = _testCategory,
                Notes = "My Brilliantly Account."
            };

            _testUserSharer.UserPasswords.ModifyPassword(modifiedPassword, _sharedPassword);
            Password sharedPasswordInSharee = _testUserShareeOne.UserPasswords.GetPassword(_sharedPassword.Site, _sharedPassword.Username);

            Assert.AreEqual(UserCategory.SHARED_WITH_ME_CATEGORY, sharedPasswordInSharee.Category);
        }

        [TestMethod]
        public void SharedPasswordHasRightCategoryOnSharerTest()
        {
            Category oldCategory = (Category)_sharedPassword.Category;

            _testUserSharer.UserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);

            Assert.AreEqual(oldCategory, _sharedPassword.Category);
        }

        [TestMethod]
        public void OneSharedPasswordHasRightNamesTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);
            Password sharedPasswordInSharer = _testUserSharer.UserPasswords.GetPassword(_sharedPassword.Site, _sharedPassword.Username);

            Assert.IsTrue(sharedPasswordInSharer.UsersSharedWith.Contains(_testUserShareeOne));
        }

        [TestMethod]
        public void UnsharingPasswordIsActuallyUnsharedTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);

            _testUserSharer.UserPasswords.StopSharingPassword(_testUserShareeOne, _sharedPassword);
            UserPassword shareeUserPasswords = _testUserShareeOne.UserPasswords;

            Assert.IsFalse(shareeUserPasswords.Passwords.Contains(_sharedPassword));
        }

        [TestMethod]
        public void MultipleUnsharedPasswordsAreActuallyUnsharedTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);
            _testUserSharer.UserPasswords.SharePassword(_testUserShareeThree, _sharedPassword);

            _testUserSharer.UserPasswords.StopSharingPassword(_testUserShareeOne, _sharedPassword);
            _testUserSharer.UserPasswords.StopSharingPassword(_testUserShareeThree, _sharedPassword);
            UserPassword shareeOneUserPasswords = _testUserShareeOne.UserPasswords;
            UserPassword shareeTwoUserPasswords = _testUserShareeTwo.UserPasswords;

            Assert.IsFalse(shareeOneUserPasswords.Passwords.Contains(_sharedPassword));
            Assert.IsFalse(shareeTwoUserPasswords.Passwords.Contains(_sharedPassword));
        }

        [TestMethod]
        public void UnsharedPasswordHasRightNamesTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);

            _testUserSharer.UserPasswords.StopSharingPassword(_testUserShareeOne, _sharedPassword);

            Password sharedPasswordInSharer = _testUserSharer.UserPasswords.GetPassword(_sharedPassword.Site, _sharedPassword.Username);

            Assert.IsFalse(sharedPasswordInSharer.UsersSharedWith.Contains(_testUserShareeOne));
        }

        [TestMethod]
        public void ModifiedPasswordCascadesCorrectlyTest()
        {
            UserPassword sharerUserPasswords = _testUserSharer.UserPasswords;

            sharerUserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);

            Password modifiedPassword = (Password)_sharedPassword.Clone();
            modifiedPassword.PasswordString = "newPassword123";
            modifiedPassword.PasswordID = _sharedPassword.PasswordID;

            sharerUserPasswords.ModifyPassword(modifiedPassword, _sharedPassword);

            UserPassword shareeUserPasswords = _testUserShareeOne.UserPasswords;

            Assert.AreEqual(modifiedPassword.PasswordString, shareeUserPasswords.GetPassword(modifiedPassword.Site, modifiedPassword.Username).PasswordString);
        }

        [TestMethod]
        public void ModifiedPasswordCascadesCorrectlyWithMultipleChangesTest()
        {
            UserPassword sharerUserPasswords = _testUserSharer.UserPasswords;

            sharerUserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);
            sharerUserPasswords.SharePassword(_testUserShareeTwo, _sharedPassword);
            sharerUserPasswords.SharePassword(_testUserShareeThree, _sharedPassword);

            Password modifiedPassword = (Password)_sharedPassword.Clone();
            modifiedPassword.PasswordString = "newP%1as3";
            modifiedPassword.PasswordID = _sharedPassword.PasswordID;

            sharerUserPasswords.ModifyPassword(modifiedPassword, _sharedPassword);

            UserPassword shareeUserPasswords = _testUserShareeOne.UserPasswords;
            UserPassword shareeTwoUserPasswords = _testUserShareeTwo.UserPasswords;
            UserPassword shareeThreeUserPasswords = _testUserShareeThree.UserPasswords;

            Assert.AreEqual(modifiedPassword, shareeUserPasswords.GetPassword(modifiedPassword.Site, modifiedPassword.Username));
            Assert.AreEqual(modifiedPassword, shareeTwoUserPasswords.GetPassword(modifiedPassword.Site, modifiedPassword.Username));
            Assert.AreEqual(modifiedPassword, shareeThreeUserPasswords.GetPassword(modifiedPassword.Site, modifiedPassword.Username));
        }

        [TestMethod]
        public void ModifiedPasswordCascadesCorrectlyAfterDeletingOneTest()
        {
            UserPassword sharerUserPasswords = _testUserSharer.UserPasswords;

            sharerUserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);
            sharerUserPasswords.SharePassword(_testUserShareeTwo, _sharedPassword);
            sharerUserPasswords.SharePassword(_testUserShareeThree, _sharedPassword);

            sharerUserPasswords.StopSharingPassword(_testUserShareeThree, _sharedPassword);

            Password modifiedPassword = (Password)_sharedPassword.Clone();
            modifiedPassword.PasswordString = "newwfscqWTG";
            modifiedPassword.PasswordID = _sharedPassword.PasswordID;

            sharerUserPasswords.ModifyPassword(modifiedPassword, _sharedPassword);

            UserPassword shareeUserPasswords = _testUserShareeOne.UserPasswords;
            UserPassword shareeTwoUserPasswords = _testUserShareeTwo.UserPasswords;

            Assert.AreEqual(modifiedPassword, shareeUserPasswords.GetPassword(modifiedPassword.Site, modifiedPassword.Username));
            Assert.AreEqual(modifiedPassword, shareeTwoUserPasswords.GetPassword(modifiedPassword.Site, modifiedPassword.Username));
        }

        [TestMethod]
        public void GetSharedPasswordHasRightAmountTest()
        {
            UserPassword sharerUserPasswords = _testUserSharer.UserPasswords;

            sharerUserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);

            Password sharedPasswordSharer = sharerUserPasswords.GetPassword(_sharedPassword.Site, _sharedPassword.Username);

            Assert.AreEqual(1, sharedPasswordSharer.UsersSharedWith.Count);
        }

        [TestMethod]
        public void GetSharedPasswordHasRightMultipleAmountsTest()
        {
            UserPassword sharerUserPasswords = _testUserSharer.UserPasswords;

            sharerUserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);
            sharerUserPasswords.SharePassword(_testUserShareeTwo, _sharedPassword);
            sharerUserPasswords.SharePassword(_testUserShareeThree, _sharedPassword);

            Password sharedPasswordSharer = sharerUserPasswords.GetPassword(_sharedPassword.Site, _sharedPassword.Username);

            Assert.AreEqual(3, sharedPasswordSharer.UsersSharedWith.Count);
        }

        [TestMethod]
        public void GetSharedPasswordHasRightMultipleWithRemoveAmountsTest()
        {
            UserPassword sharerUserPasswords = _testUserSharer.UserPasswords;

            sharerUserPasswords.SharePassword(_testUserShareeOne, _sharedPassword);
            sharerUserPasswords.SharePassword(_testUserShareeTwo, _sharedPassword);
            sharerUserPasswords.SharePassword(_testUserShareeThree, _sharedPassword);

            sharerUserPasswords.StopSharingPassword(_testUserShareeTwo, _sharedPassword);

            Password sharedPasswordSharer = sharerUserPasswords.GetPassword(_sharedPassword.Site, _sharedPassword.Username);

            Assert.AreEqual(2, sharedPasswordSharer.UsersSharedWith.Count);
        }

    }
}
