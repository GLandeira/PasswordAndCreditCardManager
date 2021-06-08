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
        public List<User> Users { get; set; }

        public IDataAccess<User> UserDataAccess { get; private set; }

        public UserManager()
        {
            Users = UserDataAccess.GetAll().ToList();
        }

        public void AddUser(User newUser)
        {
            Verifier.VerifyUser(newUser);

            if (Users.Contains(newUser))
            {
                throw new UserAlreadyExistsException();
            }

            int dbID = UserDataAccess.Add(newUser);

            newUser.UserID = dbID;
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

            UserDataAccess.Modify(userWithNewPassword);
        }

        public bool LogIn(string userNameToLogInWith, string userPasswordToLogInWith)
        {
            try
            {
                User userToLogInWith = GetUser(userNameToLogInWith);

                if (userToLogInWith.MainPassword == userPasswordToLogInWith)
                {
                    LoggedUser = userToLogInWith;
                    return true;
                }

                return false;
            }
            catch (UserNotPresentException e)
            {
                return false;
            }
        }
    }
}
