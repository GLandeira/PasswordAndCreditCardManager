using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Domain.Exceptions;
using Repository;

namespace DomainTests
{
    [TestClass]
    public class UserCategoryTests
    {
        private UserManager _mockDomain;

        private User _testUser;
        private UserCategory _mockUserCategory;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDomain = UserManager.Instance;

            _testUser = new User("Juana", "123456");
            _testUser.Encryptor = new MockEncryptor();
            _mockDomain.AddUser(_testUser);

            _mockUserCategory = _testUser.UserCategories;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockDomain.Users.Clear();
        }

        [TestMethod]
        public void TestAddingOneCategoryMaintainsLength()
        {
            int originalLength = _mockUserCategory.Categories.Count;
            string nameToTest = "School";
            Category aCategory = new Category(nameToTest);

            _mockUserCategory.AddCategory(aCategory);

            Assert.AreEqual(originalLength + 1, _mockUserCategory.Categories.Count);
        }

        [TestMethod]
        public void TestGettingACategoryThatIsPresentIsntNull()
        {
            string nameToTest = "Work";
            Category aCategory = new Category(nameToTest);

            _mockUserCategory.AddCategory(aCategory);

            Assert.AreNotEqual(null, _mockUserCategory.GetACategory(nameToTest));
        }

        [TestMethod]
        public void TestGettingACategoryThatIsWhatWasAdded()
        {
            string nameToTest = "Work";
            Category aCategory = new Category(nameToTest);

            _mockUserCategory.AddCategory(aCategory);

            Assert.AreEqual(nameToTest, _mockUserCategory.GetACategory(nameToTest).Name);
        }

        [TestMethod]
        public void TestGettingACategoryThatIsntPresentThrowsException()
        {
            string nameToTest1 = "Wokr";
            string nameToTest2 = "Work";
            Category aCategory = new Category(nameToTest2);

            _mockUserCategory.AddCategory(aCategory);

            Assert.ThrowsException<CategoryNotFoundException>(() => _mockUserCategory.GetACategory(nameToTest1));
        }

        [TestMethod]
        public void TestGettingACategoryFromANullCategoriesListThrowsException()
        {
            string nameToTest = "Work";
            Category aCategory = new Category(nameToTest);

            _mockUserCategory.Categories = null;

            Assert.ThrowsException<CategoryNotFoundException>(() => _mockUserCategory.GetACategory(nameToTest));
        }

        [TestMethod]
        public void TestModifyCategoryActuallyModifies()
        {
            string testName = "Modifiable";
            Category categoryToModify = new Category(testName);

            _mockUserCategory.AddCategory(categoryToModify);

            Category newCategory = new Category(categoryToModify.CategoryID, "University");
            _mockUserCategory.ModifyCategory(categoryToModify, newCategory);

            Assert.AreEqual(newCategory, _mockUserCategory.GetACategory(newCategory.Name));
        }

        [TestMethod]
        public void TestModifyCategoryThatIsntPresentThrowsException()
        {
            string testName = "Modifiable";
            Category categoryToModify = new Category(testName);
            Category newCategory = new Category("University");

            Assert.ThrowsException<CategoryNotFoundException>(() => _mockUserCategory.ModifyCategory(categoryToModify, newCategory));
        }

        [TestMethod]
        public void TestModifyCategoryOnEmptyListThrowsException()
        {
            _mockUserCategory.Categories = null;

            string testName = "Modifiable";
            Category categoryToModify = new Category(testName);
            Category newCategory = new Category("University");

            Assert.ThrowsException<CategoryNotFoundException>(() => _mockUserCategory.ModifyCategory(categoryToModify, newCategory));
        }


        [TestMethod]
        public void TestAddingTwoCategoriesWithSameNameThrowsException()
        {
            string categoryString1 = "My Job";
            string categoryString2 = "My Job";
            Category category1 = new Category(categoryString1);
            Category category2 = new Category(categoryString2);

            _mockUserCategory.AddCategory(category1);

            Assert.ThrowsException<CategoryAlreadyExistsException>(() => _mockUserCategory.AddCategory(category2));
        }

        [TestMethod]
        public void TestAddingTwoCategoriesWithSameNameDifferentCasingThrowsException()
        {
            string categoryString1 = "my jOb";
            string categoryString2 = "MY JoB";
            Category category1 = new Category(categoryString1);
            Category category2 = new Category(categoryString2);

            _mockUserCategory.AddCategory(category1);

            Assert.ThrowsException<CategoryAlreadyExistsException>(() => _mockUserCategory.AddCategory(category2));
        }
    }
}
