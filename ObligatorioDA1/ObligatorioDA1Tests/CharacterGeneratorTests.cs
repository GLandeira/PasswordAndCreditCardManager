using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Domain.PasswordGenerator;

namespace DomainTests
{
    /// <summary>
    /// Summary description for CharacterGeneratorTests
    /// </summary>
    [TestClass]
    public class CharacterGeneratorTests
    {

        public CharacterGeneratorTests()
        {
            //
            // TODO: Add constructor logic here
            //
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
        public void GenerateCharacterOfTypeMayusGeneratesAMayusCharacter()
        {
            CharacterGenerator generator = new MayusCharacterGenerator();

            char characterGenerated = generator.GenerateCharacter();
            Assert.IsTrue(
                PasswordGeneratorConstants.ALL_MAYUS_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
        }

        [TestMethod]
        public void GenerateCharacterOfTypeMinusGeneratesAMinusCharacter()
        {
            CharacterGenerator generator = new MinusCharacterGenerator();

            char characterGenerated = generator.GenerateCharacter();
            Assert.IsTrue(
                PasswordGeneratorConstants.ALL_MINUS_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
        }

        [TestMethod]
        public void GenerateCharacterOfTypeDigitsGeneratesADigitsCharacter()
        {
            CharacterGenerator generator = new DigitCharacterGenerator();

            char characterGenerated = generator.GenerateCharacter();
            Assert.IsTrue(
                PasswordGeneratorConstants.ALL_DIGIT_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
        }

        [TestMethod]
        public void GenerateCharacterOfTypeSymbolsGeneratesASymbolsCharacter()
        {
            CharacterGenerator generator = new SymbolCharacterGenerator();

            char characterGenerated = generator.GenerateCharacter();
            Assert.IsTrue(
                PasswordGeneratorConstants.ALL_SYMBOL_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
        }
    }
}
