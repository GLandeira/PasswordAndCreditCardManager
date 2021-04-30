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
        private const int MIN_ACCEPTABLE_ASCII_CODE = 33; // !
        private const int MAX_ACCEPTABLE_ASCII_CODE = 126; // ~

        public static string GeneratePassword(PasswordGenerationSettings generationSettings)
        {
            string result = "";

            CheckIfInvalidPassword(generationSettings);


            // Generate a random password
            // Check the conditions
            // All ascii: 32 - 126
            // Mayus: 65 - 90
            // Minus: 97 - 122
            // Digits: 48 - 57
            // Symbols: 33 - 46 and 58 - 64 and 91 - 96 and 123 - 126
            // Have a list that has the boolean conditions
            // 0 is mayus, 1 is minus, 2 is digits, 3 is symbols
            // Go through it, add the generator of each true to a list of characterGenerators also add to the string the new character
            // Random from 0 to thatList.length
            // Generate with the one in the array at the random point generated

            Random random = new Random();
            int passwordLength = generationSettings.length;
            bool[] conditionsList = new bool[4];
            conditionsList[0] = generationSettings.hasMayus;
            conditionsList[1] = generationSettings.hasMinus;
            conditionsList[2] = generationSettings.hasDigits;
            conditionsList[3] = generationSettings.hasSymbols;

            List<CharacterGenerator> characterGenerators = new List<CharacterGenerator>();

            for(int i = 0; i < conditionsList.Length; i++)
            {

            }

            for (int i = 0; i < passwordLength; i++)
            {
                int generatedCharacterNumber = random.Next(MIN_ACCEPTABLE_ASCII_CODE, MAX_ACCEPTABLE_ASCII_CODE);
                string newCharacter = ((char)generatedCharacterNumber).ToString();
                result = result.Insert(result.Length, newCharacter);
            }

            return result;
        }

        private static void CheckIfInvalidPassword(PasswordGenerationSettings generationSettings)
        {
            int passwordLength = generationSettings.length;
            bool hasMayus = generationSettings.hasMayus;
            bool hasMinus = generationSettings.hasMinus;
            bool hasDigits = generationSettings.hasDigits;
            bool hasSymbols = generationSettings.hasSymbols;

            if (passwordLength <= 0 || (!hasSymbols && !hasMinus && !hasMayus && !hasDigits))
            {
                throw new InvalidPasswordGenerationSettingsException();
            }
        }

    }
}
