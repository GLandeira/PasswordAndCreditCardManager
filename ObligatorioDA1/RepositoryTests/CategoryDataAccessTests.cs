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
        private CategoryDataAccess _categoryDataAccess;

        private Category _testCategory1;
        private Category _testCategory2;

        [TestInitialize]
        public void TestInitialize()
        {
            _categoryDataAccess = new CategoryDataAccess();
            _categoryDataAccess.Clear();

            _testCategory1 = new Category("Escuela");

            _testCategory2 = new Category("Universidade");
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
    }
}
