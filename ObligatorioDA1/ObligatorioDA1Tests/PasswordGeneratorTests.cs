using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Exceptions;

namespace DomainTests
{
    /// <summary>
    /// Summary description for PasswordGeneratorTests
    /// </summary>
    [TestClass]
    public class PasswordGeneratorTests
    {
        private readonly char[] ALL_MAYUS_CHARACTERS = 
        { 
            'A', 'B', 'C', 'D', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O',
            'P', 'Q', 'R', 'S' , 'T', 'U', 'V',
            'W', 'X', 'Y', 'Z'
        };

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
        public void GeneratePasswordWithMayusLengthContainsMayus()
        {
            PasswordGenerationSettings generationSettings = new PasswordGenerationSettings();
            generationSettings.length = 8;
            generationSettings.hasMayus = true;
            generationSettings.hasMinus = false;
            generationSettings.hasSymbols = false;
            generationSettings.hasDigits = false;

            string generatedPassword = PasswordGenerator.GeneratePassword(generationSettings);

            Assert.IsTrue(-1 == generatedPassword.IndexOfAny(ALL_MAYUS_CHARACTERS));
        }
    }
}
