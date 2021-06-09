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
        }

        public User(UserManager userManager)
        {
            UserPasswords = new UserPassword(userManager);
            UserCreditCards = new UserCreditCard();
            UserDataBreaches = new UserDataBreaches(this);
            UserCategories = new UserCategory();
        }

        public User(int userId, string name, string mainPassword, UserManager userManager)
        {
            UserID = userId;
            UserPasswords = new UserPassword(userManager);
            UserCreditCards = new UserCreditCard();
            UserDataBreaches = new UserDataBreaches(this);
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
