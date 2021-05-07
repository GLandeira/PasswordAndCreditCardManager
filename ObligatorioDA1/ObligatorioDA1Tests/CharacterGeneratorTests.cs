using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.PasswordGenerator;

namespace DomainTests
{
    [TestClass]
    public class CharacterGeneratorTests
    {
        [TestMethod]
        public void GenerateCharacterOfTypeMayusGeneratesAMayusCharacter()
        {
            CharacterGenerator generator = new MayusCharacterGenerator();

            char characterGenerated = generator.GenerateCharacter();
            Assert.IsTrue(
                CharacterConstants.ALL_MAYUS_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
        }

        [TestMethod]
        public void GenerateCharacterOfTypeMinusGeneratesAMinusCharacter()
        {
            CharacterGenerator generator = new MinusCharacterGenerator();

            char characterGenerated = generator.GenerateCharacter();
            Assert.IsTrue(
                CharacterConstants.ALL_MINUS_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
        }

        [TestMethod]
        public void GenerateCharacterOfTypeDigitsGeneratesADigitsCharacter()
        {
            CharacterGenerator generator = new DigitCharacterGenerator();

            char characterGenerated = generator.GenerateCharacter();
            Assert.IsTrue(
                CharacterConstants.ALL_DIGIT_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
        }

        [TestMethod]
        public void GenerateCharacterOfTypeSymbolsGeneratesASymbolsCharacter()
        {
            CharacterGenerator generator = new SymbolCharacterGenerator();

            char characterGenerated = generator.GenerateCharacter();
            Assert.IsTrue(
                CharacterConstants.ALL_SYMBOL_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
        }

        [TestMethod]
        public void GenerateCharacterOfTypeSymbolsDoesntGenerateOtherCharacter()
        {
            CharacterGenerator generator = new SymbolCharacterGenerator();

            char characterGenerated = generator.GenerateCharacter();
            Assert.IsFalse(
                CharacterConstants.ALL_MINUS_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
            Assert.IsFalse(
                CharacterConstants.ALL_MAYUS_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
            Assert.IsFalse(
                CharacterConstants.ALL_DIGIT_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
        }

        [TestMethod]
        public void GenerateCharacterOfTypeMinusDoesntGenerateOtherCharacter()
        {
            CharacterGenerator generator = new MinusCharacterGenerator();

            char characterGenerated = generator.GenerateCharacter();
            Assert.IsFalse(
                CharacterConstants.ALL_SYMBOL_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
            Assert.IsFalse(
                CharacterConstants.ALL_MAYUS_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
            Assert.IsFalse(
                CharacterConstants.ALL_DIGIT_CHARACTERS.Any(
                    theCharacter => theCharacter == characterGenerated));
        }

    }
}
