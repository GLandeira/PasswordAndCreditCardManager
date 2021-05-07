using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.PasswordGenerator;
using Domain.Exceptions;

namespace DomainTests
{
    /// <summary>
    /// Summary description for PasswordGeneratorTests
    /// </summary>
    [TestClass]
    public class PasswordGeneratorTests
    {

        public PasswordGeneratorTests()
        {
        }


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GenerateAPasswordWithAllFalseSettingsThrowsException()
        {
            PasswordGenerationSettings generationSettings = new PasswordGenerationSettings();
            generationSettings.length =  13;
            generationSettings.hasMayus = false;
            generationSettings.hasMinus = false;
            generationSettings.hasSymbols = false;
            generationSettings.hasDigits = false;

            Assert.ThrowsException<InvalidPasswordGenerationSettingsException>(() => PasswordGenerator.GeneratePassword(generationSettings));
        }

        [TestMethod]
        public void GenerateAPasswordWithLengthCeroThrowsException()
        {
            int passwordLength = 0;

            PasswordGenerationSettings generationSettings = new PasswordGenerationSettings();
            generationSettings.length = passwordLength;
            generationSettings.hasMayus = true;
            generationSettings.hasMinus = false;
            generationSettings.hasSymbols = true;
            generationSettings.hasDigits = false;

            Assert.ThrowsException<InvalidPasswordGenerationSettingsException>(() => PasswordGenerator.GeneratePassword(generationSettings));
        }

        [TestMethod]
        public void GenerateVeryLongPasswordThrowsException()
        {
            int passwordLength = 26;

            PasswordGenerationSettings generationSettings = new PasswordGenerationSettings();
            generationSettings.length = passwordLength;
            generationSettings.hasMayus = true;
            generationSettings.hasMinus = false;
            generationSettings.hasSymbols = true;
            generationSettings.hasDigits = false;

            Assert.ThrowsException<InvalidPasswordGenerationSettingsException>(() => PasswordGenerator.GeneratePassword(generationSettings));
        }

        [TestMethod]
        public void GeneratePasswordWithSettingsLengthTwelveGeneratesALengthTwelvePassword()
        {
            int passwordLength = 12;

            PasswordGenerationSettings generationSettings = new PasswordGenerationSettings();
            generationSettings.length = passwordLength;
            generationSettings.hasMayus = false;
            generationSettings.hasMinus = true;
            generationSettings.hasSymbols = false;
            generationSettings.hasDigits = false;

            string generatedPassword = PasswordGenerator.GeneratePassword(generationSettings);

            Assert.AreEqual(passwordLength, generatedPassword.Length);
        }

        [TestMethod]
        public void GeneratePasswordWithMayusContainsMayus()
        {
            PasswordGenerationSettings generationSettings = new PasswordGenerationSettings();
            generationSettings.length = 8;
            generationSettings.hasMayus = true;
            generationSettings.hasMinus = false;
            generationSettings.hasSymbols = false;
            generationSettings.hasDigits = false;

            string generatedPassword = PasswordGenerator.GeneratePassword(generationSettings);

            // If IndexOfAny computes -1, it means that none of the characters in the input are in the string.
            // If its different to -1, then it means that atleast one of the caracters in the list
            // is in the string.
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(CharacterConstants.ALL_MAYUS_CHARACTERS));
        }

        [TestMethod]
        public void GeneratePasswordWithMinusContainsMinus()
        {
            PasswordGenerationSettings generationSettings = new PasswordGenerationSettings();
            generationSettings.length = 5;
            generationSettings.hasMayus = false;
            generationSettings.hasMinus = true;
            generationSettings.hasSymbols = false;
            generationSettings.hasDigits = false;

            string generatedPassword = PasswordGenerator.GeneratePassword(generationSettings);

            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(CharacterConstants.ALL_MINUS_CHARACTERS));
        }

        [TestMethod]
        public void GeneratePasswordWithDigitsContainsDigits()
        {
            PasswordGenerationSettings generationSettings = new PasswordGenerationSettings();
            generationSettings.length = 3;
            generationSettings.hasMayus = false;
            generationSettings.hasMinus = false;
            generationSettings.hasSymbols = false;
            generationSettings.hasDigits = true;

            string generatedPassword = PasswordGenerator.GeneratePassword(generationSettings);

            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(CharacterConstants.ALL_DIGIT_CHARACTERS));
        }

        [TestMethod]
        public void GeneratePasswordWithSymbolsContainsSymbols()
        {
            PasswordGenerationSettings generationSettings = new PasswordGenerationSettings();
            generationSettings.length = 4;
            generationSettings.hasMayus = false;
            generationSettings.hasMinus = false;
            generationSettings.hasSymbols = true;
            generationSettings.hasDigits = false;

            string generatedPassword = PasswordGenerator.GeneratePassword(generationSettings);

            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(CharacterConstants.ALL_SYMBOL_CHARACTERS));
        }

        [TestMethod]
        public void GeneratePasswordWithMinusMayusContainsMinusMayus()
        {
            PasswordGenerationSettings generationSettings = new PasswordGenerationSettings();
            generationSettings.length = 24;
            generationSettings.hasMayus = true;
            generationSettings.hasMinus = true;
            generationSettings.hasSymbols = false;
            generationSettings.hasDigits = false;

            string generatedPassword = PasswordGenerator.GeneratePassword(generationSettings);

            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(CharacterConstants.ALL_MAYUS_CHARACTERS));
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(CharacterConstants.ALL_MINUS_CHARACTERS));
        }

        [TestMethod]
        public void GeneratePasswordWithAllContainsAll()
        {
            PasswordGenerationSettings generationSettings = new PasswordGenerationSettings();
            generationSettings.length = 18;
            generationSettings.hasMayus = true;
            generationSettings.hasMinus = true;
            generationSettings.hasSymbols = true;
            generationSettings.hasDigits = true;

            string generatedPassword = PasswordGenerator.GeneratePassword(generationSettings);

            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(CharacterConstants.ALL_SYMBOL_CHARACTERS));
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(CharacterConstants.ALL_MINUS_CHARACTERS));
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(CharacterConstants.ALL_MAYUS_CHARACTERS));
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(CharacterConstants.ALL_DIGIT_CHARACTERS));
        }

        [TestMethod]
        public void GeneratePasswordFulfillsAllCriteria()
        {
            int passwordLength = 19;

            PasswordGenerationSettings generationSettings = new PasswordGenerationSettings();
            generationSettings.length = passwordLength;
            generationSettings.hasMayus = true;
            generationSettings.hasMinus = true;
            generationSettings.hasSymbols = true;
            generationSettings.hasDigits = false;

            string generatedPassword = PasswordGenerator.GeneratePassword(generationSettings);

            Assert.IsTrue(generatedPassword.Length == passwordLength);
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(CharacterConstants.ALL_MAYUS_CHARACTERS));
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(CharacterConstants.ALL_MINUS_CHARACTERS));
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(CharacterConstants.ALL_SYMBOL_CHARACTERS));
            Assert.IsTrue(-1 == generatedPassword.IndexOfAny(CharacterConstants.ALL_DIGIT_CHARACTERS));
        }
    }
}
