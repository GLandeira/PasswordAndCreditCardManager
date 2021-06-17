using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace DomainTests
{
    [TestClass]
    public class UserDataBreachesTests
    {
        private UserDataBreaches _userDataBreachesTest;
        private DataBreach _dataBreach1;
        private DataBreach _dataBreach2;
        private DataBreach _dataBreach3;
        private DataBreach _dataBreach4;

        private Password _testPassword1;
        private Password _testPassword2;
        private Password _testPassword3;
        private Password _testPassword4;
        private Password _testPassword5;
        private Password _testPassword6;

        private PasswordHistory _passwordHistories1;
        private PasswordHistory _passwordHistories2;
        private PasswordHistory _passwordHistories3;
        private PasswordHistory _passwordHistories4;
        private PasswordHistory _passwordHistories5;
        private PasswordHistory _passwordHistories6;

        private CreditCard _creditCard1;
        private CreditCard _creditCard2;
        private CreditCard _creditCard3;
        private CreditCard _creditCard4;
        private CreditCard _creditCard5;
        private CreditCard _creditCard6;

        [TestInitialize]
        public void TestInitialize()
        {
            _userDataBreachesTest = new UserDataBreaches();

            _testPassword1 = new Password
            {
                PasswordString = "111@#sasddawdq111",
                Site = "www.ort.edu.uy",
                Username = "Matias Gonzalez",
                LastModification = DateTime.Today,
                Notes = "cuenta universidad"
            };
            _testPassword2 = new Password
            {
                PasswordString = "111@aasdas111",
                Site = "www.papas.edu.uy",
                Username = "Juan Alberto",
                LastModification = DateTime.Today,
                Notes = "cuenta papas"
            };
            _testPassword3 = new Password
            {
                PasswordString = "111@1231awdq111",
                Site = "www.papas.edu.uy",
                Username = "Juana",
                LastModification = DateTime.Today,
                Notes = "cuenta papas Juana"
            };
            _testPassword4 = new Password
            {
                PasswordString = "1gagahA111",
                Site = "www.bolognesa.uy",
                Username = "Juan Alberto",
                LastModification = DateTime.Today,
                Notes = "cuenta bolognesa"
            };
            _testPassword5 = new Password
            {
                PasswordString = "Faaadq111",
                Site = "www.fiosa.edu.uy",
                Username = "Alfredo",
                LastModification = DateTime.Today,
                Notes = "cuenta fiosa"
            };
            _testPassword6 = new Password
            {
                PasswordString = "111@fasfasdq111",
                Site = "www.ebay.com",
                Username = "Ariadne",
                LastModification = DateTime.Today,
                Notes = "Cuenta ebay aranias"
            };

            _passwordHistories1 = new PasswordHistory()
            {
                Password = _testPassword1,
                BreachedPasswordString = "0ldPassw0rd"
            };
            _passwordHistories2 = new PasswordHistory()
            {
                Password = _testPassword2,
                BreachedPasswordString = "SecondOldPassword"
            };
            _passwordHistories3 = new PasswordHistory()
            {
                Password = _testPassword3,
                BreachedPasswordString = "SomeOldPassword"
            };
            _passwordHistories4 = new PasswordHistory()
            {
                Password = _testPassword4,
                BreachedPasswordString = "AnotherOtherPassword"
            };
            _passwordHistories5 = new PasswordHistory()
            {
                Password = _testPassword5,
                BreachedPasswordString = "MoreOldPasswords"
            };
            _passwordHistories6 = new PasswordHistory()
            {
                Password = _testPassword6,
                BreachedPasswordString = "OldestPassword"
            };

            _creditCard1 = new CreditCard()
            {
                Number = "1234132112344321"
            };

            _creditCard2 = new CreditCard()
            {
                Number = "323445216344821"
            };

            _creditCard3 = new CreditCard()
            {
                Number = "4434632112134241"
            };

            _creditCard4 = new CreditCard()
            {
                Number = "3334439010001322"
            };

            _creditCard5 = new CreditCard()
            {
                Number = "0000402112005021"
            };

            _creditCard6 = new CreditCard()
            {
                Number = "1724452112344661"
            };

            List<PasswordHistory> fakePasswordHistories1 = new List<PasswordHistory>();
            fakePasswordHistories1.Add(_passwordHistories1);
            fakePasswordHistories1.Add(_passwordHistories2);
            fakePasswordHistories1.Add(_passwordHistories3);

            List<CreditCard> fakeCreditCards1 = new List<CreditCard>();
            fakeCreditCards1.Add(_creditCard1);
            fakeCreditCards1.Add(_creditCard4);

            _dataBreach1 = new DataBreach();
            _dataBreach1.PasswordBreaches = fakePasswordHistories1;
            _dataBreach1.CreditCardBreaches = fakeCreditCards1;

            List<PasswordHistory> fakePasswordHistories2 = new List<PasswordHistory>();
            fakePasswordHistories2.Add(_passwordHistories4);
            fakePasswordHistories2.Add(_passwordHistories5);
            fakePasswordHistories2.Add(_passwordHistories6);

            List<CreditCard> fakeCreditCards2 = new List<CreditCard>();
            fakeCreditCards2.Add(_creditCard2);
            fakeCreditCards2.Add(_creditCard3);

            _dataBreach2 = new DataBreach();
            _dataBreach2.PasswordBreaches = fakePasswordHistories2;
            _dataBreach2.CreditCardBreaches = fakeCreditCards2;

            List<PasswordHistory> fakePasswordHistories3 = new List<PasswordHistory>();
            fakePasswordHistories3.Add(_passwordHistories1);
            fakePasswordHistories3.Add(_passwordHistories3);
            fakePasswordHistories3.Add(_passwordHistories5);

            List<CreditCard> fakeCreditCards3 = new List<CreditCard>();
            fakeCreditCards3.Add(_creditCard4);
            fakeCreditCards3.Add(_creditCard6);

            _dataBreach3 = new DataBreach();
            _dataBreach3.PasswordBreaches = fakePasswordHistories3;
            _dataBreach3.CreditCardBreaches = fakeCreditCards3;
            _dataBreach3.Date = DateTime.Now;

            List<PasswordHistory> fakePasswordHistories4 = new List<PasswordHistory>();
            fakePasswordHistories4.Add(_passwordHistories1);
            fakePasswordHistories4.Add(_passwordHistories3);
            fakePasswordHistories4.Add(_passwordHistories5);

            List<CreditCard> fakeCreditCards4 = new List<CreditCard>();
            fakeCreditCards4.Add(_creditCard4);
            fakeCreditCards4.Add(_creditCard6);

            _dataBreach4 = new DataBreach();
            _dataBreach4.PasswordBreaches = fakePasswordHistories4;
            _dataBreach4.CreditCardBreaches = fakeCreditCards4;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _userDataBreachesTest.DataBreaches.Clear();
        }

        [TestMethod]
        public void AddDataBreachTest()
        {
            _userDataBreachesTest.AddDataBreach(_dataBreach1);

            Assert.AreEqual(1, _userDataBreachesTest.DataBreaches.Count);
        }

        [TestMethod]
        public void AddManyDataBreachesTest()
        {
            _userDataBreachesTest.AddDataBreach(_dataBreach1);
            _dataBreach1.Date = DateTime.Now.AddHours(3);
            _userDataBreachesTest.AddDataBreach(_dataBreach2);
            _dataBreach2.Date = DateTime.Now.AddHours(4);
            _userDataBreachesTest.AddDataBreach(_dataBreach4);

            Assert.AreEqual(3, _userDataBreachesTest.DataBreaches.Count);
        }

        [TestMethod]
        public void AddRepeatedDataBreachesOfSameDateDoesntAddThemTest()
        {
            _userDataBreachesTest.AddDataBreach(_dataBreach1);
            _userDataBreachesTest.AddDataBreach(_dataBreach3);

            Assert.AreEqual(1, _userDataBreachesTest.DataBreaches.Count);
        }

        [TestMethod]
        public void AddTwoDataBreachesInSameHourAddsTheNewPasswordsTest()
        {
            _userDataBreachesTest.AddDataBreach(_dataBreach1);
            _userDataBreachesTest.AddDataBreach(_dataBreach3);

            DataBreach dataBreachInMemory = _userDataBreachesTest.DataBreaches.FirstOrDefault(db => db.Equals(_dataBreach1));

            Assert.AreEqual(4, dataBreachInMemory.PasswordBreaches.Count);
        }

        [TestMethod]
        public void AddTwoDataBreachesInSameHourAddsTheNewCreditCardsTest()
        {
            _userDataBreachesTest.AddDataBreach(_dataBreach1);
            _userDataBreachesTest.AddDataBreach(_dataBreach3);

            DataBreach dataBreachInMemory = _userDataBreachesTest.DataBreaches.FirstOrDefault(db => db.Equals(_dataBreach1));

            Assert.AreEqual(3, dataBreachInMemory.CreditCardBreaches.Count);
        }

        [TestMethod]
        public void GetDataBreachTest()
        {
            _userDataBreachesTest.AddDataBreach(_dataBreach1);

            Assert.AreEqual(_dataBreach1, _userDataBreachesTest.GetDataBreach(_dataBreach1.Date));
        }
    }
}
