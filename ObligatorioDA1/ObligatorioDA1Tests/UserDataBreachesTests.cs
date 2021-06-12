using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using System.Collections.Generic;

namespace DomainTests
{
    [TestClass]
    public class UserDataBreachesTests
    {
        private UserDataBreaches _userDataBreachesTest;
        private DataBreach _dataBreach1;
        private DataBreach _dataBreach2;
        private DataBreach _dataBreach3;

        [TestInitialize]
        public void TestInitialize()
        {
            _userDataBreachesTest = new UserDataBreaches();

            List<PasswordHistory> fakePasswordHistories1 = new List<PasswordHistory>();
            fakePasswordHistories1.Add(new PasswordHistory(1, "OldPassword"));
            fakePasswordHistories1.Add(new PasswordHistory(1, "SecondOldPassword"));
            fakePasswordHistories1.Add(new PasswordHistory(2, "SomeOldPassword"));

            List<CreditCard> fakeCreditCards1 = new List<CreditCard>();
            fakeCreditCards1.Add(new CreditCard());

            _dataBreach1 = new DataBreach();
            _dataBreach1.PasswordBreaches = fakePasswordHistories1;
            _dataBreach1.CreditCardBreaches = fakeCreditCards1;
            _dataBreach1.Date = DateTime.Today;
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
        public void GetDataBreachTest()
        {
            _userDataBreachesTest.AddDataBreach(_dataBreach1);

            Assert.AreEqual(_dataBreach1, _userDataBreachesTest.GetDataBreach(_dataBreach1.Date));
        }
    }
}
