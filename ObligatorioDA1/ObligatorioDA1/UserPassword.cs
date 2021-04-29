using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain
{
    public class UserPassword
    {
        private List<Password> _passwords;

        public List<Password> Passwords
        {
            get
            {
                return _passwords;
            }
            set
            {
                _passwords = value;
            }
        }

        public UserPassword()
        {
            this._passwords = new List<Password>();
        }

        public void AddPassword(Password password)
        {
            this._passwords.Add(password);
        }

        public void RemovePassword(Password password)
        {
            this._passwords.Remove(password);
        }

        public void ModifyPassword(Password modifiedPassword, Password oldPassword)
        {
            if(this._passwords.Any(ListIteratingPassword => ListIteratingPassword.Equals(modifiedPassword)))
            {
                throw new AlreadyExistingPasswordException();
            }
            else
            {
                this._passwords.Remove(oldPassword);
                this._passwords.Add(modifiedPassword);
            }
        }

    }
}
