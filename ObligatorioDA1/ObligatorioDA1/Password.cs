using System;
using System.Collections.Generic;
using Domain.PasswordSecurityFlagger;

namespace Domain
{
    public class Password : ICloneable
    {
        public string PasswordString { get; set; }
        public string Site { get; set; }
        public string Username { get; set; }
        public DateTime LastModification { get; set; }
        public SecurityLevelPasswords SecurityLevel { get; set; }
        public Category Category { get; set; }
        public string Notes { get; set; }
        public List<string> UsersSharedWith { get; private set; }

        public Password()
        {
            UsersSharedWith = new List<string>();
        }

        public bool AbsoluteEquals(Password password)
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

        public override string ToString()
        {
            return "[" + Category.ToString() + "][" + Site + "][" + Username + "]";  
        }
    }
}
