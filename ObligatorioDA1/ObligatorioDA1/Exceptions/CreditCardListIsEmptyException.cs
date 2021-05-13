using System;

namespace Domain.Exceptions
{
    public class CreditCardListIsEmptyException : CreditCardException
    {
        public CreditCardListIsEmptyException()
        {
        }

        public override string Message => "There aren't any credit card submitted";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
