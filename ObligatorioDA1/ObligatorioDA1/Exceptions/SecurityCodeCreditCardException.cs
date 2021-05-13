using System;

namespace Domain.Exceptions
{
    public class SecurityCodeCreditCardException : CreditCardException
    {
        public SecurityCodeCreditCardException()
        {
        }

        public override string Message => "CVV input is incorrect, Credit Card CVV are between 3 and 4 digits long";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}