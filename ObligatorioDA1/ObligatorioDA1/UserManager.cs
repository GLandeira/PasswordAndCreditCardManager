using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.PasswordEncryptor;

namespace Domain
{
    public class UserManager
    {
        private static UserManager _instance;
        public static UserManager Instance 
        { 
            get 
            {
                return _instance;
            } 
        }

        public User LoggedUser { get; set; }
        public List<User> Users { get; set; }

        private IDataAccess<User> _userDataAccess;

        public UserManager()
        {
            CheckSingleInstanceOfSingleton();

            _userDataAccess = RepositoryFacade.Instance.UserDataAccess;
            Users = _userDataAccess.GetAll().ToList();
        }

        public void AddUser(User newUser)
        {
            if (Users.Contains(newUser))
            {
                throw new UserAlreadyExistsException();
            }

            int dbID = _userDataAccess.Add(newUser);
            newUser.InitializeUser(dbID);
            Users.Add(newUser);
        }

        public User GetUser(string username)
        {
            if(!Users.Any(user => user.Name == username))
            {
                throw new UserNotPresentException();
            }

            int userFoundID = Users.First(user => user.Name == username).UserID;
            User userInDB = RepositoryFacade.Instance.UserDataAccess.Get(userFoundID);

            return userInDB;
        }

        public void ModifyPassword(User userWithNewPassword)
        {
            if (!Users.Exists(userInList => userInList.Equals(userWithNewPassword)))
            {
                throw new UserNotPresentException();
            }

            Users.First(us => us.Name == userWithNewPassword.Name).MainPassword = userWithNewPassword.MainPassword;
            _userDataAccess.Modify(userWithNewPassword);
        }

        public bool LogIn(User userToLogInWith, string userPasswordToLogInWith)
        {
            try
            {
                User userInDB = Users.FirstOrDefault(u => u.Equals(userToLogInWith));

                if (userInDB != null && userInDB.MainPassword == userPasswordToLogInWith)
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

        private void CheckSingleInstanceOfSingleton()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }
    }
}
