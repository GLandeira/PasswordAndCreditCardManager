using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;

namespace DomainTests
{
    [TestClass]
    public class UserDataBreachesTests
    {
        private User _testUser;
        private UserDataBreaches _userDataBreaches;

        private string _breach1;
        private string _breach2;
        private string _breach3;
        private string _breach4;
        private string _breach5;
        private string _breach6;
        private String[] _breachTest;

        private UserCreditCard _userCreditCardTest;
        private UserPassword _userPasswordTest;

        private CreditCard _creditCard1;
        private CreditCard _creditCard2;
        private CreditCard _creditCard3;

        private Password _password1;
        private Password _password2;
        private Password _password3;

        private DataBreaches _dataBreachTest;

        [TestInitialize]
        public void TestInitialize()
        {
            _testUser = new User();
            _userDataBreaches = new UserDataBreaches(_testUser);

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
            };
            _creditCard2 = new CreditCard
            {
                Name = "Santander Rio",
                Number = "2222222222222222",
                SecurityCode = "123",
                Notes = "",
            };
            _creditCard3 = new CreditCard
            {
                Name = "Master Platinum",
                Number = "4444444444444444",
                SecurityCode = "1234",
                Notes = "No note",
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

        [TestMethod]
        public void CheckOneDataBreachCreditCardThatIsInTheDomain()
        {
            _breachTest = new string[] { _breach1 };
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest);

            Assert.AreEqual(true, _dataBreachTest.CreditCardsBreaches.Exists(creditCardInList => creditCardInList.Equals(_creditCard1)));
        }

        [TestMethod]
        public void CheckOneDataBreachPasswordThatIsInTheDomain()
        {
            _breachTest = new string[] { _breach2 };
            _userPasswordTest.AddPassword(_password1);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest);

            Assert.AreEqual(true, _dataBreachTest.PasswordBreaches.Exists(passwordInList => passwordInList.PasswordString.Equals(_password1.PasswordString)));
        }

        [TestMethod]
        public void CheckOneDataBreachCreditCardThatIsNotInTheDomain()
        {
            _breachTest = new string[] { _breach5 };
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.AddCreditCard(_creditCard2);
            _userCreditCardTest.AddCreditCard(_creditCard3);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest);

            Assert.AreEqual(0, _dataBreachTest.CreditCardsBreaches.Count);
        }

        [TestMethod]
        public void CheckOneDataBreachPasswordThatIsNotInTheDomain()
        {
            _breachTest = new string[] { _breach3 };
            _userPasswordTest.AddPassword(_password1);
            _userPasswordTest.AddPassword(_password2);
            _userPasswordTest.AddPassword(_password3);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest);

            Assert.AreEqual(0, _dataBreachTest.PasswordBreaches.Count);
        }

        [TestMethod]
        public void CheckMultipleDataBreachesInTheDomain()
        {
            _breachTest = new string[] { _breach1, _breach2, _breach4, _breach6};
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.AddCreditCard(_creditCard2);
            _userCreditCardTest.AddCreditCard(_creditCard3);
            _userPasswordTest.AddPassword(_password1);
            _userPasswordTest.AddPassword(_password2);
            _userPasswordTest.AddPassword(_password3);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest);

            int _listQuantity = _dataBreachTest.PasswordBreaches.Count + _dataBreachTest.CreditCardsBreaches.Count;
            Assert.AreEqual(4, _listQuantity);
        }

        [TestMethod]
        public void CheckMultipleDataBreachesThatAreOrNotInTheDomain()
        {
            _breachTest = new string[] { _breach1, _breach2, _breach3, _breach4, _breach5, _breach6};
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.AddCreditCard(_creditCard2);
            _userCreditCardTest.AddCreditCard(_creditCard3);
            _userPasswordTest.AddPassword(_password1);
            _userPasswordTest.AddPassword(_password2);
            _userPasswordTest.AddPassword(_password3);
            _dataBreachTest = _userDataBreaches.CheckDataBreaches(_breachTest);

            int _listQuantity = _dataBreachTest.PasswordBreaches.Count + _dataBreachTest.CreditCardsBreaches.Count;
            Assert.AreEqual(4, _listQuantity);
        }
    }
}
