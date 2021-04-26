using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain
{
    public class Domain
    {
        public List<User> Users { get; set; }

        public Domain()
        {
            Users = new List<User>();
        }

        public void AddUser(User newUser)
        {
            if (Users.Contains(newUser))
            {
                throw new UserAlreadyExistsException();
            }

            Users.Add(newUser);
        }

        public void ModifyPassword(string userNameInDomain, string newPassword)
        {
            try
            {
                Users.First(us => us.Name == userNameInDomain).MainPassword = newPassword;
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
