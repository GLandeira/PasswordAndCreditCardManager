using System;

namespace Domain.Exceptions
{
    public class PasswordStringPasswordException : PasswordExceptions
    {
        public PasswordStringPasswordException()
        {
        }

        public PasswordStringPasswordException(string message) : base(message)
        {
        }

        public PasswordStringPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => "Password needs to be between 5 and 25 characters";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}