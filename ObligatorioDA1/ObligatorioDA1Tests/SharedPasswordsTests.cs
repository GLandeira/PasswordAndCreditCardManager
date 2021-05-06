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

        private Password _sharedPassword;
        private Category _testCategory;

        public SharedPasswordsTests()
        {
            _testDomain = new Domain.Domain();
            PasswordSharer.Init(_testDomain);

            _testUserSharer = SetupSharer();

            _testUserSharee = new User(_shareeName, "password");

            _testDomain.AddUser(_testUserSharer);
            _testDomain.AddUser(_testUserSharee);
        }

        private User SetupSharer()
        {
            User sharer = new User(_sharerName, "password");

            _sharedPassword = new Password
            {
                PasswordString = "abcd1234",
                Site = "www.brilliantly.com",
                Username = "John Cage",
                LastModification = DateTime.Today,
                Category = _testCategory,
                Notes = "My Brilliantly Account."
            };
            _testCategory = new Category("TestCategory");
            _testUserSharer.AddCategory(_testCategory);
            _testUserSharer.UserPasswords.AddPassword(_sharedPassword);

            return sharer;
        }

        [TestMethod]
        public void SharedPasswordIsActuallySharedTest()
        {
            User sharerInDomain = _testDomain.GetUser(_sharerName);

            sharerInDomain.UserPasswords.SharePassword(_testUserSharee.Name, _sharedPassword);

            User shareeInDomain = _testDomain.GetUser(_shareeName);

            Assert.IsTrue(shareeInDomain.UserPasswords.Passwords.Any(pass => pass.Equals(_sharedPassword)));
        }

        [TestMethod]
        public void SharedPasswordHasRightCategoryTest()
        {
            
        }

        [TestMethod]
        public void SharedPasswordHasRightNamesTest()
        {

        }

        [TestMethod]
        public void UnsharingPasswordIsActuallyUnsharedTest()
        {

        }

        [TestMethod]
        public void UnsharedPasswordHasRightNamesTest()
        {

        }

        [TestMethod]
        public void ModifiedPasswordCascadesCorrectlyTest()
        {

        }

        [TestMethod]
        public void GetSharedPasswordHasRightAmountTest()
        {

        }
    }
}
