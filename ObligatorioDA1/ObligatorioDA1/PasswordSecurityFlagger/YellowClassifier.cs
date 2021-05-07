using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordSecurityFlagger
{
    public class YellowClassifier : ColorClassifier
    {
        public override SecurityLevelPasswords AssociatedSecurityLevel { get; } = SecurityLevelPasswords.YELLOW;
        public override bool MeetsColorCriteria(String password)
        {
            bool meetsCriteria = false;

            if(password.Length > 14)
            {
                bool UpperCaseFound = HasUpperCase(password);
                bool LowerCaseFound = HasLowerCase(password);
                bool DigitsFound = HasDigits(password);
                bool SpecialCharsFound = HasSpecialCharacters(password);
                meetsCriteria = UpperCaseFound || LowerCaseFound || DigitsFound || SpecialCharsFound;
            }
            
            return meetsCriteria;
        }

    }
}
