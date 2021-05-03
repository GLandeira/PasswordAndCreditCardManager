using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Domain.Exceptions;

namespace DomainTests
{
    [TestClass]
    public class VerifierTests
    {
        UserCreditCard userCreditCardTest;
        CreditCard creditCard1;

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
                SecurityCode = "111",
                ValidDue = DateTime.Today,
                Category = trabajo,
                Notes = "super secreta, no compartir"
            };
        }

        [ExpectedException(typeof(NameCreditCardException))]
        [TestMethod]
        public void CreditCardShortName()
        {
            creditCard1.Name = "aa";
            Verifier.VerifyCreditCard(creditCard1);
            //creditCard1.Name = "Visa Gold";
        }

        [ExpectedException(typeof(NameCreditCardException))]
        [TestMethod]
        public void CreditCardLongName()
        {
            creditCard1.Name = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            Verifier.VerifyCreditCard(creditCard1);
        }

        [ExpectedException(typeof(NumberCreditCardException))]
        [TestMethod]
        public void CreditCardLongNumber()
        {
            creditCard1.Number = "11111111111111112";
            Verifier.VerifyCreditCard(creditCard1);
        }

        [ExpectedException(typeof(NumberCreditCardException))]
        [TestMethod]
        public void CreditCardShortNumber()
        {
            creditCard1.Number = "111111111111110";
            Verifier.VerifyCreditCard(creditCard1);
        }

        [ExpectedException(typeof(NumberCreditCardException))]
        [TestMethod]
        public void CreditCardNumberNotBeingAllNumbers()
        { 
            creditCard1.Number = "1@1 1111c11111b1";
            Verifier.VerifyCreditCard(creditCard1);
        }

        [ExpectedException(typeof(SecurityCodeCreditCardException))]
        [TestMethod]
        public void CreditCardDifferentLengthSecurityCode()
        {
            creditCard1.SecurityCode = "1234";
            Verifier.VerifyCreditCard(creditCard1);
        }

        [ExpectedException(typeof(SecurityCodeCreditCardException))]
        [TestMethod]
        public void CreditCardSecurityCodeNotBeingAllNumbers()
        {
            creditCard1.SecurityCode = "12A";
            Verifier.VerifyCreditCard(creditCard1);
        }

        [ExpectedException(typeof(NotesException))]
        [TestMethod]
        public void CreditCardNotesTooLong()
        {
            creditCard1.Notes = "This note should bee too long, more than 250 " +
                "characters is actually a lot. When will i stop typing? its a " +
                "matter of time actually. You cant outrun time, dont even try " +
                "to skip some words in order to get to finish the sentence, you " +
                "will get there one day, and you will look back to the old days " +
                "were you where reading this, those good old days.";
                
            Verifier.VerifyCreditCard(creditCard1);
        }
    }
}
