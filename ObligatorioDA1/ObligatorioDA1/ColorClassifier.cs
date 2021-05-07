using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ColorClassifier
    {
        public static readonly char[] ALL_SYMBOL_CHARACTERS =
        {
            '!', '@', '#', '$', '%', '^', '&',
            '+', '=', '_', '-', ')', '(', '*',
            '`', '~', '/', '.' , ',', '>', '<',
            '[', ']', ':', '"', ';', '{', '}', '|',
            '|', '?', ' '
        };


        public static bool HasUpperCase(String password)
        {
            bool upperCaseFound = false;
            foreach (char letter in password)
            {
                if ((letter < 91 && letter > 64) || (letter == 165))
                {
                    upperCaseFound = true;
                }
            }
            return upperCaseFound;
        }

        public static bool HasLowerCase(String password)
        {
            bool LowerCaseFound = false;
            foreach (char letter in password)
            {
                if ((letter < 122 && letter > 97) || (letter == 164))
                {
                    LowerCaseFound = true;
                }
            }
            return LowerCaseFound;
        }


        public static bool HasDigits(String password)
        {

            bool digitFound = false;
            foreach (char letter in password)
            {
                if ((letter < 58 && letter > 47))
                {
                    digitFound = true;
                }
            }
            return digitFound;
        }

        public static bool HasSpecialCharacters(String password)
        {
            bool symbolFound = false;
            foreach (char letter in password)
            {
                foreach (char symbol in ALL_SYMBOL_CHARACTERS)
                {
                    if (letter == symbol)
                    {
                        symbolFound = true;
                    }
                }
            }
            return symbolFound;
        }

        public static bool meetsColorCriteria(String password)
        {
            return true;
        }
    }
}
