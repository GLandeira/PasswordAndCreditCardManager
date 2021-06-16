using System;

namespace Domain
{
    public class PasswordHistory
    {
        public int PasswordHistoryID { get; set; }
        public Password Password { get; set; }
        public string BreachedPasswordString { get; set; }

        public PasswordHistory()
        {

        }

        public PasswordHistory(int id, string oldPassword)
        {
            PasswordHistoryID = id;
            BreachedPasswordString = oldPassword;
        }

        public override bool Equals(object obj)
        {
            PasswordHistory entry = (PasswordHistory)obj;
            bool areEqual = entry.Password.Equals(Password);

            return areEqual;
        }

        public bool AbsoluteEquals(PasswordHistory passHistory)
        {
            bool equalString = this.BreachedPasswordString.Equals(passHistory.BreachedPasswordString);
            bool equalPassword = this.Password.Equals(passHistory.Password);
            return equalPassword && equalString;
        }
    }
}