using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain
{
    public class UserManager
    {
        public User LoggedUser { get; set; }
        public List<User> Users { get; private set; }

        public UserManager()
        {
            Users = new List<User>();
        }

        public void AddUser(User newUser)
        {
            Verifier.VerifyUser(newUser);

            if (Users.Contains(newUser))
            {
                throw new UserAlreadyExistsException();
            }

            Users.Add(newUser);
        }

        public User GetUser(string username)
        {
            if(!Users.Any(user => user.Name == username))
            {
                throw new UserNotPresentException();
            }

            return Users.First(user => user.Name == username);
        }

        public void ModifyPassword(User userWithNewPassword)
        {
            Verifier.VerifyUser(userWithNewPassword);

            if (!Users.Exists(userInList => userInList.Equals(userWithNewPassword)))
            {
                throw new UserNotPresentException();
            }

            Users.First(us => us.Name == userWithNewPassword.Name).MainPassword = userWithNewPassword.MainPassword;
        }

        public bool LogIn(string userNameToLogInWith, string userPasswordToLogInWith)
        {
            User userToLogInWith = GetUser(userNameToLogInWith);

            if (userToLogInWith.MainPassword == userPasswordToLogInWith)
            {
                LoggedUser = userToLogInWith;
                return true;
            }

            return false;
        }
    }
}
