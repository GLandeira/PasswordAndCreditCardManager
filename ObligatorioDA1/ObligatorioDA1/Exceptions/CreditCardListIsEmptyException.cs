using System;

namespace Domain.Exceptions
{
    public class CreditCardListIsEmptyException : CreditCardException
    {
        public CreditCardListIsEmptyException()
        {
        }

        public CreditCardListIsEmptyException(string message) : base(message)
        {
        }

        public CreditCardListIsEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => "There aren't any credit card submitted";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
