using System;

namespace Domain.Exceptions
{
    public class CreditCardException : Exception
    {
        public CreditCardException()
        {
        }

        public CreditCardException(string message) : base(message)
        {
        }

        public CreditCardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
