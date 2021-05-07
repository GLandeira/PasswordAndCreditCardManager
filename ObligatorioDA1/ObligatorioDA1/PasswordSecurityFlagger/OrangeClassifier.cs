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
        public override bool MeetsColorCriteria(String password)
        {
            bool meetsCriteria = (password.Length > 7 && password.Length < 15);
            return meetsCriteria;
        }
    }
}
