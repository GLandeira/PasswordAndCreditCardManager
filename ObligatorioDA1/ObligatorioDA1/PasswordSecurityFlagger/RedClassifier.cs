using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordSecurityFlagger
{
    public class RedClassifier : ColorClassifier
    {
        public override SecurityLevelPasswords AssociatedSecurityLevel { get; } = SecurityLevelPasswords.RED;
        public override ColorClassifier NextClassifier { get; } = new OrangeClassifier();
        public override bool MeetsColorCriteria(string password)
        {
            bool meetsCriteria = password.Length < MAXIMUM_LENGTH_RED + 1;

            return meetsCriteria;
        }
    }
}
