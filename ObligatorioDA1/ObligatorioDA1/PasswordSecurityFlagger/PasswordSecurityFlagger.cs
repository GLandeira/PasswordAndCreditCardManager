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
        public static SecurityLevelPasswords GetSecurityLevel(string password)
        {
            ColorClassifier colorClassifier = new RedClassifier();

            return DetermineSecurityLevel(colorClassifier, password);
        }

        private static SecurityLevelPasswords DetermineSecurityLevel(ColorClassifier colorClassifier, string password)
        {
            if (colorClassifier.MeetsColorCriteria(password))
            {
                return colorClassifier.AssociatedSecurityLevel;
            }

            colorClassifier = colorClassifier.NextClassifier;

            return DetermineSecurityLevel(colorClassifier, password);
        }
    }
}
