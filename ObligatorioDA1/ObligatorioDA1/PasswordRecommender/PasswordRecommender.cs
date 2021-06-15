using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.PasswordSecurityFlagger;

namespace Domain.PasswordRecommender
{
    public class PasswordRecommender
    {
        public static bool isASafePassword(string passwordString, User loggedUser)
        {
            bool isSafe = true;

            //Check if its in data breaches
            foreach (DataBreach db in loggedUser.UserDataBreaches.DataBreaches)
            {
                foreach (PasswordHistory ph in db.PasswordBreaches)
                {
                    if (ph.BreachedPasswordString == passwordString)
                    {
                        isSafe = false;
                    }
                }
            }

            //Check if its used already
            foreach (Password p in loggedUser.UserPasswords.Passwords)
            {
                if (p.PasswordString == passwordString)
                {
                    isSafe = false;
                }
            }


            //Check password level
            SecurityLevelPasswords passwordLevel = PasswordSecurityFlagger.PasswordSecurityFlagger.GetSecurityLevel(passwordString);
            if (!(passwordLevel == SecurityLevelPasswords.DARK_GREEN || passwordLevel == SecurityLevelPasswords.LIGHT_GREEN))
            {
                isSafe = false;
            }

            return isSafe;
        }
    }
}
