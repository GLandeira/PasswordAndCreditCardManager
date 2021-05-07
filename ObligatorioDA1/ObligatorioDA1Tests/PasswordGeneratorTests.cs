using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.PasswordGenerator;
using Domain.Exceptions;

namespace DomainTests
{
    [TestClass]
    public class PasswordGeneratorTests
    {
        private PasswordGenerationSettings _generationSettings;

        [TestInitialize]
        public void TestInitialize()
        {
            _generationSettings = new PasswordGenerationSettings();
        }
            [TestMethod]
        public void GenerateAPasswordWithAllFalseSettingsThrowsException()
        {
            _generationSettings.length =  13;
            _generationSettings.hasMayus = false;
            _generationSettings.hasMinus = false;
            _generationSettings.hasSymbols = false;
            _generationSettings.hasDigits = false;

            Assert.ThrowsException<InvalidPasswordGenerationSettingsException>(() => PasswordGenerator.GeneratePassword(_generationSettings));
        }

        [TestMethod]
        public void GenerateAPasswordWithLengthCeroThrowsException()
        {
            _generationSettings.length = 0;
            _generationSettings.hasMayus = true;
            _generationSettings.hasMinus = false;
            _generationSettings.hasSymbols = true;
            _generationSettings.hasDigits = false;

            Assert.ThrowsException<InvalidPasswordGenerationSettingsException>(() => PasswordGenerator.GeneratePassword(_generationSettings));
        }

        [TestMethod]
        public void GenerateVeryLongPasswordThrowsException()
        {
            _generationSettings.length = 26;
            _generationSettings.hasMayus = true;
            _generationSettings.hasMinus = false;
            _generationSettings.hasSymbols = true;
            _generationSettings.hasDigits = false;

            Assert.ThrowsException<InvalidPasswordGenerationSettingsException>(() => PasswordGenerator.GeneratePassword(_generationSettings));
        }

        [TestMethod]
        public void GeneratePasswordWithSettingsLengthTwelveGeneratesALengthTwelvePassword()
        {
            _generationSettings.length = 12;
            _generationSettings.hasMayus = false;
            _generationSettings.hasMinus = true;
            _generationSettings.hasSymbols = false;
            _generationSettings.hasDigits = false;

            string generatedPassword = PasswordGenerator.GeneratePassword(_generationSettings);

            Assert.AreEqual(12, generatedPassword.Length);
        }

        [TestMethod]
        public void GeneratePasswordWithMayusContainsMayus()
        {
            _generationSettings.length = 8;
            _generationSettings.hasMayus = true;
            _generationSettings.hasMinus = false;
            _generationSettings.hasSymbols = false;
            _generationSettings.hasDigits = false;

            string generatedPassword = PasswordGenerator.GeneratePassword(_generationSettings);

            // If IndexOfAny computes -1, it means that none of the characters in the input are in the string.
            // If its different to -1, then it means that atleast one of the caracters in the list
            // is in the string.
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_MAYUS_CHARACTERS));
        }

        [TestMethod]
        public void GeneratePasswordWithMinusContainsMinus()
        {
            _generationSettings.length = 5;
            _generationSettings.hasMayus = false;
            _generationSettings.hasMinus = true;
            _generationSettings.hasSymbols = false;
            _generationSettings.hasDigits = false;

            string generatedPassword = PasswordGenerator.GeneratePassword(_generationSettings);

            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_MINUS_CHARACTERS));
        }

        [TestMethod]
        public void GeneratePasswordWithDigitsContainsDigits()
        {
            _generationSettings.length = 3;
            _generationSettings.hasMayus = false;
            _generationSettings.hasMinus = false;
            _generationSettings.hasSymbols = false;
            _generationSettings.hasDigits = true;

            string generatedPassword = PasswordGenerator.GeneratePassword(_generationSettings);

            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_DIGIT_CHARACTERS));
        }

        [TestMethod]
        public void GeneratePasswordWithSymbolsContainsSymbols()
        {
            _generationSettings.length = 4;
            _generationSettings.hasMayus = false;
            _generationSettings.hasMinus = false;
            _generationSettings.hasSymbols = true;
            _generationSettings.hasDigits = false;

            string generatedPassword = PasswordGenerator.GeneratePassword(_generationSettings);

            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_SYMBOL_CHARACTERS));
        }

        [TestMethod]
        public void GeneratePasswordWithMinusMayusContainsMinusMayus()
        {
            _generationSettings.length = 24;
            _generationSettings.hasMayus = true;
            _generationSettings.hasMinus = true;
            _generationSettings.hasSymbols = false;
            _generationSettings.hasDigits = false;

            string generatedPassword = PasswordGenerator.GeneratePassword(_generationSettings);

            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_MAYUS_CHARACTERS));
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_MINUS_CHARACTERS));
        }

        [TestMethod]
        public void GeneratePasswordWithAllContainsAll()
        {
            _generationSettings.length = 18;
            _generationSettings.hasMayus = true;
            _generationSettings.hasMinus = true;
            _generationSettings.hasSymbols = true;
            _generationSettings.hasDigits = true;

            string generatedPassword = PasswordGenerator.GeneratePassword(_generationSettings);

            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_SYMBOL_CHARACTERS));
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_MINUS_CHARACTERS));
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_MAYUS_CHARACTERS));
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_DIGIT_CHARACTERS));
        }

        [TestMethod]
        public void GeneratePasswordFulfillsAllCriteria()
        {
            int passwordLength = 19;

            _generationSettings.length = passwordLength;
            _generationSettings.hasMayus = true;
            _generationSettings.hasMinus = true;
            _generationSettings.hasSymbols = true;
            _generationSettings.hasDigits = false;

            string generatedPassword = PasswordGenerator.GeneratePassword(_generationSettings);

            Assert.IsTrue(generatedPassword.Length == passwordLength);
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_MAYUS_CHARACTERS));
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_MINUS_CHARACTERS));
            Assert.IsTrue(-1 != generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_SYMBOL_CHARACTERS));
            Assert.IsTrue(-1 == generatedPassword.IndexOfAny(PasswordGeneratorConstants.ALL_DIGIT_CHARACTERS));
        }
    }
}
