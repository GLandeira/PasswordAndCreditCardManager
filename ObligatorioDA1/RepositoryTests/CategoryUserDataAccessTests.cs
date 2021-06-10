using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Repository;
using System;
using System.Linq;

namespace RepositoryTests
{
    [TestClass]
    public class CategoryUserDataAccessTests
    {

        private Category _testCategory1;
        private Category _testCategory2;

        [TestInitialize]
        public void TestInitialize()
        {
            //_categoryDataAccess.Clear();

            _testCategory1 = new Category("Escuela");

            _testCategory2 = new Category("Universidade");
        }
    }
}
