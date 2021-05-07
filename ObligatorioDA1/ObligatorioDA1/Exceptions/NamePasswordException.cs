using System;

namespace Domain.Exceptions
{
    public class NamePasswordException : Exception
    {
        public NamePasswordException()
        {
        }

        public NamePasswordException(string message) : base(message)
        {
        }

        public NamePasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}