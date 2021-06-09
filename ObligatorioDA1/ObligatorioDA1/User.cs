using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string MainPassword { get; set; }
        public UserPassword UserPasswords { get; private set; }
        public UserCreditCard UserCreditCards { get; private set; }
        public UserDataBreaches UserDataBreaches { get; private set; }
        public UserCategory UserCategories { get; private set; }


        public User()
        {
            UserPasswords = new UserPassword();
            UserCreditCards = new UserCreditCard();
            UserDataBreaches = new UserDataBreaches(this);
            UserCategories = new UserCategory();
        }

        public User(string name, string mainPassword)
        {
            UserPasswords = new UserPassword();
            UserCreditCards = new UserCreditCard();
            UserDataBreaches = new UserDataBreaches(this);
            UserCategories = new UserCategory();
            Name = name;
            MainPassword = mainPassword;
        }

        public User(int userId, string name, string mainPassword)
        {
            UserID = userId;
            UserPasswords = new UserPassword();
            UserCreditCards = new UserCreditCard();
            UserDataBreaches = new UserDataBreaches(this);
            UserCategories = new UserCategory();
            Name = name;
            MainPassword = mainPassword;
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
    }
}
