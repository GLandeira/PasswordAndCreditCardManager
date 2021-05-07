using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordSecurityFlagger
{
    public class ColorClassifier
    {
        public virtual SecurityLevelPasswords AssociatedSecurityLevel { get; }

        public bool HasUpperCase(String password)
        {
            bool upperCaseFound = false;

            if(-1 != password.IndexOfAny(CharacterConstants.ALL_MAYUS_CHARACTERS))
            {
                upperCaseFound = true;
            }

            return upperCaseFound;
        }

        public bool HasLowerCase(String password)
        {
            bool lowerCaseFound = false;

            if (-1 != password.IndexOfAny(CharacterConstants.ALL_MINUS_CHARACTERS))
            {
                lowerCaseFound = true;
            }

            return lowerCaseFound;
        }


        public bool HasDigits(String password)
        {

            bool digitFound = false;

            if (-1 != password.IndexOfAny(CharacterConstants.ALL_DIGIT_CHARACTERS))
            {
                digitFound = true;
            }

            return digitFound;
        }

        public bool HasSpecialCharacters(String password)
        {
            bool symbolFound = false;

            if (-1 != password.IndexOfAny(CharacterConstants.ALL_SYMBOL_CHARACTERS))
            {
                symbolFound = true;
            }

            return symbolFound;
        }

        public virtual bool MeetsColorCriteria(String password)
        {
            return true;
        }
    }
}
