using System;

namespace Domain.Exceptions
{
    public class PasswordNotFoundException : UserException
    {
        public PasswordNotFoundException()
        {
        }

        public PasswordNotFoundException(string message) : base(message)
        {
        }

        public PasswordNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

