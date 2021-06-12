using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Exceptions;

namespace DomainTests
{
    [TestClass]
    public class UserTests
    {
        private User _testUser;
        private UserManager _userManager;
        [TestInitialize]
        public void TestInitialize()
        {
            _userManager = UserManager.Instance;
            _testUser = new User("UserName", "SomePassword");
        }
        
        [TestMethod]
        public void TestAddingOneCategoryMaintainsLength()
        {
            int originalLength = _testUser.UserCategories.Categories.Count;
            string nameToTest = "School";
            Category aCategory = new Category(nameToTest);
            
            _testUser.UserCategories.AddCategory(aCategory);

            Assert.AreEqual(originalLength + 1, _testUser.UserCategories.Categories.Count);
        }

        [TestMethod]
        public void TestGettingACategoryThatIsPresentIsntNull()
        {
            string nameToTest = "Work";
            Category aCategory = new Category(nameToTest);

            _testUser.UserCategories.AddCategory(aCategory);

            Assert.AreNotEqual(null, _testUser.UserCategories.GetACategory(nameToTest));
        }

        [TestMethod]
        public void TestGettingACategoryThatIsWhatWasAdded()
        {
            string nameToTest = "Work";
            Category aCategory = new Category(nameToTest);

            _testUser.UserCategories.AddCategory(aCategory);

            Assert.AreEqual(nameToTest, _testUser.UserCategories.GetACategory(nameToTest).Name);
        }

        [TestMethod]
        public void TestGettingACategoryThatIsntPresentThrowsException()
        {
            string nameToTest1 = "Wokr";
            string nameToTest2 = "Work";
            Category aCategory = new Category(nameToTest2);

            _testUser.UserCategories.AddCategory(aCategory);

            Assert.ThrowsException<CategoryNotFoundException>(() => _testUser.UserCategories.GetACategory(nameToTest1));
        }

        [TestMethod]
        public void TestGettingACategoryFromANullCategoriesListThrowsException()
        {
            string nameToTest = "Work";
            Category aCategory = new Category(nameToTest);

            _testUser.UserCategories.Categories = null;

            Assert.ThrowsException<CategoryNotFoundException>(() => _testUser.UserCategories.GetACategory(nameToTest));
        }

        [TestMethod]
        public void TestModifyCategoryActuallyModifies()
        {
            //Setup
            string testName = "Modifiable";
            Category categoryToModify = new Category(testName);

            _testUser.UserCategories.AddCategory(categoryToModify);

            Category newCategory = new Category(categoryToModify.CategoryID, "University");
            _testUser.UserCategories.ModifyCategory(categoryToModify, newCategory);

            Assert.AreEqual(newCategory, _testUser.UserCategories.GetACategory(newCategory.Name));
        }

        [TestMethod]
        public void TestModifyCategoryThatIsntPresentThrowsException() 
        {
            string testName = "Modifiable";
            Category categoryToModify = new Category(testName);
            Category newCategory = new Category("University");

            Assert.ThrowsException<CategoryNotFoundException>(() =>_testUser.UserCategories.ModifyCategory(categoryToModify, newCategory));
        }

        [TestMethod]
        public void TestModifyCategoryOnEmptyListThrowsException()
        {
            _testUser.UserCategories.Categories = null;
            
            string testName = "Modifiable";
            Category categoryToModify = new Category(testName);
            Category newCategory = new Category("University");

            Assert.ThrowsException<CategoryNotFoundException>(() => _testUser.UserCategories.ModifyCategory(categoryToModify, newCategory));
        }

        [TestMethod]
        public void TestModifyingWithShortNameThrowsException()
        {
            string testName = "Modifiable";
            Category categoryToModify = new Category(testName);

            _testUser.UserCategories.AddCategory(categoryToModify);
            Category newCategory = new Category("Un");

            Assert.ThrowsException<NameCategoryException>(() => _testUser.UserCategories.ModifyCategory(categoryToModify, newCategory));
        }

        [TestMethod]
        public void TestModifyingWithLongNameThrowsException()
        {
            string testName = "Modifiable";
            Category categoryToModify = new Category(testName);

            _testUser.UserCategories.AddCategory(categoryToModify);
            Category newCategory = new Category("University and others");

            Assert.ThrowsException<NameCategoryException>(() => _testUser.UserCategories.ModifyCategory(categoryToModify, newCategory));
        }

        [TestMethod]
        public void TestGoodEqualsCase()
        {
            string name = "Pablo";
            User userOne = new User(name, "pass1");
            User userTwo = new User(name, "pass2");

            Assert.AreEqual(userOne, userTwo);
        }

        [TestMethod]
        public void TestBadEqualsCase()
        {
            string name1 = "Johnny";
            string name2 = "Alice";
            User userOne = new User(name1, "pass1");
            User userTwo = new User(name2, "pass2");

            Assert.AreNotEqual(userOne, userTwo);
        }

        [TestMethod]
        public void TestAddingTwoCategoriesWithSameNameThrowsException()
        {
            string categoryString1 = "My Job";
            string categoryString2 = "My Job";
            Category category1 = new Category(categoryString1);
            Category category2 = new Category(categoryString2);

            _testUser.UserCategories.AddCategory(category1);

            Assert.ThrowsException<CategoryAlreadyExistsException>(() => _testUser.UserCategories.AddCategory(category2));
        }

        [TestMethod]
        public void TestAddingTwoCategoriesWithSameNameDifferentCasingThrowsException()
        {
            string categoryString1 = "my jOb";
            string categoryString2 = "MY JoB";
            Category category1 = new Category(categoryString1);
            Category category2 = new Category(categoryString2);

            _testUser.UserCategories.AddCategory(category1);

            Assert.ThrowsException<CategoryAlreadyExistsException>(() => _testUser.UserCategories.AddCategory(category2));
        }
    }
}
