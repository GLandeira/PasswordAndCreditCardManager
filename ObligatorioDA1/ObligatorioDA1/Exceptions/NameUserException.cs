using System;

namespace Domain.Exceptions
{
    public class NameUserException : UserException
    {
        public NameUserException()
        {
        }

        public NameUserException(string message) : base(message)
        {
        }

        public NameUserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

