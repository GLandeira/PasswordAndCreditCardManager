using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain.PasswordSecurityFlagger;

namespace DomainTests
{
    [TestClass]
    public class PasswordSecurityFlaggerTests
    {
        [TestMethod]
        public void TestRedLevelSecurityPassword()
        {
            String password = "abc123";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.RED, TestSecurityLevel);
        }

        [TestMethod]
        public void TestOrangeLevelSecurityPassword1()
        {
            String password = "abcdefgh";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.ORANGE, TestSecurityLevel);
        }

        [TestMethod]
        public void TestOrangeLevelSecurityPassword2()
        {
            String password = "123456789abcde";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.ORANGE, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersOnlyUppercasePassword()
        {
            String password = "ABCDEFGHIJKLMNO";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.YELLOW, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersOnlyLowercasePassword()
        {
            String password = "abcdefghijklmno";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.YELLOW, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersOnlyDigitsPassword()
        {
            String password = "123456789123456";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.YELLOW, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersOnlySpecialCharactersPassword()
        {
            String password = "@$#%&/:;<>[]{}-_";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.YELLOW, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersLowerAndUpperCasePassword()
        {
            String password = "aBcDeFgHiJkLmNO";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.LIGHT_GREEN, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersLowerCaseAndDigitsPassword()
        {
            String password = "a1b2cd3e4f5g6hi";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.YELLOW, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersLowerCaseAndSpecialCharsPassword()
        {
            String password = "abc@de#f$helloworld";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.YELLOW, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersUperCaseAndDigitsPassword()
        {
            String password = "A1B2C345DEFG121LMN";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.YELLOW, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersUpperCaseAndSpecialCharsPassword()
        {
            String password = "AB#$CDE%&FG@AAA";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.YELLOW, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersDigitsAndSpecialCharsPassword()
        {
            String password = "12#3$3256@@@??99";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.YELLOW, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersLowerCaseUpperCaseAndDigitsPassword()
        {
            String password = "aA23Bd2Cc77D3199";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.LIGHT_GREEN, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersLowerCaseUpperCaseAndSpecialCharsPassword()
        {
            String password = "bC@DD%hellOWOrld";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.LIGHT_GREEN, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersLowerCaseDigitsAndSpecialCharsPassword()
        {
            String password = "ab@gr357729#$privado";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.LIGHT_GREEN, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersUpperCaseDigitsAndSpecialCharsPassword()
        {
            String password = "INAKI3321@GG.HEL98WOR";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.LIGHT_GREEN, TestSecurityLevel);
        }

        [TestMethod]
        public void TestMoreThan14LettersLowerCaseUpperCaseDigitsAndSPecialCharsPassword()
        {
            String password = "InakiE34t%cg5#ar8y@aAa";
            SecurityLevelPasswords TestSecurityLevel = PasswordSecurityFlagger.GetSecurityLevel(password);
            Assert.AreEqual(SecurityLevelPasswords.DARK_GREEN, TestSecurityLevel);
        }
    }

}


