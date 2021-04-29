using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain
{
    public static class PasswordGenerator
    {
        private const int MIN_ACCEPTABLE_ASCII_CODE = 33; // !
        private const int MAX_ACCEPTABLE_ASCII_CODE = 126; // ~

        public static string GeneratePassword(PasswordGenerationSettings generationSettings)
        {
            string result = "";

            CheckIfInvalidPassword(generationSettings);

            Random random = new Random();
            int passwordLength = generationSettings.length;
            bool hasMayus = generationSettings.hasMayus;
            bool hasMinus = generationSettings.hasMinus;
            bool hasDigits = generationSettings.hasDigits;
            bool hasSymbols = generationSettings.hasSymbols;

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
