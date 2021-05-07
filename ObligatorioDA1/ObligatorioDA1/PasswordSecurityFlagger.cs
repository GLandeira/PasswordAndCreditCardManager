using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain
{
    public class PasswordSecurityFlagger
    {
        public static SecurityLevelPasswords GetSecurityLevel(String password)
        {
            if (RedClassifier.MeetsColorCriteria(password)) return SecurityLevelPasswords.RED;

            if (OrangeClassifier.MeetsColorCriteria(password)) return SecurityLevelPasswords.ORANGE;

            if (DarkGreenClassifier.MeetsColorCriteria(password)) return SecurityLevelPasswords.DARK_GREEN;

            if (LightGreenClassifier.MeetsColorCriteria(password)) return SecurityLevelPasswords.LIGHT_GREEN;

            if (YellowClassifier.MeetsColorCriteria(password)) return SecurityLevelPasswords.YELLOW;

            throw new CouldntAssignSecurityLevelException();
        }


    }
}
