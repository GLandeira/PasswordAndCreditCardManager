using System;

namespace Domain
{
    public class PasswordHistory
    {
        public int PasswordHistoryID { get; set; }
        public Password Password { get; set; }
        public DataBreach DataBreachOrigin { get; set; }
        public string BreachedPasswordString { get; set; }

        public PasswordHistory()
        {

        }

        public PasswordHistory(int id, string oldPassword)
        {
            PasswordHistoryID = id;
            BreachedPasswordString = oldPassword;
        }
    }
}