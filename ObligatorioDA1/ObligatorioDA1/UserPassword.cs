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
        private User _theUser;

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

        public UserPassword(User theUser)
        {
            this._passwords = new List<Password>();
            _theUser = theUser;
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

        public void SharePassword(string sharee, Password sharedPassword)
        {
            PasswordShareDetails shareDetails = new PasswordShareDetails();
            shareDetails.sharerName = _theUser.Name;
            shareDetails.shareeName = sharee;
            shareDetails.sharedPassword = sharedPassword;

            PasswordSharer.Instance.SharePassword(shareDetails);
        }
    }
}
