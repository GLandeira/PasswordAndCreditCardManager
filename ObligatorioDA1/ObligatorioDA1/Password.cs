using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.PasswordSecurityFlagger;

namespace Domain
{
    public class Password : ICloneable
    {
        public string _passwordString;
        public string _site;
        public string _username;
        public DateTime _lastModification;
        public SecurityLevelPasswords _securityLevel;
        public Category _category;
        public string _notes;
        public List<string> _usersSharedWith = new List<string>();

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

        internal bool AbsoluteEquals(Password password)
        {
            if (password == null)
            {
                return false;
            }

            bool areAbsolutelyEqual = this.Site == password.Site &&
                                      this.PasswordString == password.PasswordString &&
                                      this.Username == password.Username &&
                                      this.Notes == password.Notes &&
                                      this.Category.Equals(password.Category);
            return areAbsolutelyEqual;
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

        public object Clone()
        {
            Password clone = new Password();
            clone.Category = this.Category;
            clone.Notes = this.Notes;
            clone.PasswordString = this.PasswordString;
            clone.UsersSharedWith = this.UsersSharedWith;
            clone.Username = this.Username;
            clone.Site = this.Site;
            clone.SecurityLevel = this.SecurityLevel;
            clone.LastModification = this.LastModification;

            return clone;
        }
    }
}
