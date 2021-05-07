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
        private List<Password> _passwords;

        public List<Password> Passwords
        {
            get
            {
                return _passwords;
            }
            set
            {
                _passwords = value;
            }
        }

        public UserPassword()
        {
            this._passwords = new List<Password>();
        }

        public void AddPassword(Password password)
        {
            this._passwords.Add(password);
        }

        public void RemovePassword(Password password)
        {
            this._passwords.Remove(password);
        }

        public Password GetPassword(string siteName, string siteUserName)
        {
            Password passwordImitator = new Password();
            passwordImitator.Site = siteName;
            passwordImitator.Username = siteUserName;

            if(!_passwords.Any(pass => pass.Equals(passwordImitator)))
            {
                throw new PasswordDoesntExistException();
            }

            return _passwords.First(pass => pass.Equals(passwordImitator));
        }

        public void ModifyPassword(Password modifiedPassword, Password oldPassword)
        {
            if(this._passwords.Any(ListIteratingPassword => ListIteratingPassword.AbsoluteEquals(modifiedPassword)))
            {
                throw new AlreadyExistingPasswordException();
            }

            modifiedPassword.LastModification = DateTime.Now;

            this._passwords.Remove(oldPassword);
            this._passwords.Add(modifiedPassword);
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
            Password sharerPasswordInMemory = _passwords.Find(pass => pass.Equals(sharedPassword));
            sharerPasswordInMemory.UsersSharedWith.Add(shareeName);
        }

        private void RemoveUserFromPasswordUsersSharedWith(string shareeName, Password sharedPassword)
        {
            Password sharerPasswordInMemory = _passwords.Find(pass => pass.Equals(sharedPassword));
            sharerPasswordInMemory.UsersSharedWith.Remove(shareeName);
        }
    }
}
