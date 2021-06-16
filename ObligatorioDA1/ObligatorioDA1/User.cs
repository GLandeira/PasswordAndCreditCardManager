using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.PasswordEncryptor;

namespace Domain
{
    public class User
    {
        private int _userID;
        public int UserID 
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
            }
        }
        public string Name { get; set; }
        public string MainPassword { get; set; }
        public string PasswordKeys { get; set; }
        public string PasswordIV { get; set; }
        public UserPassword UserPasswords { get; set; }
        public UserCreditCard UserCreditCards { get; set; }
        public UserDataBreaches UserDataBreaches { get; set; }
        public UserCategory UserCategories { get; set; }
        public IEncryptor Encryptor { get; set; }


        public User()
        {
        }

        public User(string name, string mainPassword)
        {
            UserPasswords = new UserPassword(this);
            UserCreditCards = new UserCreditCard();
            UserDataBreaches = new UserDataBreaches();
            UserCategories = new UserCategory();
            Name = name;
            MainPassword = mainPassword;
        }

        public User(int userId, string name, string mainPassword)
        {
            UserPasswords = new UserPassword(this);
            UserCreditCards = new UserCreditCard();
            UserDataBreaches = new UserDataBreaches();
            UserCategories = new UserCategory();
            UserID = userId;
            Name = name;
            MainPassword = mainPassword;
        }

        public void InitializeUser(int dbID)
        {
            UserID = dbID;
            UserCategories.AddSharedWithMeCategoryToDB();
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            User theUser = (User)obj;
            return theUser.Name == this.Name;
        }

        public List<Password> DecryptPasswords(List<Password> passwords)
        {
            List<Password> decryptedPasswords = new List<Password>();
            foreach (Password p in passwords)
            {
                Password decryptedPassword = (Password)p.Clone();
                DecryptPassword(decryptedPassword);
                decryptedPasswords.Add(decryptedPassword);
            }

            return decryptedPasswords;
        }

        private void DecryptPassword(Password passwordToDecrypt)
        {
            User loggedUser = UserManager.Instance.LoggedUser;
            IEncryptor encryptor = loggedUser.Encryptor;
            //Password dbPassword = (Password) passwrodToAdd.Clone(); ??
            //passwordToDecrypt.PasswordString = encryptor.Decrypt(passwordToDecrypt.PasswordString);
        }
    }
}
