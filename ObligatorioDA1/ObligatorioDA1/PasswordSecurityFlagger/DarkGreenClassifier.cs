using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordSecurityFlagger
{
    public class DarkGreenClassifier : ColorClassifier
    {
        public override SecurityLevelPasswords AssociatedSecurityLevel { get; } = SecurityLevelPasswords.DARK_GREEN;
        public override ColorClassifier NextClassifier { get; } = new LightGreenClassifier();
        public override bool MeetsColorCriteria(string password)
        {
            bool meetsCriteria = false;

            if(password.Length > MAXIMUM_LENGTH_ORANGE)
            {
                bool UpperCaseFound = HasUpperCase(password);
                bool LowerCaseFound = HasLowerCase(password);
                bool DigitsFound = HasDigits(password);
                bool SpecialCharsFound = HasSpecialCharacters(password);
                meetsCriteria = UpperCaseFound && LowerCaseFound && DigitsFound && SpecialCharsFound;
            }
            
            return meetsCriteria;
        }

    }
}
