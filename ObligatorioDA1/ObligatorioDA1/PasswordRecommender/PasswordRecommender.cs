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
            conditions._isNotBreached = checkIfHasBeenBreached(passwordString,loggedUser);
            conditions._isNotInUse = true;
            conditions._isNotLowSecurityLevel = true;

            
            

            return conditions;
        }

        private static bool checkIfHasBeenBreached(string passwordString, User loggedUser)
        {
            bool condition = true;
            foreach (DataBreach db in loggedUser.UserDataBreaches.DataBreaches)
            {
                foreach (PasswordHistory ph in db.PasswordBreaches)
                {
                    if (ph.BreachedPasswordString == passwordString)
                    {
                        condition = false;
                    }
                }
            }
            return condition;
        }

        private static bool checkIfIsAlreadyInUse(string passwordString, User loggedUser)
        {
            bool condition = true;
            foreach (Password p in loggedUser.UserPasswords.Passwords)
            {
                if (p.PasswordString == passwordString)
                {
                    condition = false;
                }
            }
            return condition;
        }

        private static bool checkSecurityLevel(string passwordString, User loggedUser)
        {
            bool condition = true;
            SecurityLevelPasswords passwordLevel = PasswordSecurityFlagger.PasswordSecurityFlagger.GetSecurityLevel(passwordString);
            if (!(passwordLevel == SecurityLevelPasswords.DARK_GREEN || passwordLevel == SecurityLevelPasswords.LIGHT_GREEN))
            {
                condition = false;
            }
            return condition;
        }
    }
