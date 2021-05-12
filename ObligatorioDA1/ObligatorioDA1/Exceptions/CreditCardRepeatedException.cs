using System;

namespace Domain.Exceptions
{
    public class CreditCardRepeatedException : CreditCardException
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

        public override string Message => "This credit card number already exists in the database";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

