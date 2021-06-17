using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordSecurityFlagger
{
    public class LightGreenClassifier : ColorClassifier
    {
        public override SecurityLevelPasswords AssociatedSecurityLevel { get; } = SecurityLevelPasswords.LIGHT_GREEN;
        public override ColorClassifier NextClassifier { get; } = new YellowClassifier();
        public override bool MeetsColorCriteria(string password)
        {
            bool UpperCaseFound = HasUpperCase(password);
            bool LowerCaseFound = HasLowerCase(password);
            bool DigitsFound = HasDigits(password);
            bool SpecialCharsFound = HasSpecialCharacters(password);
            bool meetsCriteria = false;
            if(password.Length > MAXIMUM_LENGTH_ORANGE)
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
