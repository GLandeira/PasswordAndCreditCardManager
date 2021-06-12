using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;

namespace RepositoryTests
{
    [TestClass]
    public class PasswordDataAccessTests
    {
        private UserDataAccess _userDataAccess;
        private PasswordDataAccess _passwordDataAccess;
        private CategoryDataAccess _categoryDataAccess;

        private User _testUser;
        private Password _testPassword1;
        private Password _testPassword2;
        private Category _testCategory1;
        private Category _testCategory2;

        public PasswordDataAccessTests()
        {
            _passwordDataAccess = new PasswordDataAccess();
            _categoryDataAccess = new CategoryDataAccess();
            _userDataAccess = new UserDataAccess();

            _testUser = new User("Juan", "123456");
            int id = _userDataAccess.Add(_testUser);
            _testUser.UserID = id;

            _testCategory1 = new Category("Escuela");
            _testCategory1.UserCategory = _testUser.UserCategories;
            _testCategory2 = new Category("Universidade");
            _testCategory2.UserCategory = _testUser.UserCategories;

            _testPassword1 = new Password
            {
                PasswordString = "111111",
                Site = "www.ort.edu.uy",
                Username = "Matias Gonzalez",
                LastModification = DateTime.Today,
                Notes = "cuenta universidad"
            };
            _testPassword1.UserPassword = _testUser.UserPasswords;
            _testPassword2 = new Password
            {
                PasswordString = "111111",
                Site = "www.twitch.tv",
                Username = "GLandeira",
                LastModification = DateTime.Today,
                Notes = "cuenta streaming 2"
            };
            _testPassword2.UserPassword = _testUser.UserPasswords;

            _categoryDataAccess.Add(_testCategory1);
            _categoryDataAccess.Add(_testCategory2);

            _testPassword1.Category = _testCategory1;
            _testPassword2.Category = _testCategory2;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _userDataAccess.Clear();
        }

        [TestMethod]
        public void AddOnePasswordTest()
        {
            
            _passwordDataAccess.Add(_testPassword1);

            Assert.AreEqual(1, _passwordDataAccess.GetAll().ToList().Count);
        }

        [TestMethod]
        public void AddTwoPasswordTest()
        {

            _passwordDataAccess.Add(_testPassword1);
            _passwordDataAccess.Add(_testPassword2);

            Assert.AreEqual(2, _passwordDataAccess.GetAll().ToList().Count);
        }

        [TestMethod]
        public void GetPasswordsTest()
        {
            int id = _passwordDataAccess.Add(_testPassword1);
            _passwordDataAccess.Add(_testPassword2);

            Assert.AreEqual(_testPassword1.PasswordID, _passwordDataAccess.Get(id).PasswordID);
        }
    }
}


      