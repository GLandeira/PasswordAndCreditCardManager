using System;

namespace Domain.Exceptions
{
    public class PasswordStringPasswordException : Exception
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

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}