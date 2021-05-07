using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
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
