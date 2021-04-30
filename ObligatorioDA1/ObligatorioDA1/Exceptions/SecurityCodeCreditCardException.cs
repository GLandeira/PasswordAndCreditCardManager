using System;

namespace Domain.Exceptions
{
    public class SecurityCodeCreditCardException : Exception
    {
        public SecurityCodeCreditCardException()
        {
        }

        public SecurityCodeCreditCardException(string message) : base(message)
        {
        }

        public SecurityCodeCreditCardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}