using System;

namespace Domain.Exceptions
{

    public class SitePasswordException : PasswordExceptions
    {
        public SitePasswordException()
        {
        }

        public override string Message => "Site needs to be between 3 and 25 characters";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}