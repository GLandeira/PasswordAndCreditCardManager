using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PasswordSharer
    {
        private Domain _theDomain;

        public static PasswordSharer Instance { get; private set; }

        private PasswordSharer(Domain theDomain)
        {
            _theDomain = theDomain;
        }

        public static void Init(Domain theDomain)
        {
            Instance = new PasswordSharer(theDomain);
        }

        internal void SharePasswordWithUser(string shareeName, Password sharedPassword)
        {
            UserPassword shareePasswords = _theDomain.GetUser(shareeName).UserPasswords;

            //sharedPassword = SetSharedPasswordCategoryToSharedWithMe(sharedPassword);

            shareePasswords.AddPassword(sharedPassword);
        }
        internal void StopSharingPasswordWithUser(string sharee, Password sharedPassword)
        {
            UserPassword shareePasswords = _theDomain.GetUser(sharee).UserPasswords;

            shareePasswords.RemovePassword(sharedPassword);
        }

        internal void ModifyPasswordForUsers(List<string> usersSharedWith, Password modifiedPassword, Password oldPassword)
        {
            modifiedPassword.UsersSharedWith = new List<string>();

            foreach(string userName in usersSharedWith)
            {
                UserPassword theUsersPasswords = _theDomain.GetUser(userName).UserPasswords;
                theUsersPasswords.ModifyPassword(modifiedPassword, oldPassword);
            }
        }
    }
}
