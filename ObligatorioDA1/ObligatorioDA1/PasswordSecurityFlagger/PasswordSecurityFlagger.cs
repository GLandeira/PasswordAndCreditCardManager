using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain.PasswordSecurityFlagger
{
    public class PasswordSecurityFlagger
    {
        public static SecurityLevelPasswords GetSecurityLevel(String password)
        {
            ColorClassifier colorClassifier = new RedClassifier();

            return DetermineSecurityLevel(colorClassifier, password);
        }

        private static SecurityLevelPasswords DetermineSecurityLevel(ColorClassifier colorClassifier, String password)
        {
            if (colorClassifier.MeetsColorCriteria(password)) return colorClassifier.AssociatedSecurityLevel;

            colorClassifier = DetermineNextColorClassifierType(colorClassifier);

            return DetermineSecurityLevel(colorClassifier, password);
        }  
        
        private static ColorClassifier DetermineNextColorClassifierType(ColorClassifier colorClassifier)
        {
            switch (colorClassifier)
            {
                case RedClassifier red:
                    return new OrangeClassifier();
                case OrangeClassifier orange:
                    return new DarkGreenClassifier();
                case YellowClassifier yellow:
                    throw new CouldntAssignSecurityLevelException();
                case LightGreenClassifier lightGreen:
                    return new YellowClassifier();
                case DarkGreenClassifier darkGreen:
                    return new LightGreenClassifier();
                default:
                    throw new CouldntAssignSecurityLevelException();
            }
        }
    }
}
