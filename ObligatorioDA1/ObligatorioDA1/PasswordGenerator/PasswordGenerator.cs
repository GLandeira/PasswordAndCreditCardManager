using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain.PasswordGenerator
{
    public static class PasswordGenerator
    {
        private const int MAX_PASSWORD_LENGTH = 25;

        public static string GeneratePassword(PasswordGenerationSettings generationSettings)
        {
            CheckIfInvalidPassword(generationSettings);

            bool[] conditionsList = CondenseConditionsToArray(generationSettings);

            List<CharacterGenerator> characterGenerators = CreateCharacterGeneratorsForAcceptedConditions(conditionsList);

            int passwordLength = generationSettings.length;

            return GeneratePasswordWithGenerators(characterGenerators, passwordLength);
        }

        private static string GeneratePasswordWithGenerators(List<CharacterGenerator> characterGenerators, int passwordLength)
        {
            string thePassword = "";

            thePassword = AddOneCharacterPerAcceptedCriteria(characterGenerators, thePassword);

            thePassword = GenerateRestOfPassword(characterGenerators, passwordLength, thePassword);

            return thePassword;
        }

        private static string GenerateRestOfPassword(List<CharacterGenerator> characterGenerators, int passwordLength, string thePassword)
        {
            int characterCountAtThisPoint = thePassword.Length;
            int charactersLeftToFillResult = passwordLength - characterCountAtThisPoint;

            Random random = new Random();
            for (int stepsInPassword = 0; stepsInPassword < charactersLeftToFillResult; stepsInPassword++)
            {
                int randomCharacterGenerationIndex = random.Next(0, characterGenerators.Count);

                thePassword = AddRandomCharacterOfTypeToString(characterGenerators[randomCharacterGenerationIndex], thePassword);
            }

            return thePassword;
        }

        private static string AddOneCharacterPerAcceptedCriteria(List<CharacterGenerator> theGenerators, string thePassword)
        {
            for (int stepInList = 0; stepInList < theGenerators.Count; stepInList++)
            {
                thePassword = AddRandomCharacterOfTypeToString(theGenerators[stepInList], thePassword);
            }

            return thePassword;
        }

        private static List<CharacterGenerator> CreateCharacterGeneratorsForAcceptedConditions(bool[] conditionsList)
        {
            List<CharacterGenerator> characterGenerators = new List<CharacterGenerator>();

            for (int stepInArray = 0; stepInArray < conditionsList.Length; stepInArray++)
            {
                if (conditionsList[stepInArray])
                {
                    characterGenerators.Add(GenerateTypeOfCharacterGenerator(stepInArray));
                }
            }

            return characterGenerators;
        }

        private static string AddRandomCharacterOfTypeToString(CharacterGenerator theGenerator, string thePassword)
        {
            string newCharacter = theGenerator.GenerateCharacter().ToString();
            return thePassword.Insert(thePassword.Length, newCharacter);
        }

        private static CharacterGenerator GenerateTypeOfCharacterGenerator(int conditionPlaceInArray)
        {
            switch (conditionPlaceInArray)
            {
                case 0:
                    return new MayusCharacterGenerator();
                case 1:
                    return new MinusCharacterGenerator();
                case 2:
                    return new DigitCharacterGenerator();
                case 3:
                    return new SymbolCharacterGenerator();
                default:
                    throw new Exception();
            }
        }

        private static void CheckIfInvalidPassword(PasswordGenerationSettings generationSettings)
        {
            int passwordLength = generationSettings.length;
            bool hasMayus = generationSettings.hasMayus;
            bool hasMinus = generationSettings.hasMinus;
            bool hasDigits = generationSettings.hasDigits;
            bool hasSymbols = generationSettings.hasSymbols;
            bool todasLasCondicionesSonFalse = !hasSymbols && !hasMinus && !hasMayus && !hasDigits;

            if (passwordLength <= 0 || passwordLength > MAX_PASSWORD_LENGTH || (todasLasCondicionesSonFalse))
            {
                throw new InvalidPasswordGenerationSettingsException();
            }
        }

        private static bool[] CondenseConditionsToArray(PasswordGenerationSettings generationSettings)
        {
            bool[] conditionsList = new bool[4];
            conditionsList[0] = generationSettings.hasMayus;
            conditionsList[1] = generationSettings.hasMinus;
            conditionsList[2] = generationSettings.hasDigits;
            conditionsList[3] = generationSettings.hasSymbols;

            return conditionsList;
        }
    }
}
