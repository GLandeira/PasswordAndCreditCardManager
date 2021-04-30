using System;

namespace Domain.Exceptions
{
    public class CreditCardRepeatedException : Exception
    {
        public CreditCardRepeatedException()
        {
        }

        public CreditCardRepeatedException(string message) : base(message)
        {
        }

        public CreditCardRepeatedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

