using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Repository;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RepositoryTests
{
    [TestClass]
    public class CategoryDataAccessTests
    {
        private UserDataAccess _userDataAccess;
        private CategoryDataAccess _categoryDataAccess;

        private User _testUser1;
        private User _testUser2;
        private Category _testCategory1;
        private Category _testCategory2;
        private Category _testCategory3;

        public CategoryDataAccessTests()
        {
            _categoryDataAccess = new CategoryDataAccess();
            _userDataAccess = new UserDataAccess();

            _testUser1 = new User("Juan", "123456");
            int id1 = _userDataAccess.Add(_testUser1);
            _testUser1.UserID = id1;

            _testUser2 = new User("Fran", "1a2b3c");
            int id2 = _userDataAccess.Add(_testUser2);
            _testUser2.UserID = id2;

            _testCategory1 = new Category("Escuela");
            _testCategory1.UserCategory = _testUser1.UserCategories;

            _testCategory2 = new Category("Universidade");
            _testCategory2.UserCategory = _testUser1.UserCategories;

            _testCategory3 = new Category("College");
            _testCategory3.UserCategory = _testUser2.UserCategories;

        }

        [TestCleanup]
        public void TestCleanup()
        {
            
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

        [TestMethod]
        public void GetAllBringsAllFromDatabase()
        {
            _categoryDataAccess.Add(_testCategory1);
            _categoryDataAccess.Add(_testCategory2);
            _categoryDataAccess.Add(_testCategory3);

            List<Category> allCategories = _categoryDataAccess.GetAll().ToList();

            Assert.IsTrue(allCategories.Contains(_testCategory1) && allCategories.Contains(_testCategory2) && allCategories.Contains(_testCategory3));
        }
    }
}
