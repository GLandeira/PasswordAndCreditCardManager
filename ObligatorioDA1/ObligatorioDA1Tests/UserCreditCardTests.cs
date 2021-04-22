using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;


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
                Number = "1111 1111 1111 1111",
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
                Number = "2222 2222 2222 2222",
                ValidDue = DateTime.Today,
                Category = personal,
                Notes = "para compartir"
            };
            creditCard3 = new CreditCard
            {
                Name = "Visa Platinum",
                Type = visa,
                Number = "3333 3333 3333 3333",
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
            bool nameIsEqual = false;

            foreach (CreditCard creditCard in userCreditCardTest.CreditCards)
            {
                if (creditCard == creditCard2)
                {
                    nameIsEqual = true;
                }
            }

            Assert.AreEqual(true, nameIsEqual);
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
            bool nameIsEqual = false;

            foreach (CreditCard creditCard in userCreditCardTest.CreditCards)
            {
                if (creditCard == creditCard2)
                {
                    nameIsEqual = true;
                }
            }
            Assert.AreEqual(false, nameIsEqual);
        }
        public void modifyACreditCardAddedToTheList()
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

            userCreditCardTest.modifyCreditCard(creditCard1, creditCardChangeTest);

            bool nameIsEqual = false;
            foreach (CreditCard creditCard in userCreditCardTest.CreditCards)
            {
                if (creditCard == creditCardChangeTest)
                {
                    nameIsEqual = true;
                }
            }
            Assert.AreEqual(true, nameIsEqual);
        }
    }
}
