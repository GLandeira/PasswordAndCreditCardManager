using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace DomainTests
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void TestGoodEqualsCase()
        {
            string name = "A name";
            Category categoryOne = new Category(name);
            Category categoryTwo = new Category(name);

            Assert.AreEqual(categoryOne, categoryTwo);
        }

        [TestMethod]
        public void TestBadEqualsCase()
        {
            string name1 = "A name";
            string name2 = "another name";
            Category categoryOne = new Category(name1);
            Category categoryTwo = new Category(name2);

            Assert.AreNotEqual(categoryOne, categoryTwo);
        }

        [TestMethod]
        public void TestEqualsCaseWithDifferentCasings()
        {
            string name1 = "Matias";
            string name2 = "mATIAS";
            Category categoryOne = new Category(name1);
            Category categoryTwo = new Category(name2);

            Assert.AreEqual(categoryOne, categoryTwo);
        }
    }
}
