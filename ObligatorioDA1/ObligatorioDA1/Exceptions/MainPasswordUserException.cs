using System;

namespace Domain.Exceptions
{
    public class MainPasswordUserException : Exception
    {
        public MainPasswordUserException()
        {
        }

        public MainPasswordUserException(string message) : base(message)
        {
        }

        public MainPasswordUserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
