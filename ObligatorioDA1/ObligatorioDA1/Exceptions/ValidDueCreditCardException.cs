using System;

namespace Domain.Exceptions
{
    public class ValidDueCreditCardException : CreditCardException
    {
        public ValidDueCreditCardException()
        {
        }

        public ValidDueCreditCardException(string message) : base(message)
        {
        }

        public ValidDueCreditCardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string Message => "Can not insert expired credit card";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}