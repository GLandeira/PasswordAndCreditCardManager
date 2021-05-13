using System;

namespace Domain.Exceptions
{
    public class CreditCardRepeatedException : CreditCardException
    {
        public CreditCardRepeatedException()
        {
        }

        public override string Message => "This credit card number already exists in the database";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

