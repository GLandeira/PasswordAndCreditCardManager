using System;

namespace Domain.Exceptions
{
    public class UsernamePasswordException : PasswordExceptions
    {
        public UsernamePasswordException()
        {
        }

        public override string Message => "Username needs to be between 5 and 25 characters";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

