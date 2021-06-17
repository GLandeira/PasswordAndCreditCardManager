using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordSecurityFlagger
{
    public class ColorClassifier
    {
        protected const int MAXIMUM_LENGTH_RED = 7;
        protected const int MAXIMUM_LENGTH_ORANGE = 14;

        public virtual SecurityLevelPasswords AssociatedSecurityLevel { get; }

        public virtual ColorClassifier NextClassifier { get; }

        public bool HasUpperCase(string password)
        {
            bool upperCaseFound = false;

            if(-1 != password.IndexOfAny(CharacterConstants.ALL_MAYUS_CHARACTERS))
            {
                upperCaseFound = true;
            }

            return upperCaseFound;
        }

        public bool HasLowerCase(string password)
        {
            bool lowerCaseFound = false;

            if (-1 != password.IndexOfAny(CharacterConstants.ALL_MINUS_CHARACTERS))
            {
                lowerCaseFound = true;
            }

            return lowerCaseFound;
        }


        public bool HasDigits(string password)
        {
            bool digitFound = false;

            if (-1 != password.IndexOfAny(CharacterConstants.ALL_DIGIT_CHARACTERS))
            {
                digitFound = true;
            }

            return digitFound;
        }

        public bool HasSpecialCharacters(string password)
        {
            bool symbolFound = false;

            if (-1 != password.IndexOfAny(CharacterConstants.ALL_SYMBOL_CHARACTERS))
            {
                symbolFound = true;
            }

            return symbolFound;
        }

        public virtual bool MeetsColorCriteria(string password)
        {
            return true;
        }
    }
}
