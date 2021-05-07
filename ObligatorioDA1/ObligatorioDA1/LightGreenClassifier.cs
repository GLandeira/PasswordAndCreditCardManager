using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LightGreenClassifier : ColorClassifier
    {
        public static bool meetsColorCriteria(String password)
        {
            bool UpperCaseFound = HasUpperCase(password);
            bool LowerCaseFound = HasLowerCase(password);
            bool DigitsFound = HasDigits(password);
            bool SpecialCharsFound = HasSpecialCharacters(password);
            bool meetsCriteria = false;
            if(password.Length > 14)
            {
                if (UpperCaseFound && LowerCaseFound)
                {
                    meetsCriteria = true;
                }
                else
                {
                    if (DigitsFound && SpecialCharsFound)
                    {
                        meetsCriteria = (UpperCaseFound || LowerCaseFound);
                    }
                }
            }

            return meetsCriteria;
        }

    }
}
