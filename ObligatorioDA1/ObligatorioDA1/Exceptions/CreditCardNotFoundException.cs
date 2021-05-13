using System;

namespace Domain.Exceptions
{
    public class CreditCardNotFoundException : CreditCardException
    {
        public CreditCardNotFoundException()
        {
        }

        public override string Message => "Credit Card wasnt found in the list";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

