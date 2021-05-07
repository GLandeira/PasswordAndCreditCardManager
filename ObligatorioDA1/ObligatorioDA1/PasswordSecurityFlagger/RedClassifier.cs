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
        public override bool MeetsColorCriteria(String password)
        {
            bool meetsCriteria = password.Length < 8;

            return meetsCriteria;
        }
    }
}
