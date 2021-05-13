using System;

namespace Domain.Exceptions
{
    public class CreditCardException : Exception
    {
        public CreditCardException()
        {
        }

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
