using System;

namespace Domain.Exceptions
{
    public class SitePasswordException : CreditCardException
    {
        public SitePasswordException()
        {
        }

        public SitePasswordException(string message) : base(message)
        {
        }

        public SitePasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}