using System;

namespace Domain.Exceptions
{
    public class UsernamePasswordException : PasswordExceptions
    {
        public UsernamePasswordException()
        {
        }

        public UsernamePasswordException(string message) : base(message)
        {
        }

        public UsernamePasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => "Username needs to be between 5 and 25 characters";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

