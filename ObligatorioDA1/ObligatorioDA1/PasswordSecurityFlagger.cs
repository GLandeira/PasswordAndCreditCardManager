using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PasswordSecurityFlagger
    {
        public static SecurityLevelPasswords GetSecurityLevel(String password)
        {
            SecurityLevelPasswords passwordSecurityLevel = SecurityLevelPasswords.RED;

            return passwordSecurityLevel;
        }


    }
}
