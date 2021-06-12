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

        private User _testUserMain;
        private User _testUser1;
        private User _testUser2;
        private Password _testPassword1;
        private Password _testPassword2;
        private Category _testCategory1;
        private Category _testCategory2;

        public PasswordDataAccessTests()
        {
            _passwordDataAccess = new PasswordDataAccess();
            _categoryDataAccess = new CategoryDataAccess();
            _userDataAccess = new UserDataAccess();

            _testUserMain = new User("Gaston", "123456");
            int id = _userDataAccess.Add(_testUserMain);
            _testUserMain.UserID = id;

            _testUser1 = new User("Matias", "BambU");
            int id1 = _userDataAccess.Add(_testUser1);
            _testUser1.UserID = id1;

            _testUser2 = new User("Inaki", "milis");
            int id2 = _userDataAccess.Add(_testUser2);
            _testUser2.UserID = id2;

            _testCategory1 = new Category("Escuela");
            _testCategory1.UserCategory = _testUserMain.UserCategories;
            _testCategory2 = new Category("Universidade");
            _testCategory2.UserCategory = _testUserMain.UserCategories;

            _testPassword1 = new Password
            {
                PasswordString = "111@#sasddawdq111",
                Site = "www.ort.edu.uy",
                Username = "Matias Gonzalez",
                LastModification = DateTime.Today,
                Notes = "cuenta universidad"
            };
            _testPassword1.UserPassword = _testUserMain.UserPasswords;
            _testPassword2 = new Password
            {
                PasswordString = "111111",
                Site = "www.twitch.tv",
                Username = "GLandeira",
                LastModification = DateTime.Today,
                Notes = "cuenta streaming 2"
            };
            _testPassword2.UserPassword = _testUserMain.UserPasswords;

            _categoryDataAccess.Add(_testCategory1);
            _categoryDataAccess.Add(_testCategory2);

            _testPassword1.Category = _testCategory1;
            _testPassword2.Category = _testCategory2;

            //_testPassword1.UsersSharedWith.Add(_testUser1);
            //_testPassword1.UsersSharedWith.Add(_testUser2);
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
        public void DeleteAPasswordTest()
        {
            int id = _passwordDataAccess.Add(_testPassword1);

            _passwordDataAccess.Delete(_testPassword1);

            Assert.IsFalse(_passwordDataAccess.GetAll().Any(c => c.PasswordID == id));
        }

        [TestMethod]
        public void DeleteAllPasswordsTest()
        {
            _passwordDataAccess.Add(_testPassword1);
            _passwordDataAccess.Add(_testPassword2);

            _passwordDataAccess.Delete(_testPassword1);
            _passwordDataAccess.Delete(_testPassword2);

            Assert.AreEqual(0, _passwordDataAccess.GetAll().Count());
        }

        [TestMethod]
        public void GetPasswordTest()
        {
            int id = _passwordDataAccess.Add(_testPassword1);
            _passwordDataAccess.Add(_testPassword2);

            Assert.AreEqual(_testPassword1.PasswordID, _passwordDataAccess.Get(id).PasswordID);
        }

        [TestMethod]
        public void GetPasswordTestCheckPrimitiveValuesAndID()
        {
            int id = _passwordDataAccess.Add(_testPassword1);

            Assert.IsTrue(_testPassword1.AbsoluteEquals(_passwordDataAccess.Get(id)));
        }

        [TestMethod]
        public void GetPasswordTestCheckSecurityLevelValue()
        {
            int id = _passwordDataAccess.Add(_testPassword1);

            Assert.AreEqual(_testPassword1.SecurityLevel, _passwordDataAccess.Get(id).SecurityLevel);
        }

        [TestMethod]
        public void GetPasswordTestCheckCategoryValue()
        {
            int id = _passwordDataAccess.Add(_testPassword1);

            Assert.AreEqual(_testPassword1.Category, _passwordDataAccess.Get(id).Category);
        }

        [TestMethod]
        public void GetPasswordTestCheckUsersSharedWithValue()
        {
            int id = _passwordDataAccess.Add(_testPassword1);

            Assert.AreEqual(_testPassword1.UsersSharedWith, _passwordDataAccess.Get(id).UsersSharedWith);
        }

        [TestMethod]
        public void ModifyAPasswordCheckPrimitives()
        {
            int id = _passwordDataAccess.Add(_testPassword1);
            Password _testPassword = new Password
            {
                PasswordID = id,
                PasswordString = "passwordChanged",
                Site = "siteChanged.com",
                Username = "UsernameChanged",
                LastModification = DateTime.Today,
                Notes = "NoteChanged"
            };
            _testPassword.Category = _testCategory1;

            _passwordDataAccess.Modify(_testPassword);

            Assert.IsTrue(_testPassword.AbsoluteEquals(_passwordDataAccess.Get(id)));
        }

        [TestMethod]
        public void ModifyAPasswordPasswordStringCheckSecurityLevel()
        {
            int id = _passwordDataAccess.Add(_testPassword1);
            Password _testPassword = new Password
            {
                PasswordID = id,
                PasswordString = "12345",
                Site = "www.ort.edu.uy",
                Username = "Matias Gonzalez",
                LastModification = DateTime.Today,
                Notes = "cuenta universidad"
            };
            _testPassword.Category = _testCategory1;

            _passwordDataAccess.Modify(_testPassword);

            Assert.AreEqual(_testPassword.SecurityLevel, _passwordDataAccess.Get(id).SecurityLevel);
        }

        [TestMethod]
        public void ModifyAPasswordCheckCategory()
        {
            int id = _passwordDataAccess.Add(_testPassword1);
            Password _testPassword = new Password
            {
                PasswordID = id,
                PasswordString = "111@#sasddawdq111",
                Site = "www.ort.edu.uy",
                Username = "Matias Gonzalez",
                LastModification = DateTime.Today,
                Notes = "cuenta universidad"
            };
            _testPassword.Category = _testCategory2;

            _passwordDataAccess.Modify(_testPassword);

            Assert.AreEqual(_testPassword.Category, _passwordDataAccess.Get(id).Category);
        }

        [TestMethod]
        public void ModifyAPasswordCheckUsersSharedWith()
        {
            int id = _passwordDataAccess.Add(_testPassword1);
            Password _testPassword = new Password
            {
                PasswordID = id,
                PasswordString = "111@#sasddawdq111",
                Site = "www.ort.edu.uy",
                Username = "Matias Gonzalez",
                LastModification = DateTime.Today,
                Notes = "cuenta universidad"
            };
            _testPassword.Category = _testCategory1;

            _passwordDataAccess.Modify(_testPassword);

            Assert.AreEqual(_testPassword.UsersSharedWith, _passwordDataAccess.Get(id).UsersSharedWith);
        }
    }
}


      