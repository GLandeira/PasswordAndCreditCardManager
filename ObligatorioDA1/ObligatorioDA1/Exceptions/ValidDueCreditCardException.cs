using System;

namespace Domain.Exceptions
{
    public class ValidDueCreditCardException : CreditCardException
    {
        public ValidDueCreditCardException()
        {
        }
        public override string Message => "Can not insert expired credit card";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}