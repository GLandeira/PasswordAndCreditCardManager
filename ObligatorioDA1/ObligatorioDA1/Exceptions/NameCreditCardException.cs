using System;

namespace Domain.Exceptions
{
    public class NameCreditCardException : Exception
    {
        public NameCreditCardException()
        {
        }

        public NameCreditCardException(string message) : base(message)
        {
        }

        public NameCreditCardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
