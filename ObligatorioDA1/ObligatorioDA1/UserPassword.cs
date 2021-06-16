using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.PasswordEncryptor;
using Domain.PasswordSecurityFlagger;

namespace Domain
{
    public class UserPassword
    {
        public List<Password> Passwords { get; set; }
        public int UserPasswordID { get; set; }

        private User _myUser;

        public UserPassword()
        {
            Passwords = new List<Password>();
        }

        public UserPassword(User user)
        {
            Passwords = new List<Password>();
            _myUser = user;
        }

        public void AddPassword(Password password)
        {
            bool foundEqual = Passwords.Any(ListIteratingPassword => ListIteratingPassword.Equals(password));

            VerifyPassword(password, foundEqual);

            password.LastModification = DateTime.Today;
            password.SecurityLevel = PasswordSecurityFlagger.PasswordSecurityFlagger.GetSecurityLevel(password.PasswordString);

            AddPasswordToListAndDB(password);
        }

        public void RemovePassword(Password password) 
        {
            if(!password.Category.Equals(UserCategory.SHARED_WITH_ME_CATEGORY))
            {
                StopSharingPasswordWhenDeleted(password);
            }
            Passwords.Remove(password);
            RepositoryFacade.Instance.PasswordDataAccess.Delete(password);
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

        public List<Password> GetPasswordsByPasswordString(string passwordStringToLook)
        {
            string encryptedPasswordStringToLook = EncryptPassword(passwordStringToLook);

            if (!Passwords.Exists(passwordInList => passwordInList.PasswordStringEquals(encryptedPasswordStringToLook)))
            {
                throw new PasswordNotFoundException();
            }

            return Passwords.FindAll(passwordInList => passwordInList.PasswordStringEquals(encryptedPasswordStringToLook));
        }

        public void ModifyPassword(Password modifiedPassword, Password oldPassword)
        {
            bool foundAbsolutelyEqual = Passwords.Any(ListIteratingPassword => ListIteratingPassword.AbsoluteEquals(modifiedPassword));
            VerifyPassword(modifiedPassword, foundAbsolutelyEqual);

            modifiedPassword.LastModification = DateTime.Now;
            modifiedPassword.SecurityLevel = PasswordSecurityFlagger.PasswordSecurityFlagger.GetSecurityLevel(modifiedPassword.PasswordString);

            List<User> usersSharedWith = new List<User>(oldPassword.UsersSharedWith);

            if (!oldPassword.Category.Equals(UserCategory.SHARED_WITH_ME_CATEGORY))
            {
                StopSharingPasswordWhenDeleted(oldPassword);
            }
            Passwords.Remove(oldPassword);

            ModifyInDatabaseEncrypted(modifiedPassword);
            Passwords.Add(modifiedPassword);
            
            ReshareModifiedPassword(usersSharedWith, modifiedPassword);
        }

        public void SharePassword(User sharee, Password sharedPassword)
        {
            CheckIfShareeHasSharedPassword(sharee, sharedPassword);

            AddUserToPasswordUsersSharedWith(sharee, sharedPassword);

            Password sharedClone = (Password)sharedPassword.Clone();
            sharedClone.Category = sharee.UserCategories.GetACategory(UserCategory.SHARED_PASSWORD_CATEGORY_NAME);
            sharedClone.UsersSharedWith = new List<User>();

            sharee.UserPasswords.AddPassword(sharedClone);
        }

        public void StopSharingPassword(User sharee, Password sharedPassword)
        {
            RemoveUserFromPasswordUsersSharedWith(sharee, sharedPassword);

            Password sharedPasswordSharedClone = (Password)sharedPassword.Clone();
            sharedPasswordSharedClone.Category = sharee.UserCategories.GetACategory(UserCategory.SHARED_PASSWORD_CATEGORY_NAME);
            sharedPasswordSharedClone.PasswordID = sharee.UserPasswords.GetPassword(sharedPassword.Site, sharedPassword.Username).PasswordID;

            sharee.UserPasswords.RemovePassword(sharedPasswordSharedClone);
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
                if (currentPassword.UsersSharedWith.Count() > 0 && currentPassword.Category != UserCategory.SHARED_WITH_ME_CATEGORY)
                {
                    sharedPasswords.Add(currentPassword);
                }
            }

            return sharedPasswords;
        }

        private void StopSharingPasswordWhenDeleted(Password password)
        {
            List<User> usersSharedWith = new List<User>(password.UsersSharedWith);
            foreach (User user in usersSharedWith)
            {
                User userInDb = RepositoryFacade.Instance.UserDataAccess.Get(user.UserID);
                StopSharingPassword(userInDb, password);
            }
        }

        private void ReshareModifiedPassword(List<User> usersSharedWith, Password modifiedPassword)
        {
            foreach (User user in usersSharedWith)
            {
                User userInDb = RepositoryFacade.Instance.UserDataAccess.Get(user.UserID);
                SharePassword(userInDb, modifiedPassword);
            }
        }

        private void VerifyPassword(Password password, bool equalityCondition)
        {
            Verifier.VerifyPassword(password);

            if (equalityCondition)
            {
                throw new AlreadyExistingPasswordException();
            }
        }

        private void CheckIfShareeHasSharedPassword(User sharee, Password sharedPassword)
        {
            if (sharee.UserPasswords.Passwords.Any(pass => pass.Equals(sharedPassword)))
            {
                throw new PasswordAlreadySharedException();
            }
        }

        private void AddUserToPasswordUsersSharedWith(User sharee, Password sharedPassword)
        {
            Password sharerPasswordInMemory = Passwords.Find(pass => pass.Equals(sharedPassword));
            sharerPasswordInMemory.UsersSharedWith.Add(sharee);
            ModifyInDatabaseEncrypted(sharedPassword);
        }

        private void RemoveUserFromPasswordUsersSharedWith(User sharee, Password sharedPassword)
        {
            sharedPassword.UsersSharedWith.Remove(sharee);
            ModifyInDatabaseEncrypted(sharedPassword);
        }

        private void AddPasswordToListAndDB(Password passwordToAdd)
        {
            passwordToAdd.UserPassword = this;
            EncryptPassword(passwordToAdd);
            Passwords.Add(passwordToAdd);
            RepositoryFacade.Instance.PasswordDataAccess.Add(passwordToAdd);
        }

        private void ModifyInDatabaseEncrypted(Password passwordToEncrypt)
        {
            EncryptPassword(passwordToEncrypt);
            RepositoryFacade.Instance.PasswordDataAccess.Modify(passwordToEncrypt);
        }

        private void EncryptPassword(Password passwordToEncrypt)
        {
            User loggedUser = UserManager.Instance.LoggedUser;
            IEncryptor encryptor = loggedUser.Encryptor;
            //Password dbPassword = (Password) passwrodToAdd.Clone(); ??
            passwordToEncrypt.PasswordString = encryptor.Encrypt(passwordToEncrypt.PasswordString);
        }

        private string EncryptPassword(string passwordToEncrypt)
        {
            User loggedUser = UserManager.Instance.LoggedUser;
            IEncryptor encryptor = loggedUser.Encryptor;
            //Password dbPassword = (Password) passwrodToAdd.Clone(); ??
            return encryptor.Encrypt(passwordToEncrypt);
        }
    }
}
