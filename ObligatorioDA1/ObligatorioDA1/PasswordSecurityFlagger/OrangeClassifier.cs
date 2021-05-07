using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordSecurityFlagger
{
    public class OrangeClassifier
    {
        public static bool MeetsColorCriteria(String password)
        {
            bool meetsCriteria = (password.Length > 7 && password.Length < 15);
            return meetsCriteria;
        }
    }
}
