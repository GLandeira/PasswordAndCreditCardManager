using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Domain.Exceptions;

namespace DomainTests
{
    [TestClass]
    public class UserCreditCardTests
    {
        private UserCreditCard _userCreditCardTest;
        private CreditCard _creditCard1;
        private CreditCard _creditCard2;
        private CreditCard _creditCard3;

        [TestInitialize]
        public void TestInitialize()
        {
            _userCreditCardTest = new UserCreditCard();

            Category trabajo = new Category("Trabajo");
            CardTypes visa = CardTypes.VISA;
            _creditCard1 = new CreditCard
            {
                Name = "Visa Gold",
                Type = visa,
                Number = "1111111111111111",
                SecurityCode = "1234",
                ValidDue = DateTime.Today,
                Category = trabajo,
                Notes = "super secreta, no compartir"
            };

            Category personal = new Category("Personal");
            CardTypes master = CardTypes.MASTERCARD;
            _creditCard2 = new CreditCard
            {
                Name = "Master",
                Type = master,
                Number = "2222222222222222",
                SecurityCode = "143",
                ValidDue = DateTime.Today,
                Category = personal,
                Notes = "para compartir"
            };

            _creditCard3 = new CreditCard
            {
                Name = "Visa Platinum",
                Type = visa,
                Number = "3333333333333333",
                SecurityCode = "123",
                ValidDue = DateTime.Today,
                Category = trabajo,
                Notes = ""
            };
        }

        [TestMethod]
        public void AddOneCreditCardToListCheckCount()
        {
            _userCreditCardTest.AddCreditCard(_creditCard1);
            Assert.AreEqual(1, _userCreditCardTest.CreditCards.Count);
        }

        [TestMethod]
        public void AddThreeCreditCardsToListCheckIfANameIsThere()
        {
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.AddCreditCard(_creditCard2);
            _userCreditCardTest.AddCreditCard(_creditCard3);
            bool numberIsEqual = false;

            foreach (CreditCard creditCard in _userCreditCardTest.CreditCards)
            {
                if (creditCard == _creditCard2)
                {
                    numberIsEqual = true;
                }
            }

            Assert.AreEqual(true, numberIsEqual);
        }

        [TestMethod]
        public void RemoveCreditCardAddedToTheList()
        {
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.RemoveCreditCard(_creditCard1);
            Assert.AreEqual(0, _userCreditCardTest.CreditCards.Count);
        }

        [TestMethod]
        public void RemoveSecondCreditCardAddedToTheList()
        {
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.AddCreditCard(_creditCard2);
            _userCreditCardTest.RemoveCreditCard(_creditCard2);
            bool numberIsEqual = false;

            foreach (CreditCard creditCard in _userCreditCardTest.CreditCards)
            {
                if (creditCard == _creditCard2)
                {
                    numberIsEqual = true;
                }
            }
            Assert.AreEqual(false, numberIsEqual);
        }

        [ExpectedException(typeof(CreditCardNotFoundException))]
        [TestMethod]
        public void RemoveCreditCardWithNoItemsInTheList()
        {
            _userCreditCardTest.RemoveCreditCard(_creditCard1);
        }

        [ExpectedException(typeof(CreditCardNotFoundException))]
        [TestMethod]
        public void RemoveCreditCardItemsInTheListButIsntPresent()
        {
            _userCreditCardTest.AddCreditCard(_creditCard2);
            _userCreditCardTest.AddCreditCard(_creditCard3);
            _userCreditCardTest.RemoveCreditCard(_creditCard1);
        }

        [TestMethod]
        public void ModifyOneCreditCardNameAddedToTheListWithJustOneCreditCard()
        {
            _userCreditCardTest.AddCreditCard(_creditCard1);

            Category trabajo = new Category("Trabajo");
            CardTypes visa = CardTypes.VISA;
            CreditCard creditCardChangeTest = new CreditCard
            {
                Name = "Visa Platinum",
                Type = visa,
                Number = "1111111111111112",
                SecurityCode = "123",
                ValidDue = DateTime.Today,
                Category = trabajo,
                Notes = ""
            };

            _userCreditCardTest.ModifyCreditCard(_creditCard1, creditCardChangeTest);
  
            bool numberIsEqual = false;
            foreach (CreditCard creditCard in _userCreditCardTest.CreditCards)
            {
                if (creditCard == creditCardChangeTest)
                {
                    numberIsEqual = true;
                }
            }
            Assert.AreEqual(true, numberIsEqual);
        }

