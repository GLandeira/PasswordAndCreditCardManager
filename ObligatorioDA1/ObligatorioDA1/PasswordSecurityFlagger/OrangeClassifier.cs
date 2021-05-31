using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordSecurityFlagger
{
    public class OrangeClassifier : ColorClassifier
    {
        public override SecurityLevelPasswords AssociatedSecurityLevel { get; } = SecurityLevelPasswords.ORANGE;
        public override ColorClassifier NextClassifier { get; } = new DarkGreenClassifier();
        public override bool MeetsColorCriteria(string password)
        {
            bool meetsCriteria = password.Length > MAXIMUM_LENGTH_RED && password.Length < MAXIMUM_LENGTH_ORANGE + 1;
            return meetsCriteria;
        }
    }
}
