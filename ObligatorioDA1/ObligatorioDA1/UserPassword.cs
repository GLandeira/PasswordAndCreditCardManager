using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain
{
    public class UserPassword
    {
        public List<Password> Passwords { get; private set; }

        public UserPassword()
        {
            this.Passwords = new List<Password>();
        }

        public void AddPassword(Password password)
        {
            this.Passwords.Add(password);
        }

        public void RemovePassword(Password password)
        {
            this.Passwords.Remove(password);
        }

        public Password GetPassword(string siteName, string siteUserName)
        {
            Password passwordImitator = new Password();
            passwordImitator.Site = siteName;
            passwordImitator.Username = siteUserName;

            if(!Passwords.Any(pass => pass.Equals(passwordImitator)))
            {
                throw new PasswordNotFoundException();
            }

            return Passwords.First(pass => pass.Equals(passwordImitator));
        }

        public List<Password> GetPasswordsByPasswordString(String passwordStringToLook)
        {

            if (!Passwords.Exists(passwordInList => passwordInList.PasswordString.Equals(passwordStringToLook)))
            {
                throw new PasswordNotFoundException();
            }
            return Passwords.FindAll(passwordInList => passwordInList.PasswordString.Equals(passwordStringToLook));
        }

        public void ModifyPassword(Password modifiedPassword, Password oldPassword)
        {
            if(this.Passwords.Any(ListIteratingPassword => ListIteratingPassword.AbsoluteEquals(modifiedPassword)))
            {
                throw new AlreadyExistingPasswordException();
            }

            modifiedPassword.LastModification = DateTime.Now;

            this.Passwords.Remove(oldPassword);
            this.Passwords.Add(modifiedPassword);
        }

        public void SharePassword(User sharee, Password sharedPassword)
        {
            CheckIfShareeHasSharedPassword(sharee, sharedPassword);

            AddUserToPasswordUsersSharedWith(sharee.Name, sharedPassword);

            Password sharedClone = (Password)sharedPassword.Clone();
            sharedClone.Category = User.SHARED_WITH_ME_CATEGORY;

            sharee.UserPasswords.AddPassword(sharedClone);
        }

        public void StopSharingPassword(User sharee, Password sharedPassword)
        {
            RemoveUserFromPasswordUsersSharedWith(sharee.Name, sharedPassword);
            sharee.UserPasswords.RemovePassword(sharedPassword);
        }

        private void CheckIfShareeHasSharedPassword(User sharee, Password sharedPassword)
        {
            if (sharee.UserPasswords.Passwords.Any(pass => pass.Equals(sharedPassword)))
            {
                throw new PasswordAlreadySharedException();
            }
        }

        private void AddUserToPasswordUsersSharedWith(string shareeName, Password sharedPassword)
        {
            Password sharerPasswordInMemory = Passwords.Find(pass => pass.Equals(sharedPassword));
            sharerPasswordInMemory.UsersSharedWith.Add(shareeName);
        }

        private void RemoveUserFromPasswordUsersSharedWith(string shareeName, Password sharedPassword)
        {
            Password sharerPasswordInMemory = Passwords.Find(pass => pass.Equals(sharedPassword));
            sharerPasswordInMemory.UsersSharedWith.Remove(shareeName);
        }
    }
}