        [TestMethod]
        public void ModifyACreditCardAddedToTheListWithMultipleCreditCards()
        {
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.AddCreditCard(_creditCard2);
            _userCreditCardTest.AddCreditCard(_creditCard3);

            Category trabajo = new Category("Trabajo");
            CardTypes visa = CardTypes.VISA;
            CreditCard creditCardChangeTest = new CreditCard
            {
                Name = "Visa Platinum",
                Type = visa,
                Number = "4444444444444444",
                SecurityCode = "123",
                ValidDue = new DateTime(2022, 12, 31),
                Category = trabajo,
                Notes = "La modifique a esta"
            };

            _userCreditCardTest.ModifyCreditCard(_creditCard1, creditCardChangeTest);

            bool numberIsEqual = false;
            foreach (CreditCard creditCard in _userCreditCardTest.CreditCards)
            {
                if (creditCard == creditCardChangeTest)
                {
                    numberIsEqual = true;
                }
            }
            Assert.AreEqual(true, numberIsEqual);
        }

        [TestMethod]
        public void ModifyACreditCardAddedToTheListLeavingSameNumber()
        {
            _userCreditCardTest.AddCreditCard(_creditCard1);
            Category personal = new Category("Personal");
            CardTypes master = CardTypes.MASTERCARD;
            CreditCard creditCardChangeTest = new CreditCard
            {
                Name = "Visa Platinum",
                Type = master,
                Number = "1111111111111111",
                SecurityCode = "123",
                ValidDue = new DateTime(2022, 12, 31),
                Category = personal,
                Notes = "La modifique a esta"
            };

            _userCreditCardTest.ModifyCreditCard(_creditCard1, creditCardChangeTest);

            bool numberIsEqual = false;
            foreach (CreditCard creditCard in _userCreditCardTest.CreditCards)
            {
                if (creditCard == creditCardChangeTest)
                {
                    numberIsEqual = true;
                }
            }
            Assert.AreEqual(true, numberIsEqual);
        }

        [ExpectedException(typeof(CreditCardRepeatedException))]
        [TestMethod]
        public void AddSameCreditCardTwice()
        {
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.AddCreditCard(_creditCard2);
            _userCreditCardTest.AddCreditCard(_creditCard1);
        }

        [ExpectedException(typeof(CreditCardRepeatedException))]
        [TestMethod]
        public void ModifyCreditCardAndAddOneThatIsAlreadyInTheList()
        {
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.AddCreditCard(_creditCard2);

            _userCreditCardTest.ModifyCreditCard(_creditCard1, _creditCard2);
        }

        [ExpectedException(typeof(CreditCardNotFoundException))]
        [TestMethod]
        public void ModifyCreditCardWithAnEmptyList()
        {
            _userCreditCardTest.ModifyCreditCard(_creditCard1, _creditCard2);
        }

        [TestMethod]
        public void GetCreditCardThatExistsInTheList()
        {
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.AddCreditCard(_creditCard2);
            CreditCard creditCardTest = _userCreditCardTest.GetCreditCard("2222222222222222");

            Assert.AreEqual("2222222222222222", creditCardTest.Number);
        }

        [ExpectedException(typeof(CreditCardNotFoundException))]
        [TestMethod]
        public void GetCreditCardThatNotExistsInTheList()
        {
            _userCreditCardTest.AddCreditCard(_creditCard1);
            _userCreditCardTest.AddCreditCard(_creditCard2);
            _userCreditCardTest.AddCreditCard(_creditCard3);
            CreditCard creditCardTest = _userCreditCardTest.GetCreditCard("4444444444444444");
        }
    }
}
