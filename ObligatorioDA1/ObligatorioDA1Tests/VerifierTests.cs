using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Domain.Exceptions;

namespace DomainTests
{
    [TestClass]
    public class VerifierTests
    {
        CreditCard creditCardTest;
        Password passwordTest;
        User userTest;
        Category categoryTest;

        [TestInitialize]
        public void TestInitialize()
        {
            //User part
            userTest = new User
            {
                Name = "admin",
                MainPassword = "1234"
            };

            //Credit Card part
            creditCardTest = new CreditCard
            {
                Name = "Visa Gold",
                Number = "1111111111111111",
                SecurityCode = "111",
                Notes = "super secreta, no compartir"
            };

            //Password part
            passwordTest = new Password
            {
                PasswordString = "myPassword",
                Site = "www.testing.edu.uy",
                Username = "myUsername",
                Notes = "not shareable"
            };

            //Category part
            categoryTest = new Category("Personal");
        }

        //-----------User TestMethods--------------------
        [ExpectedException(typeof(NameUserException))]
        [TestMethod]
        public void UserShortName()
        {
            userTest.Name = "aaaa";
            Verifier.VerifyUser(userTest);
        }

        [ExpectedException(typeof(NameUserException))]
        [TestMethod]
        public void UserLongName()
        {
            userTest.Name = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            Verifier.VerifyUser(userTest);
        }

        [ExpectedException(typeof(MainPasswordUserException))]
        [TestMethod]
        public void UserLongMainPassword()
        {
            userTest.MainPassword = "aaaa";
            Verifier.VerifyUser(userTest);
        }

        [ExpectedException(typeof(MainPasswordUserException))]
        [TestMethod]
        public void UserShortMainPassword()
        {
            userTest.MainPassword = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            Verifier.VerifyUser(userTest);
        }

        //-----------CreditCard TestMethods--------------------
        [ExpectedException(typeof(NameCreditCardException))]
        [TestMethod]
        public void CreditCardShortName()
        {
            creditCardTest.Name = "aa";
            Verifier.VerifyCreditCard(creditCardTest);
        }

        [ExpectedException(typeof(NameCreditCardException))]
        [TestMethod]
        public void CreditCardLongName()
        {
            creditCardTest.Name = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            Verifier.VerifyCreditCard(creditCardTest);
        }

        [ExpectedException(typeof(NumberCreditCardException))]
        [TestMethod]
        public void CreditCardLongNumber()
        {
            creditCardTest.Number = "11111111111111112";
            Verifier.VerifyCreditCard(creditCardTest);
        }

        [ExpectedException(typeof(NumberCreditCardException))]
        [TestMethod]
        public void CreditCardShortNumber()
        {
            creditCardTest.Number = "111111111111110";
            Verifier.VerifyCreditCard(creditCardTest);
        }

        [ExpectedException(typeof(NumberCreditCardException))]
        [TestMethod]
        public void CreditCardNumberNotBeingAllNumbers()
        { 
            creditCardTest.Number = "1@1 1111c11111b1";
            Verifier.VerifyCreditCard(creditCardTest);
        }

        [ExpectedException(typeof(SecurityCodeCreditCardException))]
        [TestMethod]
        public void CreditCardLongSecurityCode()
        {
            creditCardTest.SecurityCode = "12345";
            Verifier.VerifyCreditCard(creditCardTest);
        }

        [ExpectedException(typeof(SecurityCodeCreditCardException))]
        [TestMethod]
        public void CreditCardShortSecurityCode()
        {
            creditCardTest.SecurityCode = "12";
            Verifier.VerifyCreditCard(creditCardTest);
        }

        [ExpectedException(typeof(SecurityCodeCreditCardException))]
        [TestMethod]
        public void CreditCardSecurityCodeNotBeingAllNumbers()
        {
            creditCardTest.SecurityCode = "12A";
            Verifier.VerifyCreditCard(creditCardTest);
        }

        [ExpectedException(typeof(NotesException))]
        [TestMethod]
        public void CreditCardLongNotes()
        {
            creditCardTest.Notes = "This note should bee too long, more than 250 " +
                "characters is actually a lot. When will i stop typing? its a " +
                "matter of time actually. You cant outrun time, dont even try " +
                "to skip some words in order to get to finish the sentence, you " +
                "will get there one day, and you will look back to the old days " +
                "where you were reading this, those good old days.";
                
            Verifier.VerifyCreditCard(creditCardTest);
        }

        //-----------Password TestMethods--------------------
        [ExpectedException(typeof(NamePasswordException))]
        [TestMethod]
        public void PasswordShortSite()
        {
            passwordTest.Site = "aaaa";
            Verifier.VerifyPassword(passwordTest);
        }

        [ExpectedException(typeof(NamePasswordException))]
        [TestMethod]
        public void PasswordLongSite()
        {
            passwordTest.Site = "abcdefghijklmnopqrstuvwxyz";
            Verifier.VerifyPassword(passwordTest);
        }

        [ExpectedException(typeof(PasswordStringPasswordException))]
        [TestMethod]
        public void PasswordShortPasswordString()
        {
            passwordTest.PasswordString = "aa";
            Verifier.VerifyPassword(passwordTest);
        }

        [ExpectedException(typeof(PasswordStringPasswordException))]
        [TestMethod]
        public void PasswordLongPasswordString()
        {
            passwordTest.PasswordString = "abcdefghijklmnopqrstuvwxyz";
            Verifier.VerifyPassword(passwordTest);
        }

        [ExpectedException(typeof(UsernamePasswordException))]
        [TestMethod]
        public void PasswordShortUsername()
        {
            passwordTest.Username = "aaaa";
            Verifier.VerifyPassword(passwordTest);
        }

        [ExpectedException(typeof(UsernamePasswordException))]
        [TestMethod]
        public void PasswordLongUsername()
        {
            passwordTest.Username = "abcdefghijklmnopqrstuvwxyz";
            Verifier.VerifyPassword(passwordTest);
        }

        [ExpectedException(typeof(NotesException))]
        [TestMethod]
        public void PasswordLongNotes()
        {
            passwordTest.Notes = "This note should bee too long, more than 250 " +
                "characters is actually a lot. When will i stop typing? its a " +
                "matter of time actually. You cant outrun time, dont even try " +
                "to skip some words in order to get to finish the sentence, you " +
                "will get there one day, and you will look back to the old days " +
                "where you were reading this, those good old days.";

            Verifier.VerifyPassword(passwordTest);
        }

        ////-----------Category TestMethods--------------------
        [ExpectedException(typeof(NameCategoryException))]
        [TestMethod]
        public void CategoryShortName()
        {
            categoryTest.Name = "aa";
            Verifier.VerifyCategory(categoryTest);
        }

        [ExpectedException(typeof(NameCategoryException))]
        [TestMethod]
        public void CategoryLongName()
        {
            categoryTest.Name = "abcdefghijklmnop";
            Verifier.VerifyCategory(categoryTest);
        }
    }
}
 