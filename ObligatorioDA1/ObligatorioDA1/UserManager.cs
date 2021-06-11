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
            Verifier.VerifyUser(newUser);

            if (Users.Contains(newUser))
            {
                throw new UserAlreadyExistsException();
            }
            if (_userDataAccess != null)
            {
                int dbID = _userDataAccess.Add(newUser);

                newUser.UserID = dbID;
            }
            
            Users.Add(newUser);
        }

        public User GetUser(string username)
        {
            if(!Users.Any(user => user.Name == username))
            {
                throw new UserNotPresentException();
            }

            int userFoundID = Users.First(user => user.Name == username).UserID;

            return RepositoryFacade.Instance.UserDataAccess.Get(userFoundID);
        }

        public void ModifyPassword(User userWithNewPassword)
        {
            Verifier.VerifyUser(userWithNewPassword);

            if (!Users.Exists(userInList => userInList.Equals(userWithNewPassword)))
            {
                throw new UserNotPresentException();
            }

            // Esto deberia de entrar un password, es pasar el que encontro y chau
            Users.First(us => us.Name == userWithNewPassword.Name).MainPassword = userWithNewPassword.MainPassword;
            if (_userDataAccess != null)
            {
                _userDataAccess.Modify(userWithNewPassword);
            }
                
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

        private void CheckSingleInstanceOfSingleton()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                throw new SingletonUniqueConditionException();
            }
        }
    }
}
