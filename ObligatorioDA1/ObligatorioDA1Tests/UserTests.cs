using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Domain.Exceptions;

namespace DomainTests
{
    [TestClass]
    public class UserTests
    {
        private User _testUser;

        [TestInitialize]
        public void TestInitialize()
        {
            _testUser = new User();
        }

        [TestMethod]
        public void TestAddingOneCategoryMaintainsLength()
        {
            int originalLength = _testUser.Categories.Count;
            string nameToTest = "School";
            Category aCategory = new Category(nameToTest);
            
            _testUser.AddCategory(aCategory);

            Assert.AreEqual(originalLength + 1, _testUser.Categories.Count);
        }

        [TestMethod]
        public void TestAddingShortNameThrowsException()
        {
            string nameToTest = "Al";
            Category aCategory = new Category(nameToTest);

            Assert.ThrowsException<ShortCategoryNameException>(() => _testUser.AddCategory(aCategory));
        }

        [TestMethod]
        public void TestAddingLongNameThrowsException()
        {
            string nameToTest = "School and Personal";
            Category aCategory = new Category(nameToTest);

            Assert.ThrowsException<LongCategoryNameException>(() => _testUser.AddCategory(aCategory));
        }

        [TestMethod]
        public void TestGettingACategoryThatIsPresentIsntNull()
        {
            string nameToTest = "Work";
            Category aCategory = new Category(nameToTest);

            _testUser.AddCategory(aCategory);

            Assert.AreNotEqual(null, _testUser.GetACategory(nameToTest));
        }

        [TestMethod]
        public void TestGettingACategoryThatIsWhatWasAdded()
        {
            string nameToTest = "Work";
            Category aCategory = new Category(nameToTest);

            _testUser.AddCategory(aCategory);

            Assert.AreEqual(nameToTest, _testUser.GetACategory(nameToTest).Name);
        }

        [TestMethod]
        public void TestGettingACategoryThatIsntPresentThrowsException()
        {
            string nameToTest1 = "Wokr";
            string nameToTest2 = "Work";
            Category aCategory = new Category(nameToTest2);

            _testUser.AddCategory(aCategory);

            Assert.ThrowsException<CategoryNotFoundException>(() => _testUser.GetACategory(nameToTest1));
        }

        [TestMethod]
        public void TestModifyCategoryThatIsntPresentThrowsException() 
        {
        }

        [TestMethod]
        public void TestModifyCategoryActuallyModifies()
        {
        }

        [TestMethod]
        public void TestModifyingWithShortNameThrowsException()
    {
        }

        [TestMethod]
        public void TestModifyingWithLongNameThrowsException()
        {
        }

        [TestMethod]
        public void TestChangingMainPasswordActuallyChanges()
    {
        }
    }
}
