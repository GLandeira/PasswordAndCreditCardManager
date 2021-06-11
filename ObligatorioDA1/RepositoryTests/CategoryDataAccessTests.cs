using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Repository;
using System;
using System.Linq;

namespace RepositoryTests
{
    [TestClass]
    public class CategoryDataAccessTests
    {
        private UserDataAccess _userDataAccess;
        private CategoryDataAccess _categoryDataAccess;

        private User _testUser;
        private Category _testCategory1;
        private Category _testCategory2;

        public CategoryDataAccessTests()
        {
            _categoryDataAccess = new CategoryDataAccess();
            _userDataAccess = new UserDataAccess();

            _testUser = new User("Juan", "123456");
            int id = _userDataAccess.Add(_testUser);
            _testUser.UserID = id;

            _testCategory1 = new Category("Escuela");
            _testCategory1.UserCategory = _testUser.UserCategories;

            _testCategory2 = new Category("Universidade");
            _testCategory2.UserCategory = _testUser.UserCategories;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //_categoryDataAccess.Clear();
            _userDataAccess.Clear();
        }

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void AddCategoryTest()
        {
            _categoryDataAccess.Add(_testCategory1);

            Assert.AreEqual(1, _categoryDataAccess.GetAll().ToList().Count);
        }

        [TestMethod]
        public void AddTwoCategoriesTest()
        {
            _categoryDataAccess.Add(_testCategory1);
            _categoryDataAccess.Add(_testCategory2);

            Assert.AreEqual(2, _categoryDataAccess.GetAll().ToList().Count);
        }

        [TestMethod]
        public void GetCategoriesTest()
        {
            int id = _categoryDataAccess.Add(_testCategory1);

            Assert.AreEqual(_testCategory1.CategoryID, _categoryDataAccess.Get(id).CategoryID);
        }

        [TestMethod]
        public void GetCategoriesNotEqualTest()
        {
            int id1 = _categoryDataAccess.Add(_testCategory1);
            int id2 = _categoryDataAccess.Add(_testCategory2);

            Assert.AreNotEqual(id1, _categoryDataAccess.Get(id2).CategoryID);
        }

        [TestMethod]
        public void DeleteCategoryTest()
        {
            int id = _categoryDataAccess.Add(_testCategory1);

            _categoryDataAccess.Delete(_testCategory1);

            Assert.IsFalse(_categoryDataAccess.GetAll().Any(c => c.CategoryID == id));
        }

        [TestMethod]
        public void DeleteRightCategoryTest()
        {
            _categoryDataAccess.Add(_testCategory1);
            int id = _categoryDataAccess.Add(_testCategory2);

            _categoryDataAccess.Delete(_testCategory1);

            Assert.IsTrue(_categoryDataAccess.GetAll().Any(c => c.CategoryID == id));
        }
        [TestMethod]
        public void ModifyCategoryTest()
        {
            int id = _categoryDataAccess.Add(_testCategory1);

            string nombreNuevo = "Trabajo";
            _testCategory1.Name = nombreNuevo;
            _categoryDataAccess.Modify(_testCategory1);

            Assert.AreEqual(nombreNuevo, _categoryDataAccess.Get(id).Name);
        }
    }
}
