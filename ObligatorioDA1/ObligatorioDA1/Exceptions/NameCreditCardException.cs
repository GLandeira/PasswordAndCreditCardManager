using System;

namespace Domain.Exceptions
{
    public class NameCreditCardException : CreditCardException
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

        public override string Message => "Name input is incorrect, Credit Card names are between 3 and 25 characters";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
