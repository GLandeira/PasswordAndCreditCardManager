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
        private User _theUser;

        private List<Password> _passwords;
        private List<Password> _sharedPasswords;

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

        public List<Password> SharedPasswords
        {
            get
            {
                return _sharedPasswords;
            }
            set
            {
                _sharedPasswords = value;
            }
        }

        public UserPassword(User theUser)
        {
            this._passwords = new List<Password>();
            this._sharedPasswords = new List<Password>();
            _theUser = theUser;
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

            if (oldPassword.UsersSharedWith.Count > 0)
            {
                ModifySharedPassword(modifiedPassword, oldPassword);
            }

            this._passwords.Remove(oldPassword);
            this._passwords.Add(modifiedPassword);
        }

        public void SharePassword(User sharee, Password sharedPassword)
        {
            AddUserToPasswordUsersSharedWith(sharee.Name, sharedPassword);

            Password sharedClone = (Password)sharedPassword.Clone();
            sharedClone.Category = User.SHARED_WITH_ME_CATEGORY;

            sharee.UserPasswords.AddPassword(sharedClone);
            AddSharedPassword(sharedClone);
        }

        public void StopSharingPassword(User sharee, Password sharedPassword)
        {
            RemoveUserFromPasswordUsersSharedWith(sharee.Name, sharedPassword);
            SharedPasswords.Remove(sharedPassword);
            sharee.UserPasswords.RemovePassword(sharedPassword);
        }

        private void ModifySharedPassword(Password modifiedPassword, Password oldPassword)
        {
            Password sharedPassword = _sharedPasswords.Find(pass => pass.Equals(oldPassword));
            sharedPassword = modifiedPassword;
        }

        private void AddSharedPassword(Password sharedPassword)
        {
            _sharedPasswords.Add(sharedPassword);
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
