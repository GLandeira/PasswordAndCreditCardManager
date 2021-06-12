using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository;


namespace RepositoryTests
{
    [TestClass]
    public class CreditCardDataAccessTests
    {
        private UserDataAccess _userDataAccess;
        private CreditCardDataAccess _creditcardDataAccess;
        private CategoryDataAccess _categoryDataAccess;

        private User _testUser;

        private Category _testCategory1;
        private Category _testCategory2;

        private CreditCard _testCreditCard1;
        private CreditCard _testCreditCard2;

        public CreditCardDataAccessTests()
        {
            _creditcardDataAccess = new CreditCardDataAccess();
            _userDataAccess = new UserDataAccess();
            _categoryDataAccess = new CategoryDataAccess();

            _testUser = new User("Juan", "123456");
            int id = _userDataAccess.Add(_testUser);
            _testUser.UserID = id;

            _testCategory1 = new Category("Trabajo");
            _testCategory1.UserCategory = _testUser.UserCategories;
            _testCategory1.CategoryID = _categoryDataAccess.Add(_testCategory1);
            CardTypes visa = CardTypes.VISA;

            _testCreditCard1 = new CreditCard
            {
                Name = "Visa Gold",
                Type = visa,
                Number = "1111111111111111",
                SecurityCode = "1234",
                ValidDue = DateTime.Today,
                Category = _testCategory1,
                Notes = "super secreta, no compartir"
            };
            _testCreditCard1.UserCreditCard = _testUser.UserCreditCards;

            _testCategory2 = new Category("personal");
            _testCategory2.UserCategory = _testUser.UserCategories;
            _testCategory2.CategoryID = _categoryDataAccess.Add(_testCategory2);
            CardTypes master = CardTypes.MASTERCARD;

            _testCreditCard2 = new CreditCard
            {
                Name = "Master",
                Type = master,
                Number = "2222222222222222",
                SecurityCode = "143",
                ValidDue = DateTime.Today,
                Category = _testCategory2,
                Notes = "para compartir"
            };
            _testCreditCard2.UserCreditCard = _testUser.UserCreditCards;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //_categoryDataAccess.Clear();
            _userDataAccess.Clear();
        }

        [TestMethod]
        public void AddCreditCardTest()
        {
            _creditcardDataAccess.Add(_testCreditCard1);

            Assert.AreEqual(1, _creditcardDataAccess.GetAll().ToList().Count);
        }

        [TestMethod]
        public void AddTwoCreditCardsTest()
        {
            _creditcardDataAccess.Add(_testCreditCard1);
            _creditcardDataAccess.Add(_testCreditCard2);

            Assert.AreEqual(2, _creditcardDataAccess.GetAll().ToList().Count);
        }


        [TestMethod]
        public void GetCreditCardsTest()
        {
            int id = _creditcardDataAccess.Add(_testCreditCard1);
            Assert.IsTrue(_testCreditCard1.absoluteEquals(_creditcardDataAccess.Get(id)));
        }

        [TestMethod]
        public void GetCreditCardsNotEqualTest()
        {
            int id1 = _creditcardDataAccess.Add(_testCreditCard1);
            int id2 = _creditcardDataAccess.Add(_testCreditCard2);

            Assert.IsFalse(id1, _creditcardDataAccess.Get(id2).CreditCardID);
        }

        [TestMethod]
        public void DeleteCreditCardTest()
        {
            int id = _creditcardDataAccess.Add(_testCreditCard1);

            _creditcardDataAccess.Delete(_testCreditCard1);

            Assert.IsFalse(_creditcardDataAccess.GetAll().Any(c => c.CreditCardID == id));
        }

        [TestMethod]
        public void ModifyCreditCardTest()
        {
            int id = _creditcardDataAccess.Add(_testCreditCard1);

            string nombreNuevo = "tarjeta shopping";
            string cvv = "277";
            _testCreditCard1.Name = nombreNuevo;
            _testCreditCard1.SecurityCode = cvv;
            _creditcardDataAccess.Modify(_testCreditCard1);

            Assert.AreEqual(nombreNuevo, _creditcardDataAccess.Get(id).Name);
        }


    }
}
