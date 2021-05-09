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
            try
            {
                Users.First(us => us.Name == userWithNewPassword.Name).MainPassword = userWithNewPassword.MainPassword;
            }
            catch (InvalidOperationException isEmptyOrNotPresent)
            {
                throw new UserNotPresentException();
            }
            catch (ArgumentNullException isNull)
            {
                throw new UserNotPresentException();
            }
        }

        public bool LogIn(string userNameToLogInWith, string userPasswordToLogInWith)
        {
            return Users.Any
                (us => us.Name == userNameToLogInWith && 

                       us.MainPassword == userPasswordToLogInWith);
        }
    }
}
