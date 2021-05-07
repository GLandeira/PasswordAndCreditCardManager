using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Exceptions;

namespace DomainTests
{
    [TestClass]
    public class VerifierTests
    {
        private CreditCard _creditCardTest;
        private Password _passwordTest;
        private User _userTest;
        private Category _categoryTest;

        [TestInitialize]
        public void TestInitialize()
        {
            //User part
            _userTest = new User
            {
                Name = "admin",
                MainPassword = "1234"
            };

            //Credit Card part
            _creditCardTest = new CreditCard
            {
                Name = "Visa Gold",
                Number = "1111111111111111",
                SecurityCode = "111",
                Notes = "super secreta, no compartir"
            };

            //Password part
            _passwordTest = new Password
            {
                PasswordString = "myPassword",
                Site = "www.testing.edu.uy",
                Username = "myUsername",
                Notes = "not shareable"
            };

            //Category part
            _categoryTest = new Category("Personal");
        }

        //-----------User TestMethods--------------------
        [ExpectedException(typeof(NameUserException))]
        [TestMethod]
        public void UserShortName()
        {
            _userTest.Name = "aaaa";
            Verifier.VerifyUser(_userTest);
        }

        [ExpectedException(typeof(NameUserException))]
        [TestMethod]
        public void UserLongName()
        {
            _userTest.Name = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            Verifier.VerifyUser(_userTest);
        }

        [ExpectedException(typeof(MainPasswordUserException))]
        [TestMethod]
        public void UserLongMainPassword()
        {
            _userTest.MainPassword = "aaaa";
            Verifier.VerifyUser(_userTest);
        }

        [ExpectedException(typeof(MainPasswordUserException))]
        [TestMethod]
        public void UserShortMainPassword()
        {
            _userTest.MainPassword = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            Verifier.VerifyUser(_userTest);
        }

        //-----------CreditCard TestMethods--------------------
        [ExpectedException(typeof(NameCreditCardException))]
        [TestMethod]
        public void CreditCardShortName()
        {
            _creditCardTest.Name = "aa";
            Verifier.VerifyCreditCard(_creditCardTest);
        }

        [ExpectedException(typeof(NameCreditCardException))]
        [TestMethod]
        public void CreditCardLongName()
        {
            _creditCardTest.Name = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            Verifier.VerifyCreditCard(_creditCardTest);
        }

        [ExpectedException(typeof(NumberCreditCardException))]
        [TestMethod]
        public void CreditCardLongNumber()
        {
            _creditCardTest.Number = "11111111111111112";
            Verifier.VerifyCreditCard(_creditCardTest);
        }

        [ExpectedException(typeof(NumberCreditCardException))]
        [TestMethod]
        public void CreditCardShortNumber()
        {
            _creditCardTest.Number = "111111111111110";
            Verifier.VerifyCreditCard(_creditCardTest);
        }

        [ExpectedException(typeof(NumberCreditCardException))]
        [TestMethod]
        public void CreditCardNumberNotBeingAllNumbers()
        { 
            _creditCardTest.Number = "1@1 1111c11111b1";
            Verifier.VerifyCreditCard(_creditCardTest);
        }

        [ExpectedException(typeof(SecurityCodeCreditCardException))]
        [TestMethod]
        public void CreditCardLongSecurityCode()
        {
            _creditCardTest.SecurityCode = "12345";
            Verifier.VerifyCreditCard(_creditCardTest);
        }

        [ExpectedException(typeof(SecurityCodeCreditCardException))]
        [TestMethod]
        public void CreditCardShortSecurityCode()
        {
            _creditCardTest.SecurityCode = "12";
            Verifier.VerifyCreditCard(_creditCardTest);
        }

        [ExpectedException(typeof(SecurityCodeCreditCardException))]
        [TestMethod]
        public void CreditCardSecurityCodeNotBeingAllNumbers()
        {
            _creditCardTest.SecurityCode = "12A";
            Verifier.VerifyCreditCard(_creditCardTest);
        }

        [ExpectedException(typeof(NotesException))]
        [TestMethod]
        public void CreditCardLongNotes()
        {
            _creditCardTest.Notes = "This note should bee too long, more than 250 " +
                "characters is actually a lot. When will i stop typing? its a " +
                "matter of time actually. You cant outrun time, dont even try " +
                "to skip some words in order to get to finish the sentence, you " +
                "will get there one day, and you will look back to the old days " +
                "where you were reading this, those good old days.";
                
            Verifier.VerifyCreditCard(_creditCardTest);
        }

        //-----------Password TestMethods--------------------
        [ExpectedException(typeof(NamePasswordException))]
        [TestMethod]
        public void PasswordShortSite()
        {
            _passwordTest.Site = "aaaa";
            Verifier.VerifyPassword(_passwordTest);
        }

        [ExpectedException(typeof(NamePasswordException))]
        [TestMethod]
        public void PasswordLongSite()
        {
            _passwordTest.Site = "abcdefghijklmnopqrstuvwxyz";
            Verifier.VerifyPassword(_passwordTest);
        }

        [ExpectedException(typeof(PasswordStringPasswordException))]
        [TestMethod]
        public void PasswordShortPasswordString()
        {
            _passwordTest.PasswordString = "aa";
            Verifier.VerifyPassword(_passwordTest);
        }

        [ExpectedException(typeof(PasswordStringPasswordException))]
        [TestMethod]
        public void PasswordLongPasswordString()
        {
            _passwordTest.PasswordString = "abcdefghijklmnopqrstuvwxyz";
            Verifier.VerifyPassword(_passwordTest);
        }

        [ExpectedException(typeof(UsernamePasswordException))]
        [TestMethod]
        public void PasswordShortUsername()
        {
            _passwordTest.Username = "aaaa";
            Verifier.VerifyPassword(_passwordTest);
        }

        [ExpectedException(typeof(UsernamePasswordException))]
        [TestMethod]
        public void PasswordLongUsername()
        {
            _passwordTest.Username = "abcdefghijklmnopqrstuvwxyz";
            Verifier.VerifyPassword(_passwordTest);
        }

        [ExpectedException(typeof(NotesException))]
        [TestMethod]
        public void PasswordLongNotes()
        {
            _passwordTest.Notes = "This note should bee too long, more than 250 " +
                "characters is actually a lot. When will i stop typing? its a " +
                "matter of time actually. You cant outrun time, dont even try " +
                "to skip some words in order to get to finish the sentence, you " +
                "will get there one day, and you will look back to the old days " +
                "where you were reading this, those good old days.";

            Verifier.VerifyPassword(_passwordTest);
        }

        ////-----------Category TestMethods--------------------
        [ExpectedException(typeof(NameCategoryException))]
        [TestMethod]
        public void CategoryShortName()
        {
            _categoryTest.Name = "aa";
            Verifier.VerifyCategory(_categoryTest);
        }

        [ExpectedException(typeof(NameCategoryException))]
        [TestMethod]
        public void CategoryLongName()
        {
            _categoryTest.Name = "abcdefghijklmnop";
            Verifier.VerifyCategory(_categoryTest);
        }
    }
}
 