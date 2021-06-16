using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Domain.DataBreachesTranslator;

namespace DomainTests
{
    [TestClass]
    public class DataBreachesCheckerTests
    {
        private UserManager _userManager;
        private User _testUser;
        private DataBreachesChecker _userDataBreaches;

        private string _breach1;
        private string _breach2;
        private string _breach3;
        private string _breach4;
        private string _breach5;
        private string _breach6;
        private string _breachTest;

        private UserCreditCard _userCreditCardTest;
        private UserPassword _userPasswordTest;

        private CreditCard _creditCard1;
        private CreditCard _creditCard2;
        private CreditCard _creditCard3;

        private Password _password1;
        private Password _password2;
        private Password _password3;

        private DataBreach _dataBreachTest;

        [TestInitialize]
        public void TestInitialize()
        {
            _userManager = UserManager.Instance;
            _testUser = new User("Alberto", "32323");
            _userManager.AddUser(_testUser);
            _userManager.LoggedUser = _testUser;

            _testUser.UserDataBreaches.UserDataBreachesID = _testUser.UserID;
            _userDataBreaches = _testUser.UserDataBreaches.DataBreachesChecker;

            _breach1 = "1111 1111 1111 1111";
            _breach2 = "micontra";
            _breach3 = "123456"; 
            _breach4 = "2222 2222 2222 2222";
            _breach5 = "3333 3333 3333 3333"; 
            _breach6 = "prueba#contra";

            _userCreditCardTest = _testUser.UserCreditCards;
            _creditCard1 = new CreditCard
            {
                Name = "Visa Gold",
                Number = "1111111111111111",
                SecurityCode = "122",
                Notes = "im a note",
                ValidDue = DateTime.Today
            };
            _creditCard2 = new CreditCard
            {
                Name = "Santander Rio",
                Number = "2222222222222222",
                SecurityCode = "123",
                Notes = "",
                ValidDue = DateTime.Today
        };
            _creditCard3 = new CreditCard
            {
                Name = "Master Platinum",
                Number = "4444444444444444",
                SecurityCode = "1234",
                Notes = "No note",
                ValidDue = DateTime.Today
            };  
            
            _userPasswordTest = _testUser.UserPasswords;
            _password1 = new Password
            {
                PasswordString = "micontra",
                Site = "www.ort.edu.uy",
                Username = "Gaston Landeira",
                Notes = "im a note",
            };
            _password2 = new Password
            {
                PasswordString = "whatsthis",
                Site = "www.ort.edu.uy",
                Username = "OwO123",
                Notes = "",
            };
            _password3 = new Password
            {
                PasswordString = "prueba#contra",
                Site = "www.twitch.tv/GLandeira",
                Username = "GLandeira",
                Notes = "No note",
            };
            
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _userManager.Users.Clear();
        }

        [TestMethod]
        public void CheckOneDataBreachCreditCardThatIsInTheDomain()
        {
            _breachTest = _breach1;
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest, new TextBoxTranslator());

            Assert.AreEqual(true, _dataBreachTest.CreditCardBreaches.Exists(creditCardInList => creditCardInList.Equals(_creditCard1)));
        }

        [TestMethod]
        public void CheckOneDataBreachPasswordThatIsInTheDomain()
        {
            _breachTest = _breach2;
            _userPasswordTest.AddPassword(_password1);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest, new TextBoxTranslator());

