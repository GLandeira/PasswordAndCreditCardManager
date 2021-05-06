using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Domain.Exceptions;


namespace DomainTests
{
    [TestClass]
    public class UserCreditCardTests
    {
        UserCreditCard userCreditCardTest;
        CreditCard creditCard1;
        CreditCard creditCard2;
        CreditCard creditCard3;

        [TestInitialize]
        public void TestInitialize()
        {
            userCreditCardTest = new UserCreditCard();

            Category trabajo = new Category("Trabajo");
            CardTypes visa = CardTypes.VISA;
            creditCard1 = new CreditCard
            {
                Name = "Visa Gold",
                Type = visa,
                Number = "1111111111111111",
                ValidDue = DateTime.Today,
                Category = trabajo,
                Notes = "super secreta, no compartir"
            };

            Category personal = new Category("Personal");
            CardTypes master = CardTypes.MASTERCARD;
            creditCard2 = new CreditCard
            {
                Name = "Master",
                Type = master,
                Number = "2222222222222222",
                ValidDue = DateTime.Today,
                Category = personal,
                Notes = "para compartir"
            };

            creditCard3 = new CreditCard
            {
                Name = "Visa Platinum",
                Type = visa,
                Number = "3333333333333333",
                ValidDue = DateTime.Today,
                Category = trabajo,
                Notes = ""
            };
        }

        [TestMethod]
        public void AddOneCreditCardToListCheckCount()
        {
            userCreditCardTest.AddCreditCard(creditCard1);
            Assert.AreEqual(1, userCreditCardTest.CreditCards.Count);
        }

        [TestMethod]
        public void AddThreeCreditCardsToListCheckIfANameIsThere()
        {
            userCreditCardTest.AddCreditCard(creditCard1);
            userCreditCardTest.AddCreditCard(creditCard2);
            userCreditCardTest.AddCreditCard(creditCard3);
            bool numberIsEqual = false;

            foreach (CreditCard creditCard in userCreditCardTest.CreditCards)
            {
                if (creditCard == creditCard2)
                {
                    numberIsEqual = true;
                }
            }

            Assert.AreEqual(true, numberIsEqual);
        }

        [TestMethod]
        public void RemoveCreditCardAddedToTheList()
        {
            userCreditCardTest.AddCreditCard(creditCard1);
            userCreditCardTest.RemoveCreditCard(creditCard1);
            Assert.AreEqual(0, userCreditCardTest.CreditCards.Count);
        }
        [TestMethod]
        public void RemoveSecondCreditCardAddedToTheList()
        {
            userCreditCardTest.AddCreditCard(creditCard1);
            userCreditCardTest.AddCreditCard(creditCard2);
            userCreditCardTest.RemoveCreditCard(creditCard2);
            bool numberIsEqual = false;

            foreach (CreditCard creditCard in userCreditCardTest.CreditCards)
            {
                if (creditCard == creditCard2)
                {
                    numberIsEqual = true;
                }
            }
            Assert.AreEqual(false, numberIsEqual);
        }

        [TestMethod]
        public void ModifyOneCreditCardNameAddedToTheListWithJustOneCreditCard()
        {
            userCreditCardTest.AddCreditCard(creditCard1);

            Category trabajo = new Category("Trabajo");
            CardTypes visa = CardTypes.VISA;
            CreditCard creditCardChangeTest = new CreditCard
            {
                Name = "Visa Platinum",
                Type = visa,
                Number = "1111 1111 1111 1112",
                ValidDue = DateTime.Today,
                Category = trabajo,
                Notes = ""
            };

            userCreditCardTest.ModifyCreditCard(creditCard1, creditCardChangeTest);
  
            bool numberIsEqual = false;
            foreach (CreditCard creditCard in userCreditCardTest.CreditCards)
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
            userCreditCardTest.AddCreditCard(creditCard1);
            userCreditCardTest.AddCreditCard(creditCard2);
            userCreditCardTest.AddCreditCard(creditCard3);

            Category trabajo = new Category("Trabajo");
            CardTypes visa = CardTypes.VISA;
            CreditCard creditCardChangeTest = new CreditCard
            {
                Name = "Visa Platinum",
                Type = visa,
                Number = "4444444444444444",
                ValidDue = new DateTime(2022, 12, 31),
                Category = trabajo,
                Notes = "La modifique a esta"
            };

            userCreditCardTest.ModifyCreditCard(creditCard1, creditCardChangeTest);

            bool numberIsEqual = false;
            foreach (CreditCard creditCard in userCreditCardTest.CreditCards)
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
            userCreditCardTest.AddCreditCard(creditCard1);
            Category personal = new Category("Personal");
            CardTypes master = CardTypes.MASTERCARD;
            CreditCard creditCardChangeTest = new CreditCard
            {
                Name = "Visa Platinum",
                Type = master,
                Number = "1111111111111111",
                ValidDue = new DateTime(2022, 12, 31),
                Category = personal,
                Notes = "La modifique a esta"
            };

            userCreditCardTest.ModifyCreditCard(creditCard1, creditCardChangeTest);

            bool numberIsEqual = false;
            foreach (CreditCard creditCard in userCreditCardTest.CreditCards)
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
            userCreditCardTest.AddCreditCard(creditCard1);
            userCreditCardTest.AddCreditCard(creditCard2);
            userCreditCardTest.AddCreditCard(creditCard1);
        }

        [ExpectedException(typeof(CreditCardRepeatedException))]
        [TestMethod]
        public void ModifyCreditCardAndAddOneThatIsAlreadyInTheList()
        {
            userCreditCardTest.AddCreditCard(creditCard1);
            userCreditCardTest.AddCreditCard(creditCard2);

            userCreditCardTest.ModifyCreditCard(creditCard1, creditCard2);
        }

        [TestMethod]
        public void GetCreditCardThatExistsInTheList()
        {
            userCreditCardTest.AddCreditCard(creditCard1);
            userCreditCardTest.AddCreditCard(creditCard2);
            CreditCard creditCardTest = userCreditCardTest.GetCreditCard("2222222222222222");

            Assert.AreEqual("2222222222222222", creditCardTest.Number);
        }

        [ExpectedException(typeof(CreditCardNotFoundException))]
        [TestMethod]
        public void GetCreditCardThatNotExistsInTheList()
        {
            userCreditCardTest.AddCreditCard(creditCard1);
            userCreditCardTest.AddCreditCard(creditCard2);
            userCreditCardTest.AddCreditCard(creditCard3);
            CreditCard creditCardTest = userCreditCardTest.GetCreditCard("4444444444444444");
        }
    }
}
