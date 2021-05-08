using System;

namespace Domain.Exceptions
{
    public class ValidDueCreditCardException : Exception
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

        public override string Message => base.Message;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}