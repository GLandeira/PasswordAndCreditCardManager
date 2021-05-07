using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace DomainTests
{
    [TestClass]
    public class SharedPasswordsTests
    {
        private Domain.Domain _testDomain;

        private string _sharerName = "Sharer";
        private User _testUserSharer;
        private string _shareeName = "Sharee";
        private User _testUserSharee;
        private string _shareeNameTwo = "ShareeTwo";
        private User _testUserShareeTwo;
        private string _shareeNameThree = "ShareeThree";
        private User _testUserShareeThree;

        private Password _sharedPassword;
        private Category _testCategory;

        public SharedPasswordsTests()
        {
            _testDomain = new Domain.Domain();
            PasswordSharer.Init(_testDomain);

            _testUserSharer = SetupSharer();

            _testUserSharee = new User(_shareeName, "password");
            _testUserShareeTwo = new User(_shareeNameTwo, "password");
            _testUserShareeThree = new User(_shareeNameThree, "password");

            _testDomain.AddUser(_testUserSharer);
            _testDomain.AddUser(_testUserSharee);
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
            
            sharer.AddCategory(_testCategory);
            sharer.UserPasswords.AddPassword(_sharedPassword);

            return sharer;
        }

        [TestMethod]
        public void SharedPasswordIsActuallySharedTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserSharee, _sharedPassword);

            Assert.IsTrue(_testUserSharer.UserPasswords.Passwords.Any(pass => pass.Equals(_sharedPassword)));
        }

        [TestMethod]
        public void SharingAPasswordAlreadySharedThrowsExceptionTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserSharee, _sharedPassword);

            Assert.ThrowsException<PasswordAlreadySharedException>(_testUserSharer.UserPasswords.SharePassword(_testUserSharee, _sharedPassword));
        }

        [TestMethod]
        public void SharedPasswordHasRightCategoryTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserSharee, _sharedPassword);
            Password sharedPasswordInSharee = _testUserSharee.UserPasswords.GetPassword(_sharedPassword.Site, _sharedPassword.Username);

            Assert.AreEqual(User.SHARED_WITH_ME_CATEGORY, sharedPasswordInSharee.Category);
        }

        [TestMethod]
        public void SharedPasswordHasRightCategoryAfterModificationTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserSharee, _sharedPassword);

            Password modifiedPassword = (Password)_sharedPassword.Clone();
            modifiedPassword.PasswordString = "newPassword123";

            _testUserSharer.UserPasswords.ModifyPassword(modifiedPassword, _sharedPassword);
            Password sharedPasswordInSharee = _testUserSharee.UserPasswords.GetPassword(_sharedPassword.Site, _sharedPassword.Username);

            Assert.AreEqual(User.SHARED_WITH_ME_CATEGORY, sharedPasswordInSharee.Category);
        }

        [TestMethod]
        public void SharedPasswordHasRightCategoryOnSharerTest()
        {
            Category oldCategory = (Category)_sharedPassword.Category.Clone();

            _testUserSharer.UserPasswords.SharePassword(_testUserSharee, _sharedPassword);

            Assert.AreEqual(oldCategory, _sharedPassword.Category);
        }

        [TestMethod]
        public void OneSharedPasswordHasRightNamesTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserSharee, _sharedPassword);
            Password sharedPasswordInSharer = _testUserSharer.UserPasswords.GetPassword(_sharedPassword.Site, _sharedPassword.Username);

            Assert.IsTrue(sharedPasswordInSharer.UsersSharedWith.Contains(_shareeName));
        }

        [TestMethod]
        public void UnsharingPasswordIsActuallyUnsharedTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserSharee, _sharedPassword);

            _testUserSharer.UserPasswords.StopSharingPassword(_testUserSharee, _sharedPassword);
            UserPassword shareeUserPasswords = _testUserSharee.UserPasswords;

            Assert.IsFalse(shareeUserPasswords.Passwords.Contains(_sharedPassword));
        }

        [TestMethod]
        public void UnsharedPasswordHasRightNamesTest()
        {
            _testUserSharer.UserPasswords.SharePassword(_testUserSharee, _sharedPassword);

            _testUserSharer.UserPasswords.StopSharingPassword(_testUserSharee, _sharedPassword);

            Password sharedPasswordInSharer = _testUserSharer.UserPasswords.GetPassword(_sharedPassword.Site, _sharedPassword.Username);

            Assert.IsFalse(sharedPasswordInSharer.UsersSharedWith.Contains(_shareeName));
        }


        [TestMethod]
        public void ModifiedPasswordCascadesCorrectlyTest()
        {
            UserPassword sharerUserPasswords = _testUserSharer.UserPasswords;

            sharerUserPasswords.SharePassword(_testUserSharee, _sharedPassword);

            Password modifiedPassword = (Password)_sharedPassword.Clone();
            modifiedPassword.PasswordString = "newPassword123";

            sharerUserPasswords.ModifyPassword(modifiedPassword, _sharedPassword);

            UserPassword shareeUserPasswords = _testUserSharee.UserPasswords;

            Assert.AreEqual(modifiedPassword, shareeUserPasswords.GetPassword(modifiedPassword.Site, modifiedPassword.Username));
        }

        [TestMethod]
        public void ModifiedPasswordCascadesCorrectlyWithMultipleChangesTest()
        {
            UserPassword sharerUserPasswords = _testUserSharer.UserPasswords;

            sharerUserPasswords.SharePassword(_testUserSharee, _sharedPassword);
            sharerUserPasswords.SharePassword(_testUserShareeTwo, _sharedPassword);
            sharerUserPasswords.SharePassword(_testUserShareeThree, _sharedPassword);

            Password modifiedPassword = (Password)_sharedPassword.Clone();
            modifiedPassword.PasswordString = "newP%1as3";

            sharerUserPasswords.ModifyPassword(modifiedPassword, _sharedPassword);

            UserPassword shareeUserPasswords = _testUserSharee.UserPasswords;
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

            sharerUserPasswords.SharePassword(_testUserSharee, _sharedPassword);
            sharerUserPasswords.SharePassword(_testUserShareeTwo, _sharedPassword);
            sharerUserPasswords.SharePassword(_testUserShareeThree, _sharedPassword);

            sharerUserPasswords.StopSharingPassword(_testUserShareeThree, _sharedPassword);

            Password modifiedPassword = (Password)_sharedPassword.Clone();
            modifiedPassword.PasswordString = "newwfscqWTG";

            sharerUserPasswords.ModifyPassword(modifiedPassword, _sharedPassword);

            UserPassword shareeUserPasswords = _testUserSharee.UserPasswords;
            UserPassword shareeTwoUserPasswords = _testUserShareeTwo.UserPasswords;

            Assert.AreEqual(modifiedPassword, shareeUserPasswords.GetPassword(modifiedPassword.Site, modifiedPassword.Username));
            Assert.AreEqual(modifiedPassword, shareeTwoUserPasswords.GetPassword(modifiedPassword.Site, modifiedPassword.Username));
        }

        [TestMethod]
        public void GetSharedPasswordHasRightAmountTest()
        {
            UserPassword sharerUserPasswords = _testUserSharer.UserPasswords;

            sharerUserPasswords.SharePassword(_testUserSharee, _sharedPassword);

            Password sharedPasswordSharee = _testUserSharee.UserPasswords.GetPassword(_sharedPassword.Site, _sharedPassword.Username);

            Assert.AreEqual(1, sharedPasswordSharee.UsersSharedWith.Count);
        }
    }
}
