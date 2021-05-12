using System;

namespace Domain.Exceptions
{
    public class NumberCreditCardException : CreditCardException
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

        public override string Message => "Number input is incorrect, Credit Card numbers are 16 digits long";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}