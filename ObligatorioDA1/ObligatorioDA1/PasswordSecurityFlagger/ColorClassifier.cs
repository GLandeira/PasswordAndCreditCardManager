using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordSecurityFlagger
{
    public class ColorClassifier
    {
        public static bool HasUpperCase(String password)
        {
            bool upperCaseFound = false;

            if(-1 != password.IndexOfAny(CharacterConstants.ALL_MAYUS_CHARACTERS))
            {
                upperCaseFound = true;
            }

            return upperCaseFound;
        }

        public static bool HasLowerCase(String password)
        {
            bool lowerCaseFound = false;

            if (-1 != password.IndexOfAny(CharacterConstants.ALL_MINUS_CHARACTERS))
            {
                lowerCaseFound = true;
            }

            return lowerCaseFound;
        }


        public static bool HasDigits(String password)
        {

            bool digitFound = false;

            if (-1 != password.IndexOfAny(CharacterConstants.ALL_DIGIT_CHARACTERS))
            {
                digitFound = true;
            }

            return digitFound;
        }

        public static bool HasSpecialCharacters(String password)
        {
            bool symbolFound = false;

            if (-1 != password.IndexOfAny(CharacterConstants.ALL_SYMBOL_CHARACTERS))
            {
                symbolFound = true;
            }

            return symbolFound;
        }

        public static bool MeetsColorCriteria(String password)
        {
            return true;
        }
    }
}
