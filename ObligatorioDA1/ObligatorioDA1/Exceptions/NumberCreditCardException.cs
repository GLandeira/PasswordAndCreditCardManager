using System;

namespace Domain.Exceptions
{
    public class NumberCreditCardException : CreditCardException
    {
        public NumberCreditCardException()
        {
        }

        public override string Message => "Number input is incorrect, Credit Card numbers are 16 digits long";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}