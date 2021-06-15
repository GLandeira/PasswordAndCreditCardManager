using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.PasswordSecurityFlagger;
using Domain.PasswordRecommender;

namespace Domain.PasswordRecommender
{
    public class PasswordRecommender
    {
        public static SecurityCondition isASafePassword(string passwordString, User loggedUser)
        {
            SecurityCondition conditions = new SecurityCondition();
            conditions._isNotBreached = true;
            conditions._isNotInUse = true;
            conditions._isNotLowSecurityLevel = true;

            //Check if its in data breaches
            foreach (DataBreach db in loggedUser.UserDataBreaches.DataBreaches)
            {
                foreach (PasswordHistory ph in db.PasswordBreaches)
                {
                    if (ph.BreachedPasswordString == passwordString)
                    {
                        conditions._isNotBreached = false;
                    }
                }
            }

            //Check if its used already
            foreach (Password p in loggedUser.UserPasswords.Passwords)
            {
                if (p.PasswordString == passwordString)
                {
                    conditions._isNotInUse = false;
                }
            }


            //Check password level
            SecurityLevelPasswords passwordLevel = PasswordSecurityFlagger.PasswordSecurityFlagger.GetSecurityLevel(passwordString);
            if (!(passwordLevel == SecurityLevelPasswords.DARK_GREEN || passwordLevel == SecurityLevelPasswords.LIGHT_GREEN))
            {
                conditions._isNotLowSecurityLevel = false;
            }

            return conditions;
        }
    }
}
