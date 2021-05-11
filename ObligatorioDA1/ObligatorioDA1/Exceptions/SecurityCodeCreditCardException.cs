using System;

namespace Domain.Exceptions
{
    public class SecurityCodeCreditCardException : CreditCardException
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

        public override string Message => "Security code input is incorrect, Credit Card CVV are between 3 and 4 digits long";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}