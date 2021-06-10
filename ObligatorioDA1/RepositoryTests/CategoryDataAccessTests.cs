﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private IDataAccess<Category> _categoryDataAccess;

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
    }
}
