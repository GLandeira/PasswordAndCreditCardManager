using System;

namespace Domain.Exceptions
{
    public class UsernamePasswordException : Exception
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

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

