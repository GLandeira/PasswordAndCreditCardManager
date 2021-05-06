using System;

namespace Domain.Exceptions
{
    public class CreditCardNotFoundException : UserException
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

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

