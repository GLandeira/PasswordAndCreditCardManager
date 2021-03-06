using System;
using System.Collections.Generic;
using Domain.PasswordSecurityFlagger;

namespace Domain
{
    public class Password : ICloneable
    {
        public int PasswordID { get; set; }
        public string PasswordString { get; set; }
        public string Site { get; set; }
        public string Username { get; set; }
        public DateTime LastModification { get; set; }
        public SecurityLevelPasswords SecurityLevel { get; set; }
        public Category Category { get; set; }
        public string Notes { get; set; }
        public List<User> UsersSharedWith { get; set; }
        public UserPassword UserPassword { get; set; }
        public byte[] PasswordIV { get; set; }
        public byte[] PasswordKey { get; set; }

        public Password()
        {
            UsersSharedWith = new List<User>();
        }

        public bool AbsoluteEquals(Password password)
        {
            if (password == null)
            {
                return false;
            }

            bool areAbsolutelyEqual = Site == password.Site &&
                                      PasswordString == password.PasswordString &&
                                      Username == password.Username &&
                                      Notes == password.Notes &&
                                      Category.Equals(password.Category);
            return areAbsolutelyEqual;
        }

        public bool PasswordStringEquals(string otherPasswordString)
        {
            return otherPasswordString == PasswordString;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            bool areEqual = (Site == ((Password)obj).Site && Username == ((Password)obj).Username);
            return areEqual;
        }

        public object Clone()
        {
            Password clone = new Password();
            clone.PasswordID = PasswordID;
            clone.Category = Category;
            clone.Notes = Notes;
            clone.PasswordString = PasswordString;
            clone.UsersSharedWith = UsersSharedWith;
            clone.Username = Username;
            clone.Site = Site;
            clone.SecurityLevel = SecurityLevel;
            clone.LastModification = LastModification;
            clone.UserPassword = UserPassword;
            clone.PasswordIV = PasswordIV;
            clone.PasswordKey = PasswordKey;

            return clone;
        }

        public override string ToString()
        {
            return "[" + Category.ToString() + "][" + Site + "][" + Username + "]";  
        }
    }
}
