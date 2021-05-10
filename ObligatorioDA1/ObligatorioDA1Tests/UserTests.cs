using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void TestGettingACategoryFromANullCategoriesListThrowsException()
        {
            string nameToTest = "Work";
            Category aCategory = new Category(nameToTest);

            _testUser.Categories = null;

            Assert.ThrowsException<CategoryNotFoundException>(() => _testUser.GetACategory(nameToTest));
        }

        [TestMethod]
        public void TestModifyCategoryActuallyModifies()
        {
            //Setup
            string testName = "Modifiable";
            Category categoryToModify = new Category(testName);

            _testUser.AddCategory(categoryToModify);

            Category newCategory = new Category("University");
            _testUser.ModifyCategory(categoryToModify, newCategory);

            Assert.AreEqual(newCategory, _testUser.GetACategory(newCategory.Name));
        }

        [TestMethod]
        public void TestModifyCategoryThatIsntPresentThrowsException() 
        {
            string testName = "Modifiable";
            Category categoryToModify = new Category(testName);
            Category newCategory = new Category("University");

            Assert.ThrowsException<CategoryNotFoundException>(() =>_testUser.ModifyCategory(categoryToModify, newCategory));
        }

        [TestMethod]
        public void TestModifyCategoryOnEmptyListThrowsException()
        {
            _testUser.Categories = null;
            
            string testName = "Modifiable";
            Category categoryToModify = new Category(testName);
            Category newCategory = new Category("University");

            Assert.ThrowsException<CategoryNotFoundException>(() => _testUser.ModifyCategory(categoryToModify, newCategory));
        }

        [TestMethod]
        public void TestModifyingWithShortNameThrowsException()
        {
            string testName = "Modifiable";
            Category categoryToModify = new Category(testName);

            _testUser.AddCategory(categoryToModify);
            Category newCategory = new Category("Un");

            Assert.ThrowsException<NameCategoryException>(() => _testUser.ModifyCategory(categoryToModify, newCategory));
        }

        [TestMethod]
        public void TestModifyingWithLongNameThrowsException()
        {
            string testName = "Modifiable";
            Category categoryToModify = new Category(testName);

            _testUser.AddCategory(categoryToModify);
            Category newCategory = new Category("University and others");

            Assert.ThrowsException<NameCategoryException>(() => _testUser.ModifyCategory(categoryToModify, newCategory));
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

            _testUser.AddCategory(category1);

            Assert.ThrowsException<CategoryAlreadyExistsException>(_testUser.AddCategory(category2));
        }
    }
}
