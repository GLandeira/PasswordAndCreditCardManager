using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Password
    {
        private string _passwordString;
        private string _site;
        private string _username;
        private DateTime _lastModification;
        private SecurityLevelPasswords _securityLevel;
        private Category _category;
        private string _notes;
        private bool _isBreached = false;
        private List<string> _usersSharedWith = new List<string>();

        public string PasswordString
        {
            get 
            {
                return _passwordString;
            }
            set 
            {
                _passwordString = value;
            }
        }

        public string Site
        {
            get
            {
                return _site;
            }
            set
            {
                _site = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public DateTime LastModification
        {
            get
            {
                return _lastModification;
            }
            set
            {
                _lastModification = value;
            }
        }

        public SecurityLevelPasswords SecurityLevel
        {
            get
            {
                return _securityLevel;
            }
            set
            {
                _securityLevel = value;
            }
        }

        public Category Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
            }
        }

        public bool IsBreached
        {
            get
            {
                return _isBreached;
            }
            set
            {
                _isBreached = value;
            }
        }

        public List<string> UsersSharedWith
        {
            get
            {
                return _usersSharedWith;
            }
            set
            {
                _usersSharedWith = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            bool areEqual = (this.Site == ((Password)obj).Site && this.Username == ((Password)obj).Username);
            return areEqual;
        }
    }
}
