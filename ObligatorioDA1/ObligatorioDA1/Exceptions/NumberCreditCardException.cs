using System;

namespace Domain.Exceptions
{
    public class NumberCreditCardException : Exception
    {
        public NumberCreditCardException()
        {
        }

        public NumberCreditCardException(string message) : base(message)
        {
        }

        public NumberCreditCardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}