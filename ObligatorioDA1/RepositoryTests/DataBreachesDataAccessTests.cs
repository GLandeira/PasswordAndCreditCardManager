using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Repository;
using Domain;
using System.Linq;

namespace RepositoryTests
{
    [TestClass]
    public class DataBreachesDataAccessTests
    {
        private UserDataAccess _userDataAccess;
        private CategoryDataAccess _categoryDataAccess;
        private PasswordDataAccess _passwordDataAccess;
        private CreditCardDataAccess _creditCardDataAccess;
        private DataBreachesDataAccess _dataBreachesDataAccess;

        private User _testUser;

        private Category _testCategory1;
        private Category _testCategory2;
        private Category _testCategory3;

        private Password _testPassword1;
        private Password _testPassword2;

        private PasswordHistory _testPasswordHistory1;
        private PasswordHistory _testPasswordHistory2;

        private CreditCard _testCreditCard1;
        private CreditCard _testCreditCard2;

        private DataBreach _testDataBreach1;
        private DataBreach _testDataBreach2;
        private DataBreach _testDataBreach3;

        [TestInitialize]
        public void TestInitialize()
        {
            _categoryDataAccess = new CategoryDataAccess();
            _userDataAccess = new UserDataAccess();
            _passwordDataAccess = new PasswordDataAccess();
            _creditCardDataAccess = new CreditCardDataAccess();
            _dataBreachesDataAccess = new DataBreachesDataAccess();

            _testUser = new User("Juan", "123456");
            int uid1 = _userDataAccess.Add(_testUser);
            _testUser.UserID = uid1;

            _testCategory1 = new Category("Escuela");
            _testCategory1.UserCategory = _testUser.UserCategories;
            int cid1 = _categoryDataAccess.Add(_testCategory1);
            _testCategory1.CategoryID = cid1;

            _testCategory2 = new Category("Universidade");
            _testCategory2.UserCategory = _testUser.UserCategories;
            int cid2 = _categoryDataAccess.Add(_testCategory2);
            _testCategory2.CategoryID = cid2;

            _testCategory3 = new Category("College");
            _testCategory3.UserCategory = _testUser.UserCategories;
            int cid3 = _categoryDataAccess.Add(_testCategory3);
            _testCategory3.CategoryID = cid3;

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
            int ccid1 = _creditCardDataAccess.Add(_testCreditCard1);
            _testCreditCard1.CreditCardID = ccid1;

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
            int ccid2 = _creditCardDataAccess.Add(_testCreditCard2);
            _testCreditCard2.CreditCardID = ccid2;

            _testPassword1 = new Password
            {
                PasswordString = "111@#sasddawdq111",
                Site = "www.ort.edu.uy",
                Username = "Matias Gonzalez",
                LastModification = DateTime.Today,
                Notes = "cuenta universidad"
            };
            _testPassword1.UserPassword = _testUser.UserPasswords;
            _testPassword1.Category = _testCategory1;
            int pid1 = _passwordDataAccess.Add(_testPassword1);
            _testPassword1.PasswordID = pid1;

            _testPassword2 = new Password
            {
                PasswordString = "111111",
                Site = "www.twitch.tv",
                Username = "GLandeira",
                LastModification = DateTime.Today,
                Notes = "cuenta streaming 2"
            };
            _testPassword2.UserPassword = _testUser.UserPasswords;
            _testPassword2.Category = _testCategory2;
            int pid2 = _passwordDataAccess.Add(_testPassword2);
            _testPassword2.PasswordID = pid2;

            _testPasswordHistory1 = new PasswordHistory()
            {
                Password = _testPassword1,
                BreachedPasswordString = "0ldPassw0rd"
            };
            _testPasswordHistory2 = new PasswordHistory()
            {
                Password = _testPassword2,
                BreachedPasswordString = "Another0ldPassword"
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _userDataAccess.Clear();
        }

        [TestMethod]
        public void AddDataBreach()
        {
            DataBreach dataBreach = new DataBreach(_testUser.UserDataBreaches);
            dataBreach.Date = DateTime.Now;
            dataBreach.CreditCardBreaches.Add(_testCreditCard1);
            dataBreach.PasswordBreaches.Add(_testPasswordHistory1);

            _dataBreachesDataAccess.Add(dataBreach);

            Assert.AreEqual(1, _dataBreachesDataAccess.GetAll().ToList().Count);
            Assert.IsFalse(false);
        }
    }
}
