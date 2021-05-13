using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.PasswordSecurityFlagger;

namespace Domain
{
    public class UserPassword
    {
        public List<Password> Passwords { get; private set; }
        private UserManager _userManager;
        public UserPassword(UserManager userManager)
        {
            this.Passwords = new List<Password>();
            _userManager = userManager;
        }

        public void AddPassword(Password password)
        {
            Verifier.VerifyPassword(password);
            password.LastModification = DateTime.Today;
            password.SecurityLevel = PasswordSecurityFlagger.PasswordSecurityFlagger.GetSecurityLevel(password.PasswordString);
            this.Passwords.Add(password);
        }

        public void RemovePassword(Password password)
        {
            if(password.Category != User.SHARED_WITH_ME_CATEGORY)
            {
                StopSharingPasswordWhenDeleted(password);
            }
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
            Verifier.VerifyPassword(modifiedPassword);
            if (this.Passwords.Any(ListIteratingPassword => ListIteratingPassword.AbsoluteEquals(modifiedPassword)))
            {
                throw new AlreadyExistingPasswordException();
            }

            modifiedPassword.LastModification = DateTime.Now;
            modifiedPassword.SecurityLevel = PasswordSecurityFlagger.PasswordSecurityFlagger.GetSecurityLevel(modifiedPassword.PasswordString);
            List<string> usersSharedWith = new List<string>(oldPassword.UsersSharedWith);
            this.RemovePassword(oldPassword);
            this.Passwords.Add(modifiedPassword);
            foreach(string username in usersSharedWith)
            {
                User userSharedTo = _userManager.GetUser(username);
                this.SharePassword(userSharedTo, modifiedPassword);
            }
           
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
            //creates password clone with Shared_with_me_category equal to the password in sharee instead of passing original password. 
            Password sharedPasswordSharedClone =(Password) sharedPassword.Clone();
            sharedPasswordSharedClone.Category = User.SHARED_WITH_ME_CATEGORY;
            sharee.UserPasswords.RemovePassword(sharedPasswordSharedClone);
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
            sharedPassword.UsersSharedWith.Remove(shareeName);
        }

        public List<Password> GetPasswordsWithSecurityLevel(SecurityLevelPasswords securityLevel)
        {
            List<Password> metSecurityLevelPasswords = new List<Password>();
            foreach(Password currentPassword in Passwords)
            {
                if(currentPassword.SecurityLevel == securityLevel)
                {
                    metSecurityLevelPasswords.Add(currentPassword);
                }
            }
            return metSecurityLevelPasswords;
        }

        public int GetAmountOfPasswordsWithSecurityLevelAndCategory(SecurityLevelPasswords securityLevel, Category category)
        {
            int amountOfPasswords = 0;
            foreach(Password currentPassword in Passwords)
            {
                if ((currentPassword.SecurityLevel == securityLevel) && (currentPassword.Category.Equals(category)))
                {
                    amountOfPasswords++;
                }
            }
            return amountOfPasswords;
        }

        public List<Password> GetPasswordsImSharing()
        {
            List<Password> sharedPasswords = new List<Password>();
            foreach(Password currentPassword in Passwords)
            {
                if (currentPassword.UsersSharedWith.Count() > 0 && currentPassword.Category != User.SHARED_WITH_ME_CATEGORY)
                {
                    sharedPasswords.Add(currentPassword);
                }
            }

            return sharedPasswords;
        }

        private void StopSharingPasswordWhenDeleted(Password password)
        {
            List<string> usersSharedWith = new List<string>(password.UsersSharedWith);
            foreach (string username in usersSharedWith)
            {
                User sharedUser = _userManager.GetUser(username);
                this.StopSharingPassword(sharedUser, password);
            }
        }
    }
}