            Assert.AreEqual(true, _dataBreachTest.PasswordBreaches.Exists(passwordInList => passwordInList.BreachedPasswordString.Equals(_password1.PasswordString)));
        }

        [TestMethod]
        public void CheckOneDataBreachCreditCardThatIsNotInTheDomain()
        {
            _breachTest = _breach5;
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.AddCreditCard(_creditCard2);
            _userCreditCardTest.AddCreditCard(_creditCard3);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest, new TextBoxTranslator());

            Assert.AreEqual(0, _dataBreachTest.CreditCardBreaches.Count);
        }

        [TestMethod]
        public void CheckOneDataBreachPasswordThatIsNotInTheDomain()
        {
            _breachTest = _breach3;
            _userPasswordTest.AddPassword(_password1);
            _userPasswordTest.AddPassword(_password2);
            _userPasswordTest.AddPassword(_password3);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest, new TextBoxTranslator());

            Assert.AreEqual(0, _dataBreachTest.PasswordBreaches.Count);
        }

        [TestMethod]
        public void CheckMultipleDataBreachesInTheDomain()
        {
            _breachTest = _breach1 + Environment.NewLine + _breach2 + Environment.NewLine + _breach4 + Environment.NewLine + _breach6;
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.AddCreditCard(_creditCard2);
            _userCreditCardTest.AddCreditCard(_creditCard3);
            _userPasswordTest.AddPassword(_password1);
            _userPasswordTest.AddPassword(_password2);
            _userPasswordTest.AddPassword(_password3);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest, new TextBoxTranslator());

            int _listQuantity = _dataBreachTest.PasswordBreaches.Count + _dataBreachTest.CreditCardBreaches.Count;
            Assert.AreEqual(4, _listQuantity);
        }

        [TestMethod]
        public void CheckMultipleDataBreachesThatAreOrNotInTheDomain()
        {
            _breachTest = _breach1 + Environment.NewLine + _breach2 + Environment.NewLine + _breach3 + 
                          Environment.NewLine + _breach4 + Environment.NewLine + _breach5 + Environment.NewLine + _breach6;
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.AddCreditCard(_creditCard2);
            _userCreditCardTest.AddCreditCard(_creditCard3);
            _userPasswordTest.AddPassword(_password1);
            _userPasswordTest.AddPassword(_password2);
            _userPasswordTest.AddPassword(_password3);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest, new TextBoxTranslator());

            int _listQuantity = _dataBreachTest.PasswordBreaches.Count + _dataBreachTest.CreditCardBreaches.Count;
            Assert.AreEqual(4, _listQuantity);
        }

        [TestMethod]
        public void CheckMultipleDataBreachesOfSamePasswordsDoesntShowRepeatedBreaches()
        {
            _breachTest = _breach2 + Environment.NewLine + _breach2 + Environment.NewLine + _breach2;
            _userPasswordTest.AddPassword(_password1);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest, new TextBoxTranslator());

            int _listQuantity = _dataBreachTest.PasswordBreaches.Count;
            Assert.AreEqual(1, _listQuantity);
        }

        [TestMethod]
        public void CheckMultipleDataBreachesOfSameCreditCardsDoesntShowRepeatedBreaches()
        {
            _breachTest = _breach1 + Environment.NewLine + _breach1 + Environment.NewLine + _breach1;
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest, new TextBoxTranslator());

            int _listQuantity = _dataBreachTest.CreditCardBreaches.Count;
            Assert.AreEqual(1, _listQuantity);
        }

        [TestMethod]
        public void CheckMultipleDataBreachesOfSameCreditCardsAndPasswordsDoesntShowRepeatedBreaches()
        {
            _breachTest = _breach1 + Environment.NewLine + _breach1 + Environment.NewLine + _breach1 + Environment.NewLine + 
                          _breach2 + Environment.NewLine + _breach2 + Environment.NewLine + _breach3 + Environment.NewLine +
                          _breach3 + Environment.NewLine + _breach4 + Environment.NewLine + _breach4 + Environment.NewLine + 
                          _breach4 + Environment.NewLine + _breach5 + Environment.NewLine + _breach5 + Environment.NewLine +
                          _breach6 + Environment.NewLine + _breach6 + Environment.NewLine + _breach6 + Environment.NewLine + _breach6;
            _userPasswordTest.AddPassword(_password1);
            _userPasswordTest.AddPassword(_password2);
            _userCreditCardTest.AddCreditCard(_creditCard2);
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest, new TextBoxTranslator());

            int _listQuantity = _dataBreachTest.CreditCardBreaches.Count + _dataBreachTest.PasswordBreaches.Count;
            Assert.AreEqual(3, _listQuantity);
        }
    }
}
