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

        private PasswordHistory _password1;
        private PasswordHistory _password2;
        private PasswordHistory _password3;
        private PasswordHistory _password4;
        private PasswordHistory _password5;
        private PasswordHistory _password6;

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

            _password1 = new PasswordHistory(1, "OldPassword");
            _password2 = new PasswordHistory(2, "SecondOldPassword");
            _password3 = new PasswordHistory(3, "SomeOldPassword");
            _password4 = new PasswordHistory(4, "AnotherOtherPassword");
            _password5 = new PasswordHistory(5, "MoreOldPasswords");
            _password6 = new PasswordHistory(6, "OldestPassword");

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
            fakePasswordHistories1.Add(_password1);
            fakePasswordHistories1.Add(_password2);
            fakePasswordHistories1.Add(_password3);

            List<CreditCard> fakeCreditCards1 = new List<CreditCard>();
            fakeCreditCards1.Add(_creditCard1);
            fakeCreditCards1.Add(_creditCard4);

            _dataBreach1 = new DataBreach();
            _dataBreach1.PasswordBreaches = fakePasswordHistories1;
            _dataBreach1.CreditCardBreaches = fakeCreditCards1;
            _dataBreach1.Date = DateTime.Today;

            List<PasswordHistory> fakePasswordHistories2 = new List<PasswordHistory>();
            fakePasswordHistories2.Add(_password4);
            fakePasswordHistories2.Add(_password5);
            fakePasswordHistories2.Add(_password6);

            List<CreditCard> fakeCreditCards2 = new List<CreditCard>();
            fakeCreditCards2.Add(_creditCard2);
            fakeCreditCards2.Add(_creditCard3);

            _dataBreach2 = new DataBreach();
            _dataBreach2.PasswordBreaches = fakePasswordHistories2;
            _dataBreach2.CreditCardBreaches = fakeCreditCards2;
            _dataBreach2.Date = DateTime.Today.AddHours(3);

            List<PasswordHistory> fakePasswordHistories3 = new List<PasswordHistory>();
            fakePasswordHistories3.Add(_password1);
            fakePasswordHistories3.Add(_password3);
            fakePasswordHistories3.Add(_password5);

            List<CreditCard> fakeCreditCards3 = new List<CreditCard>();
            fakeCreditCards3.Add(_creditCard4);
            fakeCreditCards3.Add(_creditCard6);

            _dataBreach3 = new DataBreach();
            _dataBreach3.PasswordBreaches = fakePasswordHistories3;
            _dataBreach3.CreditCardBreaches = fakeCreditCards3;
            _dataBreach3.Date = DateTime.Today;

            List<PasswordHistory> fakePasswordHistories4 = new List<PasswordHistory>();
            fakePasswordHistories4.Add(_password1);
            fakePasswordHistories4.Add(_password3);
            fakePasswordHistories4.Add(_password5);

            List<CreditCard> fakeCreditCards4 = new List<CreditCard>();
            fakeCreditCards4.Add(_creditCard4);
            fakeCreditCards4.Add(_creditCard6);

            _dataBreach4 = new DataBreach();
            _dataBreach4.PasswordBreaches = fakePasswordHistories4;
            _dataBreach4.CreditCardBreaches = fakeCreditCards4;
            _dataBreach4.Date = DateTime.Today.AddDays(3);
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
            _userDataBreachesTest.AddDataBreach(_dataBreach2);
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
