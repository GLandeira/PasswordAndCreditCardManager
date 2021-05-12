using System;

namespace Domain.Exceptions
{
    public class CreditCardNotFoundException : CreditCardException
    {
        public CreditCardNotFoundException()
        {
        }

        public CreditCardNotFoundException(string message) : base(message)
        {
        }

        public CreditCardNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => "Credit Card wasnt found in the list";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

